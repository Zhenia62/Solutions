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
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Please, enter the new string");
            var str = Console.ReadLine();
            var lenght = CountWords(str);
            Console.WriteLine($"Average length words = {lenght}");
            Console.ReadKey();
        }

        static int CountWords(string str)
        {
            str = Regex.Replace(str, "[-.,&!:;'()]", "");
            string[] words = str.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var lenght = words.Aggregate(0, (count, nextWord) => count += nextWord.Length) / words.Length;
            return lenght;
        }
    }
}
