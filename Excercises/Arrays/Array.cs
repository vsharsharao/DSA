using System;

namespace Array
{
    public class Array
    {
        private int[] _array;
        public int Count { get; private set; }
        public Array(int length)
        {
            _array = new int[length];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i] == item)
                    return i;
            }

            return -1;
        }

        public void Insert(int item)
        {
            if (Count == _array.Length)
            {
                int[] newArray = new int[Count * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _array[i];
                }
                _array = newArray;
            }
            _array[Count++] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < Count; i++)
            {
                _array[i] = _array[i + 1];
            }
            Count--;
        }

        //O[n]
        public int Max()
        {
            if (_array?.Length > 0)
            {
                int max = _array[0];
                for (int i = 1; i < _array.Length; i++)
                {
                    max = _array[i] > max ? _array[i] : max;
                }

                return max;
            }

            throw new InvalidOperationException("Array is empty");
        }

        public void Intersect(int[] array)
        {
            if (_array?.Length > 0 && array.Length > 0)
            {

            }

            throw new InvalidOperationException("Array is empty");
        }

        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(_array[i]);
            }
        }
    }
}