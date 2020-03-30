using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceComplexity
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void greet(string[] names)
        {
            // O(n)
            string[] copy = new string[names.Length];
            for (int i = 0; i < names.Length; i++) // O(n)
            {
                Console.WriteLine("Hi" + names[i]);
            }

        }
    }
}
