using System;
using System.Collections.Generic;

namespace Queues
{
    public class StackQueue
    {
        private Stack<int> _stack1 { get; set; }
        private Stack<int> _stack2 { get; set; }

        public StackQueue()
        {
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        public void EnQueue(int value)
        {
            _stack1.Push(value);
        }

        public int DeQueue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            MoveStack1ToStack2();
            return _stack2.Pop();
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty");

            MoveStack1ToStack2();
            return _stack2.Peek();
        }

        public bool IsEmpty()
        {
            return _stack1.Count == 0 && _stack2.Count == 0;
        }

        private void MoveStack1ToStack2()
        {
            if (_stack2.Count == 0)
            {
                while (_stack1.Count > 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }
        }
    }
}