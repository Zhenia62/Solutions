using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static List<Person> employeesList;
        static void Main(string[] args)
        {
            employeesList = new List<Person>()
            {
                new Person("Женя"),
                new Person("Артем"),
                new Person("Катя"),
                new Person("Аня")
            };

            foreach (var employee in employeesList)
            {
                employee.ArrivedToOffice += Employee_ArrivedToOffice;
                employee.LeftOffice += Employee_LeftOffice;
            }

            var zhenia = employeesList.FirstOrDefault(e => e.Name == "Женя");
            var artem = employeesList.FirstOrDefault(e => e.Name == "Артем");
            var katya = employeesList.FirstOrDefault(e => e.Name == "Катя");
            var anna = employeesList.FirstOrDefault(e => e.Name == "Аня");



            Console.WriteLine("[Женя пришел]");
            zhenia.CheckIn();

            Console.WriteLine("\n[Артем пришел]");
            artem.CheckIn();

            Console.WriteLine("\n[Катя пришла]");
            katya.CheckIn();

            Console.WriteLine("\n[Артем ушел]");
            artem.CheckOut();

            Console.WriteLine("\n[Аня пришла]");
            anna.CheckIn();

            Console.WriteLine("\n[Аня ушла]");
            anna.CheckOut();

            Console.WriteLine("\n[Катя ушла]");
            katya.CheckOut();

            Console.WriteLine("\n[Женя ушел]");
            zhenia.CheckOut();


            Console.ReadKey();
        }

        private static void Employee_ArrivedToOffice(object sender, EmployeeEventArgs args)
        {
            var list = employeesList
                .Where(e => e.Name != args.Person.Name && e.AtWork)
                .OrderBy(e => e.TimeIn);

            if (list.Count() == 0)
            {
                Console.WriteLine("В офисе никого нет...");
                return;
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.Greet(args.Person));
            }
        }

        private static void Employee_LeftOffice(object sender, EmployeeEventArgs args)
        {
            var list = employeesList
               .Where(e => e.Name != args.Person.Name && e.AtWork)
               .OrderBy(e => e.TimeIn);

            if (list.Count() == 0)
            {
                Console.WriteLine("В офисе больше никого нет...");
                return;
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.SayGoodbye(args.Person));
            }
        }
    }
}
