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
            int[] mass = { 12, 5, 6, 7, };
            DynamicArray<int> da = new DynamicArray<int>(mass);

            foreach (var item in da)
            {
                Console.WriteLine(item +"\n");
            }
        }
    }
}
