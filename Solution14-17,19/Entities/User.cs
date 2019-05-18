using Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class User
    {
        private int _id;
        private string _firstName;  // <50 simbols
        private string _lastName;// <50 simbols
        private  int _age;
        private DateTime _birthDate; // now<x<150  .... Age()
       

        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public int Age { get => _age; set => _age = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }


        public List<Award> AwardList = new List<Award>();


        Dictionary<string, string> ErrorCollection = new Dictionary<string, string>();


        public User(string firstName, string lastName, DateTime birthDate, int age, string awardList)
        {
            _age = age;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;


        }
        public User(int id, string firstName, string lastName, DateTime birthDate, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public static int CheckAge(DateTime date)
        {

            int age = 0;
            age = DateTime.Today.Year - date.Year - 1;
            if (DateTime.Today.Month - date.Month > 0 || (DateTime.Today.Month - date.Month == 0 && DateTime.Today.Day - date.Day >= 0))
            {
                age++;
            }
            return age;

        }


        public string Error => throw new NotImplementedException();
        public string this[string name]
        {
            get
            {
                string error = string.Empty;
                switch (name)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName))
                            error = "Введите имя";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                            error = "Введите фамилию";
                        break;
                    case "BirthDate":
                        if (string.IsNullOrEmpty(BirthDate.ToString()))
                            error = "Введите дату рождения";
                        else if ((BirthDate.Year - DateTime.Now.Year < 10) || (BirthDate.Year - DateTime.Now.Year > 100))
                            error = "Количество лет не может быть меньше 10 и больше 100";
                        break;
                }
                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = error;
                else if (error != null)
                    ErrorCollection.Add(name, error);

                //OnPropertyChanged("ErrorCollection");
                return error;
            }
        }

    }
}
