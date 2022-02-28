using System;

namespace DSA.Excercises.Heaps
{
    public class PriorityQueue
    {
        private MinHeap _heap { get; set; }
        public int Size => _heap.Values.Count;
        public PriorityQueue()
        {
            _heap = new MinHeap();
        }
        public void EnQueue(int priority, string value)
        {
            if (priority == default || string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid arguments passed");

            var node = new Node(priority, value);

            _heap.Insert(node);
        }

        public string DeQueue()
        {
            if (_heap.Values.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            var node = _heap.Remove();
            return node.Value;
        }
    }
}