using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1, 5, 6, 7, 8};
            Search search = new Search();
            Console.WriteLine(search.BinarySearchIter(numbers, 8));

            Console.ReadKey();
        }
    }
}
