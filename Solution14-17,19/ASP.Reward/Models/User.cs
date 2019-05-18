using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Reward.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }


        public int Age
        {
            get
            {
                int age = 0;
                age = DateTime.Today.Year - Birthdate.Year - 1;
                if (DateTime.Today.Month - Birthdate.Month > 0 || (DateTime.Today.Month - Birthdate.Month == 0 && DateTime.Today.Day - Birthdate.Day >= 0))
                {
                    age++;
                }
                return age;
            }
        }

        public List<Award> Rewards { get; set; }
    }
}