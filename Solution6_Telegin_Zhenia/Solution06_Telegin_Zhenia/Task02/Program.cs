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
            PrintSeries();
            Console.ReadKey();
        }

        public static void PrintSeries()
        {
            Progress progress = new Progress();
            for (int i = 0; i < 20; i++)
                Console.WriteLine("Next number= " + progress.GetNext());
        }
    }
}
