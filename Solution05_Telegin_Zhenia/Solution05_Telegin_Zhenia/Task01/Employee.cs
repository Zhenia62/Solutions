using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Employee : User
    {
        private string _post;
        private DateTime _dateofemployment;


        public string Post { get => _post; set => _post = value;}

        public Employee()
        {

        }


        public DateTime DateOfEmployment { get => _dateofemployment; set => _dateofemployment = value;}

        public int Experience(DateTime date)
        {         
            int year = DateTime.Now.Year - date.Year;
            return year;
        }

        public Employee(string name, string surname, DateTime date, int age, string post, int experience)
            : base(name, surname, date,age)
        {
            this.Post = post;
            int exp = experience;

            string str = "";
            if (DateTime.Now.Month > DateOfEmployment.Month)
            {
                str = ">";
            }
            

            PrintAll(name,surname,date,age, post,str,experience);
        }

        public void PrintAll(string name, string surname, DateTime date, int age, string post, string str, int experience)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Date of birth: {date.ToShortDateString()}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Post: {post}");
            Console.WriteLine($"Experience:{str}{experience}");
        }
    }
}
