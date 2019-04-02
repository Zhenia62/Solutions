using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c1 = new Counter { value = 20 };
            Counter c2 = new Counter { value = 40 };

            bool result = c1 > c2;
            Counter c3 = c2 + c1;
            Counter c4 = c2 - c1;
            c1++;
            c2--
        }
    }

    class Counter
    {
     public int value { get; set; }

        public static Counter operator +(Counter c1, Counter c2)
        {
            return new Counter { value = c1.value + c2.value };
        }

        public static Counter operator -(Counter c1, Counter c2)
        {
            return new Counter { value = c1.value - c2.value };
        }

        public static bool operator >(Counter c1, Counter c2)
        {
            if (c1.value > c2.value)
                return true;
            else return false;
        }

        public static bool operator <(Counter c1, Counter c2)
        {
            if (c1.value < c2.value)
                return true;
            else return false;
        }

        public static Counter operator ++(Counter c1)
        {
            return new Counter { value = c1.value + 10};
        }

        public static Counter operator --(Counter c2)
        {
            return new Counter { value = c2.value - 10 };
        }
    }
}
