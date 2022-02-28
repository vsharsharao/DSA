using System.Collections.Generic;

namespace DSA.Excercises.Heaps
{
    public sealed class MaxHeap : Heap
    {
        public MaxHeap() : base()
        {

        }

        public MaxHeap(ICollection<int> values) : base(values)
        {

        }

        public override void Insert(int value)
        {
            Values.Add(value);
            BubbleUp(Values.Count - 1);
        }

        public override int Remove()
        {
            int removedValue = Values[0];
            Values[0] = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);
            BubbleDown(0);

            return removedValue;
        }

        public static Heap Heapify(ICollection<int> collection)
        {
            MaxHeap heap = new MaxHeap(collection);
            int lastParentIndex = heap.Values.Count / 2 - 1;
            for (int i = lastParentIndex; i >= 0; i--)
            {
                heap.BubbleDown(i);
            }

            return heap;
        }

        public override int GetKthLargestElement(int k)
        {
            var newHeap = Clone<MaxHeap>();
            int largest = default;
            while (k-- > 0)
            {
                largest = newHeap.Remove();
            }
            newHeap = null;
            return largest;
        }
    }
}