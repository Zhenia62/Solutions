using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Rectangle
    {
        public int Height;
        public int Width;
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Rectangle rectangle = new Rectangle();

            //ввод и проверка ширины прямоугольника
            Console.WriteLine("Please, enter height");
            rectangle.Height = int.Parse(Console.ReadLine());
            rectangle.Height = Result(rectangle.Height);
           
            //ввод и проверка высоты прямоугольника
            Console.WriteLine("Please, enter Wight");
            rectangle.Width = int.Parse(Console.ReadLine());
            rectangle.Width = Result(rectangle.Width);

            //Вывод
            Output(rectangle.Width, rectangle.Height);
        }

         static int Result(int value)
         {
            Rectangle rectangle = new Rectangle();
            while (value <= 0)
            {
                Console.WriteLine("The side of the rectangle cannot be a negative number or a zero!");
                value = int.Parse(Console.ReadLine());
            }
            return value;
         }

        static void Output(int firsvalue, int secondvalue)
        {
            Console.WriteLine($"Result={firsvalue * secondvalue} cm");
        }
    }
}
