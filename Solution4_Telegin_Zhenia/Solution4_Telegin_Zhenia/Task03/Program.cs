using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Triangle
    {
        static int _firsside;
        static int _seconsside;
        static int _thirdside;
        static int _perimeter;
        static double _area;

        public int Firsside
        {
            get
            {
                return _firsside;
            }
            set
            {
                _firsside = value;
            }
        }
        public int Seconsside
        {
            get
            {
                return _seconsside;
            }
            set
            {
                _seconsside = value;
            }
        }
        public int Thirdside
        {
            get
            {
                return _thirdside;
            }
            set
            {
                _thirdside = value;
            }
        }

        public int Perimeter()
        {
            if (CheckSides() == true)
            {
                _perimeter = _firsside + _seconsside + _thirdside;
                return _perimeter;
            }
            else return 0;
        }
        public double Area()
        {
            if (CheckSides() == true)
            {
                double h = ((2 * Math.Sqrt(_perimeter * (_perimeter - _firsside) * (_perimeter - _seconsside) * (_perimeter - _thirdside)) / _seconsside));
                _area = (double)(1 / 2 * h * _seconsside);
                return _area;
            }
            else return 0;

        }
        public bool CheckSides()
        {
            if (_firsside > (_seconsside + _thirdside) || (_seconsside > (_firsside + _thirdside)))
            {
                return false;
            }
            else return true;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();

            Console.Write("Enter the firs side: ");
            triangle.Firsside = int.Parse(Console.ReadLine());
            triangle.Firsside = CheckString(triangle.Firsside);

            Console.Write("Enter the secons side: ");
            triangle.Seconsside = int.Parse(Console.ReadLine());
            triangle.Seconsside = CheckString(triangle.Seconsside);

            Console.Write("Enter the third side: ");
            triangle.Thirdside = int.Parse(Console.ReadLine());
            triangle.Thirdside = CheckString(triangle.Thirdside);

            Console.WriteLine(triangle.Perimeter());
            Console.WriteLine(triangle.Area());

            Console.ReadKey();
        }

        static int CheckString(int side)
        {
            if (side <= 0)
            {
                Console.WriteLine("Invalid input! Please, repeat input!");
                side = int.Parse(Console.ReadLine());
            }
            return side;
        }
    }
}
