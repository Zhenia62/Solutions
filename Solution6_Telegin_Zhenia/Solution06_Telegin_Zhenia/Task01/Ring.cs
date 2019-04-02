using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Ring:Round
    {
        private static double _dopradius;

        public double DopRadius { get => _dopradius; set => _dopradius = value; }
        public Ring()
        {
        }

        public Ring(int x, int y, double r, double r2, string color) :base(x,y,r,color)
        {
            this.DopRadius = r2;
        }

        public override void Draw(int x, int y, double r, string color)
        {
            Console.Clear();
            Console.WriteLine($"Представьте, что вы видите кольцо с координатами x={x}, y={y}; c радиусами {r} и {DopRadius}, а еще {color} цвета");
        }
    }
}
