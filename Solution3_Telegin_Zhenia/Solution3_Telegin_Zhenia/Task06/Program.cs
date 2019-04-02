using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please, enter the number");
            var str = Console.ReadLine();
            var numb = Check(str);

            Console.Clear();
            Console.WriteLine($"Вы ввели: {str} \n{numb}");
            Console.ReadKey();
        }

        static string Check(string str)
        {
            Regex regex = new Regex(@"[^e^0-9\s+\s-]");
            Regex regex2 = new Regex("[e^]");
            string strdop;

            if ((str != null) && (!regex.Match(str).Success))
            {
                if (regex2.Match(str).Success)
                {
                    strdop = "Это число в научной нотации";
                }else strdop = "Это число в обычной нотации";
                
            }
            else strdop = "Не число";

            return strdop;
        }
    }
}
