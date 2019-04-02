using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Ring : Round
    {
        private static double _innerRadius;

        public double InnerRadius { get => _innerRadius; set => _innerRadius = value; }

        public Ring() { }

        public Ring(double x, double y, double radus, double inner_radius) :base(x,y,radus)
        {
            InnerRadius = inner_radius;
            PrintAll(x,y,radus,inner_radius);
        }

        public double Area(double r)
        {
            double area = Math.PI * Math.Pow(r, 2);
            return area;
        }

        public double Lenght(double r)
        {
            double lenght = 2 * Math.PI * r;
            return lenght;
        }

        public void PrintAll(double x, double y, double r2, double r1)
        {
            Console.WriteLine();
            Console.WriteLine($"Round and ring have coordinates: x={x} and y={y}");
            Console.WriteLine($"Round radius= {r2}");
            Console.WriteLine("Round lenght= {0:0.##}", Lenght(r2));
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Ring radius (inner radius)= {r1}");
            Console.WriteLine("Ring area= {0:0.##}", Area(r1));
            Console.WriteLine("Ring lenght= {0:0.##}", Lenght(r1));
        }
    }
}
