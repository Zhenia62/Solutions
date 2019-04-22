using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
   
    class EmployeeEventArgs : EventArgs
    {
        public Person Person { get; set; }

        public EmployeeEventArgs(Person person)
        {
            Person = person;
        }
    }
}
