using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    //public delegate void Message(string name);
    //public delegate void OfficeEventHandler(object sender, OfficeEventArgs args);

    delegate void EmployeeEventHandler(object sender, EmployeeEventArgs args);

    class Person
    {
        public string Name { get; set; }
        public DateTime TimeIn { get; private set; }
        public bool AtWork { get; private set; }

        public event EmployeeEventHandler ArrivedToOffice;
        public event EmployeeEventHandler LeftOffice;

        protected virtual void OnArrivedToOffice(EmployeeEventArgs e)
        {
            ArrivedToOffice?.Invoke(this, e);
        }

        protected virtual void OnLeftOffice(EmployeeEventArgs e)
        {
            LeftOffice?.Invoke(this, e);
        }

        public Person(string name)
        {
            Name = name;
        }


        public void CheckIn()
        {
            AtWork = true;
            TimeIn = DateTime.Now;
            OnArrivedToOffice(new EmployeeEventArgs(this));
        }

        public void CheckOut()
        {
            AtWork = false;
            TimeIn = DateTime.MinValue;
            OnLeftOffice(new EmployeeEventArgs(this));
        }

        public string Greet(Person person)
        {
            int hour = person.TimeIn.Hour;
            string greeting = "Доброе утро";

            if (hour >= 12 && hour < 17)
            {
                greeting = "Добрый день";
            }
            else if (hour >= 17 || hour < 6)
            {
                greeting = "Добрый вечер";
            }

            return $"{Name}: \"{greeting}, {person.Name}!\"";
        }

        public string SayBye(Person person)
        {
            return $"{Name}: \"Пока, {person.Name}!\"";
        }
    }
}