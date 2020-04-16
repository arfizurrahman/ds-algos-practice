using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringManipulationAlgorithms
{
    class StringUtils
    {
        public static int CountVowels(string str)
        {
            if (str == null)
                return 0;
            //HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            var vowels = "aeiou";
            var count = 0;
            foreach (var ch in str.ToLower().ToCharArray())
                if (vowels.Contains(ch))
                    count++;

            return count;
        }

        public static string Reverse(string str)
        {
            if (str == null)
                return "";
            StringBuilder builder = new StringBuilder();
            var array = str.ToCharArray();
            for (int i = array.Length - 1; i >= 0; i--)
                builder.Append(array[i]);

            return builder.ToString();
        }

        //public static string Reverse(string str)
        //{
        //    Stack<char> characters = new Stack<char>();
        //    foreach (var ch in str.ToCharArray())
        //        characters.Push(ch);

        //    StringBuilder builder = new StringBuilder();
        //    while (characters.Count != 0)
        //        builder.Append(characters.Pop());

        //    return builder.ToString();
        //} 

        public static string ReverseWords(string sentence)
        {
            if (sentence == null)
                return "";
            var words = sentence.Trim().Split(' ');
            Array.Reverse(words);
            return string.Join(" ", words);

            //StringBuilder builder = new StringBuilder();
            //for (int i = words.Length - 1; i >= 0; i--)
            //    builder.Append(words[i] + "");

            //return builder.ToString().Trim();
        }

        public static bool AreRotations(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;

            return (str1.Length == str2.Length) &&
                   ((str1 + str1).Contains(str2));
        }

        public static string RemoveDuplicates(string str)
        {
            if (str == null)
                return "";

            StringBuilder output = new StringBuilder();
            HashSet<char> seen = new HashSet<char>();

            foreach (var ch in str.ToCharArray()) { 
                if (!seen.Contains(ch))
                {
                    seen.Add(ch);
                    output.Append(ch);
                }
            }
            return output.ToString();
        }

        public static char GetMaxOcurringChar(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new InvalidOperationException();

            const int ASCII_SIZE = 256;

            int[] frequencies = new int[ASCII_SIZE];
            foreach (var ch in str.ToCharArray())
                frequencies[ch]++;
            int max = 0;
            char result = ' ';

            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] > max)
                {
                    max = frequencies[i];
                    result = (char) i;
                }
            }

            return result;
            //Dictionary<char, int> dictionary = new Dictionary<char, int>();
            //int count = 0;
            //char repeatedChar = ' ';
            //foreach (var ch in str.ToCharArray())
            //{
            //    if (dictionary.ContainsKey(ch))
            //        dictionary[ch]++;
            //    else
            //        dictionary.Add(ch, 1);

            //    if (count < dictionary[ch])
            //    {
            //        count = dictionary[ch];
            //        repeatedChar = ch;
            //    }
            //}


            //return repeatedChar;
        }

        public static string CapitalizeString(string str)
        {
            if (string.IsNullOrEmpty(str.Trim()))
                return "";

            str = Regex.Replace(str, " +", " ");
            string[] words = str.Trim().Split( ' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
            }

            return string.Join(" ", words);
        }

        // O (n log n)
        public static bool AreAnagrams(string str1, string str2)
        {
            if (str1 == null || str2 == null || str1.Length != str2.Length)
                return false;
            
            var array1 = str1.ToLower().ToCharArray(); // O(n)
            Array.Sort(array1); // O (n log n)

            var array2 = str2.ToLower().ToCharArray();
            Array.Sort(array2);

            //for (int i = 0; i < array1.Length; i++)
            //{
            //    if (array1[i] != array2[i])
            //        return false;
            //}

            return Enumerable.SequenceEqual(array1, array2);
        }
        // O(n)
        public static bool AreAnagram2(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                return false;

            const int ENGLISH_ALPHABET = 26; 
            int[] frequencies = new int[ENGLISH_ALPHABET];

            str1 = str1.ToLower();
            for (int i = 0; i < str1.Length; i++)
                frequencies[str1[i] - 'a']++;

            str2 = str2.ToLower();
            for (int i = 0; i < str2.Length; i++)
            {
                var index = str2[i] - 'a';
                if (frequencies[index] == 0)
                    return false;
                frequencies[index]--;
            }

            return true;
        }

        public static bool IsPalindrome(string word)
        {
            if (word == null)
                return false;
            //var array = word.ToCharArray();
            //for (int i = 0; i < array.Length / 2; i++)
            //    if (array[i] != array[array.Length - 1 - i])
            //        return false;

            int left = 0;
            int right = word.Length - 1;
            var array = word.ToCharArray();
            while (left < right)
            {
                if (array[left++] != array[right--])
                    return false;
            }
            return true;
        }
    }
}
