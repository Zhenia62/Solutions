using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Round
    {
        public static int _x;
        public static int _radius;
        public static int _lenght;
        public static double _area;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public int Lenght
        {
            get
            {
                return _lenght;
            }
            set
            {
                _lenght = (value * 2) * value;
            }
        }

        public double Area
        {
            get
            {
                return _area;
            }
            set
            {
                _area = 2 * Math.PI * value * value;
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("Area= " + _area);
            Console.WriteLine("Lenght= " + _lenght);
        }  

    }

    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round();

            Console.WindowHeight = 70;
            Console.WindowWidth = 110;

            Console.WriteLine("Введите коордиату х");
            var str = Console.ReadLine();
            round.X = Check(str);

            Console.WriteLine("Введите радиус");
            var str2 = Console.ReadLine();
            round.Radius = Check(str);

            round.Area = round.Radius;
            round.Lenght = round.Radius;
        
            round.PrintAll();
            Console.ReadKey();
        }


        static int Check(string str)
        {
            int number;
            bool success = int.TryParse(str, out number);
            while ((string.IsNullOrEmpty(str)) ||(success == false))
            {
                Console.WriteLine("Incorrect input!");
                str = Console.ReadLine();
            }
            return int.Parse(str);
        }
    }
}
