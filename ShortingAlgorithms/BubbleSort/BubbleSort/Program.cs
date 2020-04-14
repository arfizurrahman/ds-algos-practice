using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {8, 2, 4, 1, 3};
            var sorter = new BubbleSort();
            sorter.Sort(numbers);

            Console.WriteLine(string.Join(", ", numbers));
            Console.ReadKey();
        }
        
    }
}
