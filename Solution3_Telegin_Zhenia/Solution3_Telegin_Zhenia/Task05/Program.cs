using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Basic string");  
            var str = "<b>Это</b> текст <i>с</i> <font color=”red”>HTML</font> кодами";
            var finalstr = Replace(str);
            Console.WriteLine($"Result: {finalstr}");
            Console.ReadKey();
        }

        static string Replace(string str)
        {
            str = Regex.Replace(str, @"(\<.*?\>)", "_");
            return str;
        }
    }
}
