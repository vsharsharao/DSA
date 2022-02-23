using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DSA.Excercises.Heaps
{
    public class Heap
    {
        public List<int> Values { get; set; }
        public Heap()
        {
            Values = new List<int>();
        }

        public Heap(List<int> values)
        {
            if (values == null || values.Count == 0)
                throw new InvalidOperationException("The Values array is empty");

            Values = values;
        }

        public void Insert(int value)
        {
            Values.Add(value);
            BubbleUp(Values.Count - 1);
        }

        public int Remove()
        {
            int removedValue = Values[0];
            Values[0] = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);
            BubbleDown(0);

            return removedValue;
        }

        private int GetParentIndex(int index)
        {
            return Convert.ToInt32(Math.Ceiling(((double)(index - 2) / 2)));
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            bool valid = Values[GetLeftChildIndex(index)] < Values[index];

            if (HasRightChild(index))
                valid &= Values[GetRightChildIndex(index)] < Values[index];

            return valid;
        }

        private bool HasLeftChild(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            return leftChildIndex < Values.Count;
        }

        private bool HasRightChild(int index)
        {
            int rightChildIndex = GetRightChildIndex(index);
            return rightChildIndex < Values.Count;
        }
        private int GetLargerChildIndex(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);

            if (leftChildIndex >= Values.Count)
                return index;

            if (rightChildIndex >= Values.Count)
                return leftChildIndex;

            return (Values[leftChildIndex] > Values[rightChildIndex]) ? leftChildIndex : rightChildIndex;
        }

        private void BubbleUp(int current)
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

        private void BubbleDown(int current)
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

        private void Swap(IList<int> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = Values[index2];
            list[index2] = temp;
        }

        public Heap Clone()
        {
            var serializedString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Heap>(serializedString);
        }
    }
}