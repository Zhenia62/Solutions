using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main()
        {
            int[] numeration = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            LinkedList<int> linklist = new LinkedList<int>(numeration);
            linklist = RemoveEachSecondItem(linklist);

            List<int> list = new List<int>(numeration);
            list = RemoveEachSecondItem(list);

        }

        public static LinkedList<T> RemoveEachSecondItem<T>(LinkedList<T> linklist)
        {
            var person = linklist.First;
            while (linklist.Count != 1)
            {
                linklist.Remove(person.Next ?? linklist.First);
                person = person.Next ?? linklist.First;
            }
            return linklist;
        }

        public static List<T> RemoveEachSecondItem<T>(List<T> list)
        {
            var person2 = list.First();
            int i = 1;
            while (list.Count != 1)
            {
                list.RemoveAt(i);
                ++i;

                if (i > list.Count)
                {
                    i = 1;
                }
                else if (i == list.Count)
                {
                    i = 0;
                }
            }
            return list;
        }
    }
}