using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Event
    {
        internal string name_event;
        internal DateTime date_event;
        internal string raffle_item;
        internal byte cnt_in_group;
        internal byte cnt_group;

        /// <summary>
        /// Название мероприятия, дата проведения, что разыгрывают, количество заявленных групп, количество студентов в одной группе
        /// </summary>
        /// <param name="name_event"></param>
        /// <param name="date_event"></param>
        /// <param name="raffle_item"></param>
        /// <param name="cnt_in_group"></param>
        /// <param name="cnt_group"></param>
        internal Event(string name_event, DateTime date_event, string rafle_item, byte cnt_in_group, byte cnt_group)
        {
            this.name_event = name_event;
            this.date_event = date_event;
            this.raffle_item = rafle_item;
            this.cnt_in_group = cnt_in_group;
            this.cnt_group = cnt_group;
        }

        /// <summary>
        /// Запись всей информации о мероприятии в заранее созданный файл
        /// </summary>
        
        internal void WriteEventFile(Event @event, List<string> groups_event, Dictionary<string, List<Person1>> event_participants)
        {
            StreamWriter event_file = new StreamWriter(@"C:\\Users\\farra\\source\\repos\\HomeWork_03.12.22\\HomeWork_03.12.22\\events_first_task.txt");
            event_file.Write($"{@event.name_event};");
            event_file.Write($"{@event.date_event.ToLongDateString()};");
            event_file.Write($"{@event.raffle_item};");
            for (int i = 0; i < groups_event.Count; i++)
            {
                for (int j = 0; j < @event.cnt_in_group; j++)
                {
                    var student = event_participants[groups_event[i]][j];
                    event_file.Write($"{groups_event[i]},{student.name},{student.surname};");
                }
            }
            event_file.WriteLine();
            event_file.Close();
        }
    }
}