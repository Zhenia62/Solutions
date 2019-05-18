using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{

    public class Award
    {
        private int _id = 0;
        private string _title;
        private string _description;

        public static void Main()
        {
        }

        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public int ID { get => _id; set => _id = value; }

        public Award(string title, string description)

        {
            _id++;
            Title = title;
            Description = description;
        }
        public Award(int id, string title, string description)

        {
            ID = id;
            Title = title;
            Description = description;
        }

        Dictionary<string, string> ErrorCollection = new Dictionary<string, string>();

        public string Error => throw new NotImplementedException();
        public string this[string name]
        {
            get
            {
                string error = string.Empty;
                switch (name)
                {
                    case "Title":
                        if (string.IsNullOrEmpty(Title))
                            error = "Введите название";
                        break;
                    case "Description":
                        if (string.IsNullOrEmpty(Description))
                            error = "Введите описание";
                        if (Description.Length > 150)
                            error = "Слишком длинное описание";
                      
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
