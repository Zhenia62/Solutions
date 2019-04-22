using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02;

namespace Task01
{
    class Task02
    {
        private static bool flagForWrite = true;
        private static string pathToCatalog;

        static void Main()
        {
            if (flagForWrite)
            {
                flagForWrite = false;
                Console.WriteLine("Введите путь к каталогу: ");
                pathToCatalog = Console.ReadLine();
                ToSearch(pathToCatalog);
            }

            Сatalogue сatalogue = new Сatalogue(pathToCatalog);

        }
        private static void ToSearch(string pathToCatalog)
        {
            if (!Directory.Exists(pathToCatalog))
            {
                Console.WriteLine("Данного каталога не существует, хотите ввести путь еще раз? y/n");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    flagForWrite = true;
                    Main();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
