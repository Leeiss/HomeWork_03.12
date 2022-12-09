using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Adelya : Person2
    {
        /// <summary>
        /// Событие - новый лайк под аватаркой
        /// </summary>
        internal event EventHandler ConcertMaksim;

        internal Adelya(string name, string surname, string tracked_event)
        {
            this.name = name;
            this.surname = surname;
            this.tracked_event = tracked_event;
        }
        internal override void CreateEvent()
        {
            if (ConcertMaksim != null)
            {
                ConcertMaksim(this, new EventArgs());
            }
        }
    }
}