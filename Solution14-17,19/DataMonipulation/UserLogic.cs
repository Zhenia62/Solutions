using StorageLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace RewardingBLL
{
    public class UserLogic
    {
        private List<User> users = new List<User>();

        public IEnumerable<User> GetList()
        {
            return users;
        }

        public IEnumerable<User> SortStudentsByFullNameAsc()
        {
            return (from s in GetList()
                    orderby s.FirstName ascending
                    select s);
        }

        public IEnumerable<User> SortStudentsByFullNameDesc()
        {
            return (from s in GetList()
                    orderby s.FirstName descending
                    select s).ToList();
        }
        static public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentException("user can't be null");
            UserDBMonipulation.AddUser(user);
        }

        static public void Remove(User user)
        {
            if (user == null)
                throw new ArgumentException("user can't be null");
            UserDBMonipulation.Remove(user);
        }

        static public void EditUser(User user)
        {
            if (user == null)
                throw new ArgumentException("user can't be null");
            UserDBMonipulation.EditUser(user);
        }

        static public DataSet LoadUsers()
        {
            DataSet dt = UserDBMonipulation.LoadUsers();
            return dt;
        }
        static public List<Award> LoadedUserRewards()
        {
            List<Award> awards = UserDBMonipulation.LoadedUserRewards();
            return awards;
        }
    }
}
