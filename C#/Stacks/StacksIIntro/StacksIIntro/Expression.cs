using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksIIntro
{
    class Expression
    {
        private readonly List<char> _rightBrackets = new List<char>(new[] { ')', '}', ']', '>' });
        private readonly List<char> _leftBrackets = new List<char>(new []{'(','{','[','<'});

        public bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                if (IsLeft(ch))
                    stack.Push(ch);

                if (IsRight(ch))
                {
                    if (stack.Count == 0) return false;

                    var top = stack.Pop();
                    if (BracketsMatch(top, ch)) return false;
                }
            }

            if (stack.Count == 0)
                return true;
            return false;
        }

        private bool IsLeft(char ch)
        {
            return _leftBrackets.Contains(ch);
        }
        private bool IsRight(char ch)
        {
            return _rightBrackets.Contains(ch);
        }

        private bool BracketsMatch(char left, char right)
        {
            return _leftBrackets.IndexOf(left) == _rightBrackets.IndexOf(right);
        }
    }
}
