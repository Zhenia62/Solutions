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
    public class AwardLogic
    {
        private List<Award> awards = new List<Award>();

        public IEnumerable<Award> GetList()
        {
            return awards;
        }

        public IEnumerable<Award> SortStudentsByFullNameAsc()
        {
            return (from s in GetList()
                    orderby s.Title ascending
                    select s);
        }

        public IEnumerable<Award> SortStudentsByFullNameDesc()
        {
            return (from s in GetList()
                    orderby s.Title descending
                    select s).ToList();
        }

        static public void Add(Award award)
        {
            if (award == null)
                throw new ArgumentException("award can't be null");
            AwardDBMonipulation.Add(award);
        }

        static public void Remove(Award award)
        {
            if (award == null)
                throw new ArgumentException("award can't be null");
            AwardDBMonipulation.Remove(award);

        }

        static public void EditAward(Award award)
        {
            if (award == null)
                throw new ArgumentException("award can't be null");
            AwardDBMonipulation.EditAward(award);
        }

        static public DataSet LoadAwards()
        {
          DataSet dt =  AwardDBMonipulation.LoadAwards();
          return dt;

        }
    }
}
