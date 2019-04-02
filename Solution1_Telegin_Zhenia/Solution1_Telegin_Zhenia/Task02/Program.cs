using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var count = 0;
            Console.WriteLine("Please, enter the count of lines");
            var number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
            var str = new string('*', count+=1);
            Console.WriteLine(str);
            }
            Console.ReadKey();
        }
    }
}
