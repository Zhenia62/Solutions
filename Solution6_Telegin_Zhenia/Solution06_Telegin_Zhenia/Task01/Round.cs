using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Round
    {
        protected static int _x;
        protected static int _y;
        protected static double _radius;
        protected static string _color;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public double R { get => _radius; set => _radius = value; }
        public string Color { get => _color; set => _color = value; }

        public Round() { }

        public Round(int x, int y, double r, string color)
        {
            X = x;
            Y = y;
            R = r;
            Color = color;

            Draw(x,y,r,color);
        }

        public virtual void Draw(int x, int y, double r, string color)
        {
            Console.Clear();
            Console.WriteLine($"Представьте, что вы видите окружность с координатами x={x}, y={y}; c радиусом {r} и с цветом контура {color}");
        }
    }
}
