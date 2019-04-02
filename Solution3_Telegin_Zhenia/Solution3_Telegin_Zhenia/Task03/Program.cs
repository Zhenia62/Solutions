using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            DateTime dt = new DateTime(2019, 3, 19, 22, 16, 35);

            Console.WriteLine("Regional settings");
            Console.WriteLine(dt.ToString("dd.mm.yyyy HH:MM",DateTimeFormatInfo.InvariantInfo));
            Console.WriteLine();
            Console.WriteLine("ru-RU");
            Console.WriteLine(dt.ToString("dd.mm.yyyy HH:MM", CultureInfo.CreateSpecificCulture("ru-RU")));
            Console.WriteLine("en-US");
            Console.WriteLine(dt.ToString("dd.mm.yyyy HH:MM", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine("dv-MV");
            Console.WriteLine(dt.ToString("dd.mm.yyyy HH:MM", CultureInfo.CreateSpecificCulture("dv-MV")));
            Console.WriteLine("Please press the key to continue.");
            Console.ReadKey();


            double value = 123.456;
            Console.WriteLine("Regional settings");
            Console.WriteLine($"{value}\n");
            Console.WriteLine("ru-RU");
            Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("ru-RU")));
            Console.WriteLine("en-US");
            Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine("dv-MV");
            Console.WriteLine(value.ToString(CultureInfo.CreateSpecificCulture("dv-MV")));
            Console.WriteLine("Please press the key to continue.");
            Console.ReadKey();

            Console.WriteLine("Regional settings");
            Console.WriteLine(value.ToString("e4 \n"));
            Console.WriteLine("ru-RU");
            Console.WriteLine(value.ToString("e4",CultureInfo.CreateSpecificCulture("ru-RU")));
            Console.WriteLine("en-US");
            Console.WriteLine(value.ToString("e4", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine("dv-MV");
            Console.WriteLine(value.ToString("e4", CultureInfo.CreateSpecificCulture("dv-MV")));
            Console.WriteLine("Please press the key to continue.");
            Console.ReadKey();

            Console.WriteLine("Regional settings");
            Console.WriteLine(value.ToString("p \n"));
            Console.WriteLine("ru-RU");
            Console.WriteLine(value.ToString("p", CultureInfo.CreateSpecificCulture("ru-RU")));
            Console.WriteLine("en-US");
            Console.WriteLine(value.ToString("p", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine("dv-MV");
            Console.WriteLine(value.ToString("p", CultureInfo.CreateSpecificCulture("dv-MV")));
            Console.WriteLine("Please press the key to continue.");
            Console.ReadKey();
        }
    }
}
