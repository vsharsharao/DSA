using System;
using System.Linq;

namespace Stacks
{
    public class Stack
    {
        public Stack()
        {
            _array = new int[4];
        }
        private int[] _array { get; set; }
        public int Count { get; private set; }
        public void Push(int value)
        {
            if (Count >= _array.Length)
            {
                var _newArray = new int[Count * 2];
                _array.CopyTo(_newArray, 0);
                _array = _newArray;
            }
            _array[Count++] = value;
        }

        public void Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Pop can't be done on an empty stack");

            _array = _array.Where((ele, i) => i != Count - 1).ToArray();
            Count--;
        }

        public int Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Can't peek an empty stack");

            return _array.Where((ele, i) => i == Count - 1).FirstOrDefault();
        }

        public int[] ToArray()
        {
            if (Count > 0)
                return _array.Where((ele, i) => i < Count).ToArray();

            return null;
        }
    }
}