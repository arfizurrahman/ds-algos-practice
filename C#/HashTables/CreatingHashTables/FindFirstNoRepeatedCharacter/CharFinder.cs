using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFirstNoRepeatedCharacter
{
    class CharFinder
    {
        public char GetFirstNonRepeatingChar(string value)
        {
            var array = value.ToCharArray();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            for (int i = 0; i < value.ToCharArray().Length; i++)
            {
                if (dictionary.ContainsKey(array[i]))
                {
                    int temp;
                    dictionary.TryGetValue(array[i], out temp);
                    temp++;
                    dictionary[array[i]] = temp;
                }
                else
                {
                    dictionary.Add(array[i], 1);
                }
            }

            foreach (var i in dictionary)
            {
                if (i.Value == 1)
                    return i.Key;
            }

           return char.MinValue;
        }
    }
}
