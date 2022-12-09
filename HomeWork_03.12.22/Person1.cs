using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Person1
    {
        internal string name;
        internal string surname;
        internal string group;
        internal bool now_active;
        internal bool activist;
        internal byte missed_events_row;

        /// <summary>
        /// Имя студента, фамилия, группа, задействован ли в данном мероприятии, активист (true/false), 
        /// количество подряд пропущенных мероприятий
        /// </summary>
        
        internal Person1(string name, string surname, string group, bool now_active, bool activist, byte missed_events_row)
        {
            this.name = name;
            this.surname = surname;
            this.group = group;
            this.now_active = now_active;
            this.activist = activist;
            this.missed_events_row = missed_events_row;
        }
    }
}