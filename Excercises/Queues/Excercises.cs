using System.Collections.Generic;

namespace Queues
{
    public static class QueueExcercises
    {
        //O[2n]
        public static Queue<int> Reverse(this Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            return queue;
        }
    }
}