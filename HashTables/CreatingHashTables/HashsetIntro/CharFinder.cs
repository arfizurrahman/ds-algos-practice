using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashsetIntro
{
    class CharFinder
    {
        public char FindTheFirstRepeatedCharacter(string input)
        {
            var array = input.ToCharArray();
            HashSet<char> set = new HashSet<char>(); 
            foreach (var ch in array)
            {
                if (set.Contains(ch))
                    return ch;

                set.Add(ch);
            }

            return char.MinValue;
        }
    }
}
