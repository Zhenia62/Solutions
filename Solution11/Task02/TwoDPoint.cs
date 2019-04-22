using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class TwoDPoint
    {
        public readonly int x, y;

        public TwoDPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TwoDPoint p = obj as TwoDPoint;
            if (p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public bool Equals(TwoDPoint p)
        {
            if (p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public virtual int HashCode(int x, int y)
        { 
           return x ^ y; 
        }
    }
}
