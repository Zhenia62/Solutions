using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Please, enter the string...");
            var str = Console.ReadLine();

            var count = CountWordsTime(str);
            Console.WriteLine($"Result={count}");
            Console.ReadKey();
        }

        static int CountWordsTime(string str)
        {
            
            int count = Regex.Matches(str, @"([0-1]?[0-9]|2[0-3]):[0-5][0-9]$").Count;
            return count;
        }

        //Regex rgx = new Regex("[^0-9: -]");
        //str = rgx.Replace(str, "");
        //string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        //int count = 0;
        //foreach (var elem in words)
        //{
        //    var res = Regex.IsMatch(elem, @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");

        //    if (res == true)
        //    {
        //        count++;
        //    }
        //}
        //return count;
    }
}
