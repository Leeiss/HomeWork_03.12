using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_03._12._22
{
    public class Events
    {
        delegate void Event(string message);
        event Event Notify;
        
    }
}
