using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { };
            var sorter = new InsertionSort();
            sorter.Sort(numbers);

            Console.WriteLine(string.Join(", ", numbers));
            Console.ReadKey();
        }
    }
}
