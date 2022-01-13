using System;
using System.Collections.Generic;

namespace LinkedLists
{
    public class LinkedList<T> where T : IComparable<T>
    {
        private Node<T> _first { get; set; }
        private Node<T> _last { get; set; }
        private int _count { get; set; }
        public int Count => _count;
        public void AddFirst(T value)
        {
            var node = new Node<T>(value);
            if (IsEmpty())
                _first = _last = node;

            else
            {
                node.Next = _first;
                _first = node;
            }

            _count++;
        }

        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            if (IsEmpty())
                _first = _last = node;

            else
            {
                _last.Next = node;
                _last = node;
            }

            _count++;
        }

        public int IndexOf(T value)
        {
            int index = 0;
            var current = _first;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The list is empty");

            if (_first == _last)
                _first = _last = null;

            else
                _first = _first.Next;

            _count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The list is empty");

            if (_first == _last)
                _first = _last = null;

            else
            {
                var current = _first;
                var previousNode = GetPreviousNode(_last);
                previousNode.Next = null;
                _last = previousNode;
            }

            _count--;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            var current = _first;
            int i = 0;
            while (current != null)
            {
                array[i++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Reverse()
        {
            #region Elegant solution
            var previous = _first;
            var current = _first.Next;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            _last = _first;
            _last.Next = null;
            _first = previous;
            #endregion

            #region Non elegant solution
            // var arr = ToArray();
            // var current = _first;
            // for (int i = arr.Length - 1; i >= 0; i--)
            // {
            //     current.Value = arr[i];
            //     if (i == 0)
            //     {
            //         current.Next = null;
            //         _last = current;
            //         return;
            //     }
            //     current.Next = new Node<T>(arr[i - 1]);

            //     current = current.Next;
            // }
            #endregion
        }

        public T GetKthFromTheEnd(int position)
        {
            #region Elegant Solution
            if (_first == null)
                throw new InvalidOperationException("Linked list is empty");
            var a = _first;
            var b = _first;

            for (int i = 0; i < position - 1; i++)
            {
                b = b.Next;
                if (b == null)
                    throw new ArgumentException("Position passed is more than the size of the list");
            }

            while (b != _last)
            {
                a = a.Next;
                b = b.Next;
            }
            return a.Value;
            #endregion
            #region Not so elegant solution
            // var current = _first;

            // while (current != null)
            // {
            //     var temp = current.Next;
            //     var span = position - 1;
            //     while (span != 0)
            //     {
            //         if (temp.Next == null)
            //             return current.Value;
            //         temp = temp.Next;
            //         span--;
            //     }
            //     current = current.Next;
            // }

            // return default;
            #endregion
            #region Non elgant solution
            // var current = _first;
            // var pointer = 0;
            // while (current != null)
            // {
            //     if ((Count - pointer) == position)
            //         return current.Value;

            //     current = current.Next;
            //     pointer++;
            // }

            // return default;
            #endregion
        }

        private bool IsEmpty()
        {
            return _first == null;
        }

        private Node<T> GetPreviousNode(Node<T> node)
        {
            var current = _first;
            while (current != null)
            {
                if (current.Next == node)
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }
    }
}