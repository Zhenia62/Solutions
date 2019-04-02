using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Please, enter the first string");
            var firststr = Console.ReadLine();

            Console.WriteLine("Please, enter the second string");
            var secondstr = Console.ReadLine();

            var finalstr = MultiplySym(firststr, secondstr);
            Console.WriteLine($"Result: {finalstr}");
            Console.ReadKey();
        }

        static string MultiplySym(string str1, string str2)
        {
            var str3 = "";

            foreach (char simb in str1)
            {
                if (!string.Equals(str2, simb.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    str3 += simb;
                }
                else
                {
                    str3 += simb;
                    str3 += simb;
                }
            }
            return str3;
        }
    }
}
