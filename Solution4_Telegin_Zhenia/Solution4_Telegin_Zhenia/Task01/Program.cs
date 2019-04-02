using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task01
{
    class User
    {
        public string _name;
        public string _surname;
        public string _middlename;
        public DateTime _dateofBirth;
        public int _age;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
            }
        }

        public DateTime DateofBirth
        {
            get
            {
                return _dateofBirth;
            }
            set
            {
                _dateofBirth = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = DateTime.Now.Year - value;
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("surname: "+ _surname);
            Console.WriteLine("middlename: " + _middlename);
            Console.WriteLine("Date of birth: " + _dateofBirth.ToShortDateString());
            Console.WriteLine("Age: " + _age);
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            Console.WriteLine("Add new user");
            Console.Write("Enter the name: ");
            user.Name = Console.ReadLine();
            user.Name = CheckString(user.Name);

            Console.Write("Enter the surname: ");
            user.Surname = Console.ReadLine();
            user.Surname = CheckString(user.Surname);

            Console.Write("Enter the middlename: ");
            user.Middlename = Console.ReadLine();
            user.Middlename = CheckString(user.Middlename);

            Console.WriteLine("Enter the dateofBirth(where dd.mm.yyyy): ");
            string date = Console.ReadLine();
            date = CheckDate(date);
            user.DateofBirth = DateTime.Parse(date);
            user.Age = user.DateofBirth.Year;

            user.PrintAll();
        }

        static string CheckString(string str)
        {
            Regex input = new Regex("[a-zA-Zа-яА-Я]");
            while ((str == null) || (!input.Match(str).Success))
            {
                Console.WriteLine("Invalid input! Please, repeat input!");
                str = Console.ReadLine();
            }
            return str;
        }


        static string CheckDate(string date)
        {
            Regex input = new Regex(@"(\d\d)[\s\.](\d\d)[\s\.](\d\d\d\d)");
            while ((date == null) || (!input.Match(date.ToString()).Success))
            {
                Console.WriteLine("Invalid input! Please, repeat input!");
                date = Console.ReadLine();
            }
            return date;
        }
    }
}
