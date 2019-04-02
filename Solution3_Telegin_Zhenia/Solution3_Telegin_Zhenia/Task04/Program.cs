using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string str = "";
            StringBuilder sb = new StringBuilder();
            int n = 10000;

            Console.WriteLine("Firs experiment");
            Console.WriteLine("The application started at {0:ss.fff}", DateTime.Now);
            for (int i = 0; i < n; i++)
            {
                str += "*";
            }
            Console.WriteLine("The application expired at {0:ss.fff} \n", DateTime.Now);

            Console.WriteLine("Second experiment");
            Console.WriteLine("The application started at {0:ss.fff}", DateTime.Now);
            for (int i = 0; i < n; i++)
            {
                sb.Append("*");
            }
            Console.WriteLine("The application expired at {0:ss.fff}", DateTime.Now);

            Console.ReadKey();
        }
    }
}
