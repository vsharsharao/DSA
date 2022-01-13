using System;

namespace Queues
{
    public class PriorityQueue
    {
        private int[] _array { get; set; }
        public int Count { get; private set; }
        private int _frontIndex { get; set; }
        private int _rearIndex { get; set; }
        public PriorityQueue(int capacity)
        {
            _array = new int[capacity];
        }

        public void EnQueue(int value)
        {
            if (Count >= _array.Length)
                throw new InvalidOperationException("Queue is full");

            if (Count == 0)
                _array[Count++] = value;

            else
            {
                int i;
                for (i = Count - 1; i >= 0; i--)
                {
                    if (_array[i] > value)
                        _array[i + 1] = _array[i];

                    else
                        break;
                }

                Count++;
                _rearIndex = (_rearIndex + 1) % _array.Length;
                _array[i + 1] = value;
            }
        }

        public int DeQueue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            int item = _array[_frontIndex];
            _array[_frontIndex] = 0;
            _frontIndex = (_frontIndex + 1) % _array.Length;
            Count--;
            return item;
        }

        public int Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return _array[_frontIndex];
        }
    }
}