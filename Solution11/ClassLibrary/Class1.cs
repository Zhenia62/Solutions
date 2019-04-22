using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Factorial
    {
        public static long GetFactorial(int N)
        {
            long factotial = 1;
            if (N != 0)
            {
                for (int i = 2; i <= N; i++)
                {
                    factotial *= i;
                }
            }
            return factotial;
        }
    }

    public class Power
    {
        public static double GetPower(double fNum, int pow)
        {
            double result = Math.Pow(fNum, pow);
            return result;
        }
    }
}
