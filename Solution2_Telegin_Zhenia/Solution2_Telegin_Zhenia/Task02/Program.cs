using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Dimension
    {
        public int FirstDim;
        public int SecondDim;
        public int ThirdDim;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Input();

            Console.ReadKey();
        }

        static void Input()//Ввод данных
        {
            Dimension dim = new Dimension();

            Console.WriteLine("Please, enter the count elements to array");

            Console.Write("First dimension: ");
            dim.FirstDim = int.Parse(Console.ReadLine());
            dim.FirstDim = Check(dim.FirstDim);

            Console.Write("Second dimension: ");
            dim.SecondDim = int.Parse(Console.ReadLine());
            dim.SecondDim = Check(dim.SecondDim);

            Console.Write("Third dimension: ");
            dim.ThirdDim = int.Parse(Console.ReadLine());
            dim.ThirdDim = Check(dim.ThirdDim);

            Console.WriteLine("\n");
            OutputBasicArray(dim.FirstDim, dim.SecondDim, dim.ThirdDim);
        }
        static int Check(int value)//проверка вводимых чисел
        {
            while (value <= 0)
            {
                Console.WriteLine("Dimension can't be negative and equals to zero");
                Console.Write("Please, enter the new count: ");
                value = int.Parse(Console.ReadLine());
            }

            return value;
        }


        static void OutputBasicArray(int arg, int arg2, int arg3)//Вывод базового массива
        {
            int number = 1;
            Dimension dim = new Dimension();

            int[,,] array = new int[arg, arg2, arg3];
            Random random = new Random();

            Console.WriteLine("Basic array \n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine($"Array №{number++}");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = random.Next(-20, 20);
                        Console.Write("|" + array[i, j, k]+ "|");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

            Replacement(array);
        }

        

        static void Replacement(int[,,] arg)//Поиск и изменение отрицательных элементов
        {
            for (int i = 0; i < arg.GetLength(0); i++)
            {
                for (int j = 0; j < arg.GetLength(1); j++)
                {
                    for (int k = 0; k < arg.GetLength(2); k++)
                    {
                        if (arg[i, j, k] > 0 )
                        {
                            arg[i, j, k] = 0;
                        }
                    }
                    Console.WriteLine();
                }
            }
            OutputNewArray(arg);
        }

        static void OutputNewArray(int[,,] arg)//Вывод измененного массива
        {
            int number = 1;

            Console.WriteLine("New array");
            for (int i = 0; i < arg.GetLength(0); i++)
            {
                Console.WriteLine($"Array №{number++}");
                for (int j = 0; j < arg.GetLength(1); j++)
                {
                    for (int k = 0; k < arg.GetLength(2); k++)
                    {
                        Console.Write("|" + arg[i, j, k] + "|");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
