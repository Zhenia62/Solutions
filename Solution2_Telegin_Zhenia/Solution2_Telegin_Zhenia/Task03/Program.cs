using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
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
            int count = int.Parse(Console.ReadLine());

            while (count < 0)
            {
                Console.WriteLine("Count can't be negative");
                Console.Write("Please, enter the new count: ");
                count = int.Parse(Console.ReadLine());
            }
            int[] array = new int[count];
            BasicArray(array);
            Console.WriteLine($"Sum of negative elements = {Sum}");

            Console.ReadKey();
        }

        static void BasicArray(int[] arg)// Генерация нового массива
        {
            Console.Write("New array:  ");
            Random random = new Random();
            for(int i = 0; i< arg.Length; i++)
            {
                arg[i] = random.Next(-10, 20);
                Console.Write($"|{arg[i]}|");
                SumNegElem(arg[i]);
            }
            Console.WriteLine();
        }
        static void SumNegElem(int arg)//Сумма отрицательных элементов
        {
            if (arg >= 0)
            {
                Sum += arg;
            }
        }
    }
}
