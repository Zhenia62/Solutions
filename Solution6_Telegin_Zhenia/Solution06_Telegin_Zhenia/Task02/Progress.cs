using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Progress : ISeries
    {
        protected int start;
        protected int step;

        public Progress()
        {
            start = 2;
            step = 2;
        }

        public int GetNext()
        {
            step *= 2;
            return step;
        }

        public void SetStart(int x)
        {
            start = x;
            step = start;
        }
    }
}
