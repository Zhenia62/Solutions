using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Line
    {
        protected static int _x;
        protected static int _y;
        protected static int _x2;
        protected static int _y2;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int X2 { get => _x2; set => _x2 = value; }
        public int Y2 { get => _y2; set => _y2 = value; }

        public Line() { }

        public Line(int x, int y, int x2, int y2)
        {
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
            Draw();
        }

        public virtual void Draw()
        {
            Console.Clear();
            Console.WriteLine($"Представьте, что вы видите линию с началом, имеющим координаты x={X}, y={Y}; c концом в точке с координаты x={X2}, y={Y2}");
        }
    }
}
