using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Ilya : Person2
    {
        /// <summary>
        /// Событие - начало Хакатона
        /// </summary>
        internal event EventHandler Hackathon;

        internal Ilya(string name, string surname, string tracked_event)
        {
            this.name = name;
            this.surname = surname;
            this.tracked_event = tracked_event;
        }

        internal override void CreateEvent()
        {
            if (Hackathon != null)
            {
                Hackathon(this, new EventArgs());
            }
        }
    }
}