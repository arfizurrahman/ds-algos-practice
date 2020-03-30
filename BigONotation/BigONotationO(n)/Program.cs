using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigONotationO_n_
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void log(int[] numbers, string[] names)
        {
            //O(1 + n + 1) = O (2 + n) = O(n)
            //Console.WriteLine(); // O(1)
            //for (int i = 0; i < numbers.Length; i++) // O(n)
            //{
            //    Console.WriteLine(numbers[i]);
            //}
            //Console.WriteLine(); // O(1)

            ////--O(n + n) = O(2n) = O(n)--//
            //for (int i = 0; i < numbers.Length; i++) // O(n)
            //{
            //    Console.WriteLine(numbers[i]);
            //}
            //for (int i = 0; i < numbers.Length; i++) // O(n)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //--O(n + m) = O(n)--//Because the run time increases linearly
            foreach (int number in numbers)// O(n)
            {
                Console.WriteLine(number);
            }

            foreach (string name in names)// O(m)
            {
                Console.WriteLine(name);
            }
            
        }
    }
}
