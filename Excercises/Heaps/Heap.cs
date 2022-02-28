using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace DSA.Excercises.Heaps
{
    public abstract class Heap
    {
        public List<int> Values { get; set; }
        public Heap()
        {
            Values = new List<int>();
        }

        public Heap(ICollection<int> values)
        {
            if (values == null || values.Count == 0)
                throw new InvalidOperationException("The Values array is empty");

            Values = values.ToList();
        }

        public bool IsMaxHeap()
        {
            return IsMaxHeap(0);
        }

        private bool IsMaxHeap(int index)
        {
            if (index >= Values.Count)
                return true;

            bool isMaxHeap = IsValidParent(index);

            var leftChildIndex = GetLeftChildIndex(index);
            var rightChildIndex = GetRightChildIndex(index);

            return isMaxHeap && IsMaxHeap(leftChildIndex) && IsMaxHeap(rightChildIndex);
        }

        public abstract void Insert(int value);
        public abstract int Remove();

        public abstract int GetKthLargestElement(int k);

        public T Clone<T>()
        {
            if (this == null)
                return default;

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(this));
        }

        #region protected methods

        protected int GetParentIndex(int index)
        {
            return Convert.ToInt32(Math.Ceiling(((double)(index - 2) / 2)));
        }

        protected int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        protected int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        protected bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            bool valid = Values[GetLeftChildIndex(index)] < Values[index];

            if (HasRightChild(index))
                valid &= Values[GetRightChildIndex(index)] < Values[index];

            return valid;
        }

        protected bool HasLeftChild(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            return leftChildIndex < Values.Count;
        }

        protected bool HasRightChild(int index)
        {
            int rightChildIndex = GetRightChildIndex(index);
            return rightChildIndex < Values.Count;
        }
        protected int GetLargerChildIndex(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);

            if (leftChildIndex >= Values.Count)
                return index;

            if (rightChildIndex >= Values.Count)
                return leftChildIndex;

            return (Values[leftChildIndex] > Values[rightChildIndex]) ? leftChildIndex : rightChildIndex;
        }

        protected void BubbleUp(int current)
        {
            int parentIndex = GetParentIndex(current);
            if (parentIndex < 0)
                return;
            if (Values[current] > Values[parentIndex])
            {
                Swap(Values, current, parentIndex);
                BubbleUp(parentIndex);
            }

            return;
        }

        protected void BubbleDown(int current)
        {
            if (!IsValidParent(current))
            {
                var largerIndex = GetLargerChildIndex(current);
                if (largerIndex == current)
                    return;
                Swap(Values, current, largerIndex);
                BubbleDown(largerIndex);
            }

            return;
        }

        protected void Swap(IList<int> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = Values[index2];
            list[index2] = temp;
        }

        #endregion
    }
}