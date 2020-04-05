using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableExercises
{
    class HashTableExercises
    {
        public int MostFrequent(int[] numbers)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (dictionary.ContainsKey(numbers[i]))
                {
                    int temp;
                    dictionary.TryGetValue(numbers[i], out temp);
                    dictionary[numbers[i]] = temp + 1;
                }
                else
                {
                    dictionary.Add(numbers[i], 1);
                }
            }

            var max = -1;
            var key = numbers[0];

            foreach (var i in dictionary)
            {
                if (i.Value > max)
                {
                    max = i.Value;
                    key = i.Key;
                }
            }

            return key;
        }

        public int CountPairsWithDiff(int[] numbers, int k)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var number in numbers)
            {
                set.Add(number);
            }

            var count = 0;
            foreach (var number in numbers)
            {
                if (set.Contains(number + k))
                    count++;
                if (set.Contains(number - k))
                    count++;
                set.Remove(number);
            }

            return count;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int[] indices = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                int complement = target - numbers[i];
                if (dictionary.ContainsKey(complement))
                {
                    int temp;
                    dictionary.TryGetValue(complement, out temp);
                    return new[] {temp, i};
                }
                dictionary.Add(numbers[i], i);
            }
            
            return null;
        }
    }
}
