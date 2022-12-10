using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Maria : Person2
    {
        /// <summary>
        /// Событие - вышел новый сезон осд
        /// </summary>
        internal event EventHandler MovieCameOut;

        internal Maria(string name, string surname, string tracked_event)
        {
            this.name = name;
            this.surname = surname;
            this.tracked_event = tracked_event;
        }

        internal override void CreateEvent()
        {
            if (MovieCameOut != null)
            {
                MovieCameOut(this, new EventArgs());
            }
        }
    }
}