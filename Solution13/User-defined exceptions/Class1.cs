using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_defined_exceptions
{
    public class LimitExeption : Exception
    {
        public LimitExeption(string message) : base(message)
        {

        }
    }
    public class BalanceExeption : Exception
    {
        public BalanceExeption(string message) : base(message)
        {

        }
    }
}
