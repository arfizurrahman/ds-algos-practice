using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFromScratchUsingArray
{
    class MinStack2
    {
        private Stack<int> stack = new Stack<int>();
        private Stack<int> minStack = new Stack<int>();

        public void Push(int item)
        {
            stack.Push(item);

            if (minStack.Count == 0)
                minStack.Push(item);
            else if (item < minStack.Peek())
                minStack.Push(item);

        }

        public int Pop()
        {
            if (stack.Count == 0)
             throw new InvalidOperationException();

            var top = stack.Pop();
            if (top == minStack.Peek())
                minStack.Pop();

            return top;
        }

        public int Min()
        {
            return minStack.Peek();
        }
    }
}
