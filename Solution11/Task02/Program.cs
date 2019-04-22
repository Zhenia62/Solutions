using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            for (int i = -10; i <= 10; i++)
            {
                for (int j = -10; j <= 10; j++)
                {
                    TwoDPoint point = new TwoDPoint(i, j);
                    list.Add(point.GetHashCode());

                }

            }
            Count(list);
            Console.ReadKey();
        }

        public static void Count(List<int> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                int elem = 0;
                for (int i = 0; i < list.Count; i++)
                {

                    if (list.Equals(item))
                    {
                        elem++;
                        if (elem == 2)
                        {
                            break;
                        }
                    }
                }
                count++;
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }

    }
}
