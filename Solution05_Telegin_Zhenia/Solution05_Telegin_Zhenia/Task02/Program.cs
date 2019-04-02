using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
       static Round round = new Round();
       static Ring ring = new Ring();

        static int flag = 0;
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("Please, enter a coordinate х: ");
            var str = Console.ReadLine();
            round.X= CheckDot(str);

            Console.Write("Please, enter a coordinate y: ");
            str = Console.ReadLine();
            round.Y = CheckDot(str);

            Console.Write("Please enter a radius: ");
            str = Console.ReadLine();
            round.R = CheckRadus(str);

            flag++;
            Console.Write("Please enter a inner radius: ");
            str = Console.ReadLine();
            ring.InnerRadius = CheckRadus(str);

            ring = new Ring(round.X, round.Y, round.R, ring.InnerRadius);
            Console.ReadKey();
        }

        static double CheckDot(string str)
        {
            bool success = double.TryParse(str, out double number);
            while ((string.IsNullOrEmpty(str)) || (success == false) || ((double.Parse(str) < round.R) && flag == 1))
            {
                Console.WriteLine("Incorrect input!");
                str = Console.ReadLine();
            }
            return double.Parse(str);
        }

        static double CheckRadus(string str)
        {
            bool success = double.TryParse(str, out double number);
            while ((string.IsNullOrEmpty(str)) || (success == false) || (double.Parse(str)<=0) || ((double.Parse(str) > round.R) && flag == 1))
            {
                Console.WriteLine("Incorrect input!");
                str = Console.ReadLine();
            }
            return double.Parse(str);
        }
    }
}
