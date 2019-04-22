using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Advertisers study how people learn so that they can teach them to respond to their advertising." +
                 "They want us to be interested,to try something, and then to do it again.These are the elements of learning:interest,experience and repetition. " +
                 "If an advert can achieve this,it is successful. If an advert works well,the same technique can be used to advertise different things. " +
                 "So,for example,in winter if the weather is cold and you see a family having a warming cup of tea and feeling cosy,you may be interested and note the name of the tea" +
                 "Here the same technique is being used as with the cool,refreshing drink.";

            Count(text);
            Console.ReadKey();
        }

        public static void  Count(string text)
        {
            string[] words = Regex.Split(text, "\\W");
            Regex regex = new Regex("\\w++");

            var frequencyList = regex.Matches(text)
                .Cast<Match>()
                .Select(c => c.Value.ToLowerInvariant())
                .Where(c => words.Contains(c))
                .GroupBy(c => c)
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Word);

            Dictionary<string, int> dict = frequencyList.ToDictionary(d => d.Word, d => d.Count);
            Output(dict);
        }

        public static void Output(Dictionary<string, int> dict)
        {
            foreach (var item in dict.OrderBy(v => v.Value).Reverse())
            {
                Console.WriteLine(($"{item.Key}|{item.Value}"));
            }
        }
    }
}
