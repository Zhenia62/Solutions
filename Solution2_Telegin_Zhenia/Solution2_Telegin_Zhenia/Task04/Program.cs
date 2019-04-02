using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        static int Sum = 0;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Please, enter the count elements to array");
            Console.Write("Count columns= ");
            int columns = int.Parse(Console.ReadLine());
            columns = Check(columns);
            Console.Write("Count rows= ");
            int rows = int.Parse(Console.ReadLine());
            rows = Check(rows);

            BasicArray(rows, columns);

            Console.WriteLine($"Sum = {Sum}");
            Console.ReadKey();
        }
        static int Check(int value)
        {
            while (value < 0)
            {
                Console.WriteLine("Count can't be negative");
                Console.Write("Please, enter the new count: ");
                value = int.Parse(Console.ReadLine());
            }
            return value;
        }
        static void BasicArray(int arg1, int arg2)
        {
            Random random = new Random();

            int[,] array = new int[arg1, arg2];

            Console.Write("New array: ");
            for (int row = 0; row < arg1; row++)
            {
                Console.WriteLine();
                for (int column = 0; column < arg2; column++)
                {
                    array[row, column] = random.Next(-10, 10);
                    Console.Write($"|{array[row, column]}|");

                    if (SumPusition(row, column) == true)
                    {
                        Sum += array[row, column];
                    }
                }
            }
            Console.WriteLine();
        }
        static bool SumPusition(int arg1, int arg2)
        {
            bool result = false;
            if ((arg1+ arg2) % 2 == 0)
            {
                result = true;
            }
            return result;
        }
    }
}
