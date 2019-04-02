using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task01
{
    class Circle:Round
    {
        public Circle()
        {

        }

        public Circle(int x, int y, double r, string color) : base(x,y,r,color)
        {
        }

        public override void Draw(int x, int y, double r, string color)
        {
            Console.Clear();
            Console.WriteLine($"Представьте, что вы видите круг с координатами x={x}, y={y}; c радиусом {r} и  {color} цвета");
        }
    }
}
