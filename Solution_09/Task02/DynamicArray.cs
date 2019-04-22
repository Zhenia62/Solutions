using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class DynamicArray<T> : IEnumerable, IEnumerator
    {
        protected T[] _array;
        protected int _index = -1;

        public int Index { get; set; }
        public T[] Array { get; set; }


        public DynamicArray(IEnumerable<T> data)
        {
            _array = new T[data.Count()];
            _array = data.ToArray();
            Index = data.Count();
        }

        public IEnumerator GetEnumerator()
        {
         return this;
        }

        public bool MoveNext()
        {
            if (Index == Array.Length - 1)
            {
                Reset();
                return false;
            }
            Index++;
            return true;
        }

        public void Reset()
        {
            Index = -1;
        }
        public object Current
        {
            get
            {
                return Array[Index];
            }
        }
    }
}
