using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Rectangle:Line
    {
        public Rectangle() { }
        public Rectangle(int x, int y, int x2, int y2) :base(x,y,x2,y2)
        {

        }

        public override void Draw()
        {
            Console.Clear();
            Console.WriteLine($"Представьте, что вы видите прямоугольник с началом вершины, имеющей координаты x={X}, y={Y}; c концом в вершине с координатами x={X2}, y={Y2}");
        }
    }
}
