using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksIIntro
{
    class StringReverser
    {
        public string Reverse(string input)
        {
            if (input == null)
                throw new ArgumentNullException();

            Stack<char> stack = new Stack<char>();

            foreach (var character in input)
                stack.Push(character);

            StringBuilder reversed = new StringBuilder();

            while (stack.Count != 0)
                reversed.Append(stack.Pop());

            return reversed.ToString();
        }

       
    }
}
