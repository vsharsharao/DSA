using System;

namespace Queues
{
    public class ArrayQueue
    {

        private int[] _array { get; set; }
        private int _frontIndex { get; set; } = 0;
        private int _rearIndex { get; set; } = 0;
        private int Count { get; set; }

        public ArrayQueue(int capacity)
        {
            _array = new int[capacity];
        }

        public void EnQueue(int value)
        {
            if (Count >= _array.Length)
                throw new InvalidOperationException("Queue is full");

            Count++;
            _array[_rearIndex] = value;
            _rearIndex = (_rearIndex + 1) % _array.Length;
        }

        public int DeQueue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            Count--;
            var item = _array[_frontIndex];
            _array[_frontIndex] = 0;
            _frontIndex = (_frontIndex + 1) % _array.Length;
            return item;
        }

        public int Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return _array[_frontIndex];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool IsFull()
        {
            return Count == _array.Length;
        }
    }
}