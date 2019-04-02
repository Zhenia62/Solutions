using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class DynamicArray<T>
    {
        protected T[] array;
        protected int _count;
        protected int _capacity;
      
        public T[] Arr
        { 
            get
            {
                return array;
            } 
            set 
            {
                array = value; 
            }
        }

        //Количество элементов 
        public int Count
        {
            get
            {
                foreach (var item in Arr)
                {
                    if (item != null)
                    {
                        _count++;
                    }
                }
                return _count;
            }
            private set
            {
                _count = value;
            }
        }

        //Получинеи длины массива
        public int Capacity { get => _capacity = Arr.Length; set => _capacity = value; }

        //Индексатор
        public T this[int i] { get => Arr[i]; set => Arr[i] = value;}


        //3
        public DynamicArray(params T[] array)
        {
            Arr = array;
        }

        //1
        public DynamicArray()
        {
            Arr = new T[8];
        }

        //2
        public DynamicArray(int lenght)
        {
            Arr = new T[lenght];
        }

        //4
        public void Add(T element)
        {
            Resize(Count, Arr.Length);
            Arr[Count] = element;
            Count++;
        }

        //5
        public void AddRange(params T[] array)
        {
            if (Arr.Length < array.Length)
            {
                int lenght = FixedMoreSize(Arr.Length, array.Length);
                Arr = new T[lenght];
                foreach (var item in array)
                {
                    Arr[Count] = item;
                    Count++;
                }
            }
        }

        // 6
        public bool Remove(T item)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            int startIndex = index + 1;
            if (startIndex < Count)
            {
                Array.Copy(Arr, startIndex, Arr, index, Count - startIndex);
            }
            Count--;
        }

        //7
        public void Insert(int index, T item)
        {
            if (index >= Arr.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Arr.Length == Count)
            {
                this.MoreArray();
            }
            Array.Copy(Arr, index, Arr, index + 1, Count - index);
            Arr[index] = item;
            Count++;
        }

        //расширение массива
        private void MoreArray()
        {
            int newLength = Arr.Length == 0 ? (Arr.Length * 3) / 2 + 1 : Arr.Length << 1;

            T[] newArray = new T[newLength];

            Arr.CopyTo(newArray, 0);

            Arr = newArray;
        }

        //*2
        public void Resize(int count, int lenght)
        {
            if (lenght <= count)
            {
                while (lenght <= count)
                {
                    lenght = MoreSize(lenght);
                }

                T[] temp = new T[lenght];

                for (int i = 0; i < Arr.Length; i++)
                {
                    temp[i] = Arr[i];
                }

                Arr = temp;
            }
        }

        //Удвоение массива
        private int MoreSize(int lenght)
        {
            if (lenght == 0)
            {
                lenght = 8;
            }
            else lenght *= 2;

            return lenght;
        }

        //Расширение массива
        private int FixedMoreSize(int lenghtStart, int lenghtStop)
        {
            int lenght_fin = lenghtStart + lenghtStop + 8;
            return lenght_fin;
        }
    }
}
