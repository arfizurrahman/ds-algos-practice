
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingTwoQueues
{
    class StackWithTwoQueues
    {
        private Queue<int> queue1 = new Queue<int>();
        private Queue<int> queue2 = new Queue<int>();
        private int top;

        public void Push(int value)
        {
            queue1.Enqueue(value);
            top = value;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            while (queue1.Count > 1)
            {
                top = queue1.Dequeue();
                queue2.Enqueue(top);
            }
            
            SwapQueues();
            
            return queue2.Dequeue();
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return top;
        }

        public int Count()
        {
            return queue1.Count;
        }

        private void SwapQueues()
        {
            var temp = queue1;
            queue1 = queue2;
            queue2 = temp;
        }

        public bool IsEmpty()
        {
            return queue1.Count == 0;
        }
    }
}
