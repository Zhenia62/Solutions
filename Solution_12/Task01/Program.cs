using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Task01
{
    class Program
    {
        private static string path = "disposable_task_file.txt";

        static void Main(string[] args)
        {
            var numbers = Reader();

            Record(numbers);

            Console.ReadLine();
        }

        private static void Record(List<int> enumerable)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (int sOutput in enumerable)
                    sw.WriteLine(Math.Pow(sOutput,2));
            }
        }

        static List<int> Reader()
        {
            string sLine = string.Empty;
            List<int> array = new List<int>();

            using (StreamReader objReader = new StreamReader(path))
            {
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != "")
                    {
                        array.Add(int.Parse(sLine));
                    }
                    else return array;
                }
                return array;
            }
        }
    }
}