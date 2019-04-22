using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        public delegate string[] MyDelegate(string[] str);
        static void Main(string[] args)
        {
            string[] mass = { "Hello, my name is Zhenia", "bbbbbbbb", "My aples", "I drink water", "Everyday", "This is a famous actor", "aaaaaaaa" };
            MyDelegate myDelegate = Sort;

            Thread mythread = new Thread(Sort2);
            mythread.Start();
            //Thread.Sleep(0);
            mass = myDelegate(mass);
        }

        private static string[] Sort(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length - 1; j++)
                {
                    if (array[j].Length < array[j + 1].Length)
                    {
                        string str = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = str;
                    }
                    else if (array[j].Length == array[j + 1].Length)
                    {
                        Array.Sort(array, j, 2);
                    }
                }
            }
            Console.ReadKey();
            return array;

        }
        public static void Sort2()
        {
            string[] array = { "already", "different", "green", "cat", "excellent", "holiday" };
            Array.Sort(array);
            string[] mass2 = array;
            Console.WriteLine("The end!");
        }
    }
}
