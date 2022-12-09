using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal abstract class Person2
    {
        internal string name;
        internal string surname;
        internal string tracked_event;

        /// <summary>
        /// Создание события в наследуемых классах
        /// </summary>
        internal abstract void CreateEvent();
    }
}