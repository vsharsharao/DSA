using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Excercises.Heaps
{
    public class MinHeap
    {
        public List<Node> Values { get; set; }

        public MinHeap()
        {
            Values = new List<Node>();
        }

        public void Insert(Node node)
        {
            Values.Add(node);
            BubbleUp(Values.Count - 1);
        }

        public Node Remove()
        {
            var removedNode = Values[0];
            Values[0] = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);

            BubbleDown(0);

            return removedNode;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < Values.Count;
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < Values.Count;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            bool valid = Values[GetLeftChildIndex(index)].Key > Values[index].Key;

            if (HasRightChild(index))
                return valid && Values[GetRightChildIndex(index)].Key > Values[index].Key;

            return valid;
        }

        private int GetLowerValuedChildIndex(int index)
        {
            if (!HasLeftChild(index) && !HasRightChild(index))
                return index;

            if (!HasRightChild(index))
                return GetLeftChildIndex(index);

            return Values[GetRightChildIndex(index)].Key < Values[GetLeftChildIndex(index)].Key ? GetRightChildIndex(index) : GetLeftChildIndex(index);
        }

        private void BubbleDown(int index)
        {
            if (index >= Values.Count)
                return;

            if (!IsValidParent(index))
            {
                var lowerIndex = GetLowerValuedChildIndex(index);

                if (lowerIndex == index)
                    return;

                if (Values[index].Key > Values[lowerIndex].Key)
                {
                    Swap(Values, index, lowerIndex);
                    BubbleDown(lowerIndex);
                }
            }
        }

        private void BubbleUp(int index)
        {
            var parentIndex = GetParentIndex(index);

            if (parentIndex < 0)
                return;

            if (Values[index].Key < Values[parentIndex].Key)
            {
                Swap(Values, parentIndex, index);
            }

            BubbleUp(parentIndex);
        }

        protected int GetParentIndex(int index)
        {
            return Convert.ToInt32(Math.Ceiling(((double)(index - 2) / 2)));
        }

        private void Swap(List<Node> nodes, int index1, int index2)
        {
            var temp = nodes[index1];
            nodes[index1] = nodes[index2];
            nodes[index2] = temp;
        }
    }

    public class Node
    {
        public Node(int key, string value)
        {
            Key = key;
            Value = value;
        }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}