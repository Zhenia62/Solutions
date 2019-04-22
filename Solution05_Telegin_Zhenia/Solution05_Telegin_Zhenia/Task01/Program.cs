using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task01
{

    class Program
    {
        public static User user = new User();
        public static Employee employee = new Employee();

        public static int flag =0;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;


            Console.WriteLine("Add new user");
            Console.Write("Enter the name: ");
            user.Name = Console.ReadLine();
            user.Name = CheckString(user.Name);

            Console.Write("Enter the surname: ");
            user.Surname = Console.ReadLine();
            user.Surname = CheckString(user.Surname);

            Console.Write("Enter the dateofBirth (where dd.mm.yyyy): ");
            string date = Console.ReadLine();
            user.DateofBirth = CheckDate(date);

            
            Console.Write("Enter the post: ");
            employee.Post = Console.ReadLine();
            employee.Post = CheckString(employee.Post);

            flag++;
            Console.Write("Date of employment (where dd.mm.yyyy): ");
            date = Console.ReadLine();
            employee.DateOfEmployment = CheckDate(date);

            employee = new Employee(user.Name, user.Surname, user.DateofBirth, user.Age(user.DateofBirth), employee.Post, employee.Experience(employee.DateOfEmployment));
            Employee emp = new Employee("Roma", user.Surname, user.DateofBirth, user.Age(user.DateofBirth), employee.Post, employee.Experience(employee.DateOfEmployment));

            Console.WriteLine(employee.Equals(emp));
            Console.ReadKey();
        }

        public static string CheckString(string str)
        {
            Regex input = new Regex("[a-zA-Zа-яА-Я]");
            while ((str == null) || (!input.Match(str).Success))
            {
                Console.WriteLine("Invalid input! Please, repeat input!");
                str = Console.ReadLine();
            }
            return str;
        }
        public static DateTime CheckDate(string date)
        {
            Regex input = new Regex(@"(^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19[5-9][0-9]|20[0-1][0-9]))$");

            while ((date == null) || (!input.Match(date.ToString()).Success) || (DateTime.Parse(date) > DateTime.Now) || ((DateTime.Parse(date) <= user.DateofBirth) && (flag == 1)))
            {
                Console.WriteLine("Invalid input! Please, repeat input!");
                date = Console.ReadLine();
            }
            return DateTime.Parse(date);
        }
    }
}
