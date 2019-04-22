using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] mass = { "Hello, my name is Zhenia", "bbbbbbbb", "My aples", "I drink water", "Everyday", "This is a famous actor", "aaaaaaaa" };

            var array1 = Sort(mass, AscendingOrder);
            var array2 = Sort(mass, DescendingOrder);
        }

        public static bool AscendingOrder(int firstWord, int secondWord)
        {
            return firstWord > secondWord;
        }

        public static bool DescendingOrder(int firstWord, int secondWord)
        {
            return firstWord < secondWord;
        }

        public delegate bool CompareDelegate(int a, int b);

        private static string[] Sort(string[] array, CompareDelegate comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length - 1; j++)
                {
                    if (comparer(array[j].Length, array[j + 1].Length))
                    {
                        string str = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = str;
                    }
                    else
                    {
                        if (array[j].Length == array[j + 1].Length)
                        {
                            Array.Sort(array, j, 2);
                        }
                    }
                }
            }

            return array;
        }
    }
}
