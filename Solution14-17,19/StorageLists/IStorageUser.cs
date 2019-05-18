using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace StorageLists
{
    public interface IStorageUser
    {
        void AddUser(User user);
        void Remove(User user);
        void EditUser(User user);
        DataSet LoadUsers();

    }
}
