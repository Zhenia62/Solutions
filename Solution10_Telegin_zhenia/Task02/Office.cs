using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Office : HashSet<Person>
    {
        private static List<Person> _workers;

        public static List<Person> Workers { get => _workers; set => _workers = value; }
        public static List<Person> OnWork { get; set; }

        public Office(List<Person> people)
        {
            _workers = people;
        }

        public Office()
        {
        }

    }
}
