using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace StorageLists
{
    public interface IAwardStorage
    {
        void Add(Award award);
        void Remove(Award award);
        void EditAward(Award award);
        DataSet LoadAwards();
    }
}
