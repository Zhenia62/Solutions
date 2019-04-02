using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Round
    {
        protected static double _x;
        protected static double _y;
        protected static double _radius;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double R { get => _radius; set => _radius = value; }


        public Round() { }

        public Round(double x, double y, double radius)
        {
            X = x;
            Y = y;
            R = radius;
        }
    }
}
