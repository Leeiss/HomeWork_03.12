using System;
using System.Security.Cryptography.X509Certificates;

namespace Homework
{
    class Program
    {
        /// <summary>
        /// Метод возвращает нужно количество групп (cnt_group), выбирая из groups
        /// </summary>
       
        static List<string> ReturnGroupss(List<string> groups, byte cnt_group)
        {
            List<string> groupsnew = new();
            Random rnd = new();
            int temp = groups.Count - cnt_group;
            for (byte i = 0; i < temp; i++)
            {
                groupsnew.RemoveAt(rnd.Next(groups.Count));
            }
            return groupsnew;
        }

        static void Main(string[] args)
        {
            Random rnd = new();
            string[] file_students = File.ReadAllLines(@"C:\\Users\\farra\\source\\repos\\HomeWork_03.12.22\\HomeWork_03.12.22\\students.txt");
            Dictionary<string, List<Person1>> students = new();
            // список всех студентов (кроме активистов)

            Dictionary<string, List<Person1>> activists = new();
            // список только активистов

            List<string> list_group = new(); // список всех представленных групп
            int all_students = 0;

            for (int i = 0; i < file_students.Length; i++)
            {
                string[] temp = file_students[i].Split(","); // 0 - фамилия, 1 - имя, 2 - группа, 3 - активист (true/false)
                if (bool.Parse(temp[3]))
                {
                    if (activists.ContainsKey(temp[2]))  // если данной группы нет в словаре (в виде ключа), то ее нужно добавить
                    {
                        activists[temp[2]].Add(new Person1(temp[0], temp[1], temp[2], false, bool.Parse(temp[3]), 0));
                    }
                    else
                    {
                        activists.Add(temp[2], new List<Person1> { new Person1(temp[0], temp[1], temp[2], false, bool.Parse(temp[3]), 0) });
                    }
                }
                else
                {
                    if (students.ContainsKey(temp[2]))
                    {
                        students[temp[2]].Add(new Person1(temp[0], temp[1], temp[2], false, bool.Parse(temp[3]), 0));
                    }
                    else
                    {
                        students.Add(temp[2], new List<Person1> { new Person1(temp[0], temp[1], temp[2], false, bool.Parse(temp[3]), 0) });
                    }
                }

                if (!list_group.Contains(temp[2]))
                {
                    list_group.Add(temp[2]);
                }
                all_students++;
            }

            Console.WriteLine("Вы создаете мероприятия для студентов.\n");

            bool end_program = false;
            while (!end_program)
            {
                try
                {
                    Console.WriteLine("Название мероприятия:");
                    string name_event = Console.ReadLine();

                    Console.WriteLine("Дата мероприятия в формате: 01.01.2001");
                    DateTime date_event = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Что разыграют в этом мероприятии?");
                    string rafle_item = Console.ReadLine();

                    Console.WriteLine("Сколько нужно участников от одной группы и сколько групп. Написать числа через пробел:");
                    string[] temp = Console.ReadLine().Split(" ");
                    byte cnt_in_group = byte.Parse(temp[0]);  // нужное кол-во студентов в одной группе
                    byte cnt_group = byte.Parse(temp[1]);    // нужное кол-во групп 
                    if (cnt_in_group * cnt_group > all_students)
                    {
                        while (cnt_in_group * cnt_group > all_students)
                        {
                            Console.WriteLine($"В вашем мероприятии должно участвовать {cnt_in_group * cnt_group} человек, " +
                                $"а студентов всего {all_students}.\n" +
                                $"Задайте новое количество участников от одной группы и количество групп");
                            temp = Console.ReadLine().Split(" ");
                            cnt_in_group = byte.Parse(temp[0]);
                            cnt_group = byte.Parse(temp[1]);
                        }
                    }
                    Event this_event = new(name_event, date_event, rafle_item, cnt_in_group, cnt_group);


                    Dictionary<string, List<Person1>> event_participants = new();
                    // участники мероприятия

                    int places_for_activists = cnt_in_group / 2;

                    List<string> groups_event = ReturnGroupss(list_group, cnt_group);

                    for (byte i = 0; i < groups_event.Count; i++)
                    {
                        event_participants.Add(groups_event[i], new List<Person1>());
                        // добавляет ключи-группы в список участников мероприятия и пустые списки (как значение ключа)
                    }


                    // добавили активистов из разных групп в мероприятие
                    for (int i = 0; i < groups_event.Count; i++)
                    {
                        var temp1 = activists[groups_event[i]];

                        if (temp1.Count > places_for_activists)
                        {
                            for (int j = 0; j < places_for_activists; j++)
                            {
                                int temp2 = rnd.Next(temp1.Count);
                                if (!temp1[temp2].now_active)
                                {
                                    event_participants[groups_event[i]].Add(temp1[temp2]);
                                    temp1[temp2].now_active = true;
                                    temp1[temp2].missed_events_row = 0;
                                }
                                // добавляем случайных активистов из нужных групп
                            }
                        }
                        else
                        {
                            for (int j = 0; j < temp1.Count; j++)
                            {
                                if (!temp1[j].now_active)
                                {
                                    event_participants[groups_event[i]].Add(temp1[j]);
                                    temp1[j].now_active = true;
                                    temp1[j].missed_events_row = 0;
                                }
                                // добавляем всех активистов из нужных групп на мероприятие
                            }
                        }
                    }


                    // добавили всех остальных участников на мероприятие
                    for (int i = 0; i < groups_event.Count; i++)
                    {
                        var temp3 = groups_event[i];
                        int left_to_choose = cnt_in_group - event_participants[temp3].Count;

                        for (int j = 0; j < left_to_choose; j++)
                        {
                            if (students[temp3][j].missed_events_row >= 3)
                            {
                                if (rnd.Next(3) == 0)
                                {
                                    event_participants[temp3].Add(students[temp3][j]);
                                    students[temp3][j].now_active = true;
                                    students[temp3][j].missed_events_row = 0;
                                    // у кого 3 и более пропущенных подряд мероприятий, есть 33% шанс попасть на этот эвент;
                                    // помимо общего случайного выбора (будет чуть ниже)
                                }
                            }
                        }

                        int cnt = left_to_choose;
                        while (cnt != 0)
                        {
                            int temp4 = rnd.Next(students[temp3].Count);
                            if (!students[temp3][temp4].now_active)
                            {
                                event_participants[temp3].Add(students[temp3][temp4]);
                                students[temp3][temp4].now_active = true;
                                students[temp3][temp4].missed_events_row = 0;
                                cnt--;
                            }
                           // случайный выбор из всех студентов с подходящими группами
                        }
                    }

                    this_event.WriteEventFile(this_event, groups_event, event_participants);
                    // записываем всю информацию о мероприятии в файл
                    Console.WriteLine("\nМероприятие создано, все данные записаны в файл \"events_first_task.txt\"\n");





                    // проходимся по все активистам (помечаем тех кто не был на мероприятии)
                    for (int i = 0; i < list_group.Count; i++)
                    {
                        for (int j = 0; j < activists[list_group[i]].Count; j++)
                        {
                            if (activists[list_group[i]][j].now_active)
                            {
                                activists[list_group[i]][j].now_active = false;
                            }
                            else
                            {
                                activists[list_group[i]][j].missed_events_row++;
                            }
                        }
                    }

                    // проходимся по всем остальным студентам (помечаем тех, кто не был на мероприятии)
                    for (int i = 0; i < list_group.Count; i++)
                    {
                        for (int j = 0; j < students[list_group[i]].Count; j++)
                        {
                            if (students[list_group[i]][j].now_active)
                            {
                                students[list_group[i]][j].now_active = false;
                            }
                            else
                            {
                                students[list_group[i]][j].missed_events_row++;
                            }
                        }
                    }

                    Console.WriteLine("Если хотите создать еще одно мероприятие, то нажмите \"Enter\"");
                    Console.WriteLine("Если не хотите, то введите \"конец\"");
                    string temp_word = Console.ReadLine();
                    if (temp_word.Equals("конец"))
                    {
                        end_program = true;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.Clear();
            Console.WriteLine("Создайте события");
            StreamReader eveent = new(@"C:\Users\farra\source\repos\HomeWork_03.12.22\HomeWork_03.12.22\events_second_task.txt");
            List<string> events = new();
            string line;
            while ((line = eveent.ReadLine()) != null)
            {
                events.Add(line);
            }
            Ilya ilya = new("Илья", "Романов", "Начало Хакатона");
            ilya.Hackathon += Ilya_Hackathon;

            Adelya adelya = new("Аделя", "Гильфанова", "Концерт Максим");
            adelya.ConcertMaksim += Adelya_ConcertMaksim;

            Maria maria = new("Мария", "Гаврилова", "Выход нового сезона <<Очень странные дела>>");
            maria.MovieCameOut += Maria_MovieCameOut;

            List<Person2> people = new() { ilya, adelya, maria };

            bool final_program = false;
            while (!final_program)
            {
                Console.WriteLine("Есть следующие потенциальные события: \n");
                for (byte i = 0; i < events.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {events[i]}");
                }
                Console.WriteLine("\nСоздайте одно из них, написав его название:");
                string event_user = Console.ReadLine();

                bool is_mass = false;
                while (!is_mass)
                {
                    for (byte i = 0; i < events.Count; i++)
                    {
                        if (events[i].Equals(event_user))
                        {
                            is_mass = true;
                        }
                    }
                    if (!is_mass)
                    {
                        Console.WriteLine("Написанного вами события нет в списке, заново укажите событие");
                        event_user = Console.ReadLine();
                    }
                }
                Console.WriteLine();

                int temp = 0;
                for (byte i = 0; i < people.Count; i++)
                {
                    if (people[i].tracked_event.Equals(event_user))
                    {
                        people[i].CreateEvent(); // создаем событие
                        temp++;
                    }
                }
                if (temp == 0)
                {
                    Console.WriteLine("Данное событие никто не отслеживает");
                }

                events.Remove(event_user);  // удаляем использованное событие


                Console.WriteLine("\nЕсли хотите хотите создать еще одно событие, то нажмите \"Enter\"");
                Console.WriteLine("Если не хотите, то введите: \"конец\"");
                string temp_word = Console.ReadLine();

                if (temp_word.Equals("конец"))
                {
                    final_program = true;
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private static void Ilya_Hackathon(object? sender, EventArgs e)
        {
            Console.WriteLine("Илья обрадовался началу Хакатона, но, прочитав информацацию, разочаровался, ведь в этом году будет скретч.....");
        }

        private static void Adelya_ConcertMaksim(object? sender, EventArgs e)
        {
            Console.WriteLine("Аделя срочно бежит покупать билеты на концерт максим, напевая знаешь ли тыыы вдоооль ночных дорог");
        }

        private static void Maria_MovieCameOut(object? sender, EventArgs e)
        {
            Console.WriteLine("Мария в шоке, ведь обычно осд выходят раз в три года");
        }
    }
}