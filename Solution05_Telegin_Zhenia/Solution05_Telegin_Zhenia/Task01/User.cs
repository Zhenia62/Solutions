using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class User
    {
        protected string _name;
        protected string _surname;
        protected DateTime _dateofBirth;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public DateTime DateofBirth { get => _dateofBirth; set => _dateofBirth = value;
        }
        public User()
        {

        }

        public int Age(DateTime date)
        {
            int age = DateTime.Now.Year - date.Year;

            if ((DateTime.Now.Month < date.Month) || ((DateTime.Now.Month == date.Month) && (DateTime.Now.Day < date.Day)))
            {
                age--;
            }
            return age;
        }

        public User(string name, string surname, DateTime date, int age)
        {
            Name = name;
            Surname = surname;
            DateofBirth = date;
            int years = age;
        }

    }
}
