using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueWithTwoStacks
{
    class QueueWithTwoStacks
    {
        private Stack<int> stack1 = new Stack<int>();
        private Stack<int> stack2 = new Stack<int>();

        public void Enqueue(int item)
        {
            stack1.Push(item);
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            MoveStack1ToStack2();
            
            return stack2.Pop();
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            MoveStack1ToStack2();
            
            return stack2.Peek();
        }

        private void MoveStack1ToStack2()
        {
            if (stack2.Count == 0)
                while (stack1.Count != 0)
                    stack2.Push(stack1.Pop());
        }

        override 
        public string ToString()
        {
            return string.Join(", ", stack1.ToArray());
        }

        public bool IsEmpty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }
        
    }
}
