using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            int[] array = new int[10];
            Random random = new Random();

            Console.WriteLine("New array");
            for (int i = 0; i < 10; i++)
            {
               array[i] = random.Next(-20, 20);
                Console.Write("|" +array[i]);
            }
            Console.WriteLine();

            MaxValue(array);
            MinValue(array);
            Sort(array);

            Console.ReadKey();
        }
        static void MaxValue(int[] arg)
        {
            int max = arg[0];
            for (int i = 0; i < arg.Length - 1; i++)
            {
                if (arg[i] > max)
                {
                    max = arg[i];
                }
            }Console.WriteLine($"Maximum value = {max}");
        }
        static void MinValue(int[] arg)
        {
            int min = arg[0];
            for (int i = 0; i < arg.Length - 1; i++)
            {
                if (arg[i] < min)
                {
                    min = arg[i];
                }             
            }Console.WriteLine($"Minimum value = {min}");
        }
        static void Sort(int[] arg)
        {
            int per;
            Console.WriteLine("Sorted array");
            for (int i = 0; i < arg.Length; i++)
            {
                for (int j = i + 1; j < arg.Length; j++)
                {
                    if (arg[i] > arg[j])
                    {
                        per = arg[i];
                        arg[i] = arg[j];
                        arg[j] = per;
                    }
                }Console.Write("|" + arg[i]);
            }
            Console.WriteLine();
        }
    }
}
