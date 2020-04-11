using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 3, 10, 1, 4, 2 };

            var heap = new Heap();
            foreach (var number in numbers)
                heap.Insert(number);

            for (int i = numbers.Length - 1; i >= 0; i--)
                numbers[i] = heap.Remove();

            //Console.WriteLine(string.Join(", ", numbers));
            //Heap heap = new Heap();
            //heap.Insert(10);
            //heap.Insert(5);
            //heap.Insert(17);
            //heap.Insert(4);
            //heap.Insert(22);

            //Console.WriteLine(heap.Remove());

            //int[] numbers2 = { 5, 3, 8, 4, 1, 2 };


            ////MaxHeap.Heapify(numbers2);
            //Console.WriteLine(MaxHeap.GetKthLargest(numbers2,2));


            MinHeap minHeap = new MinHeap();
            minHeap.Insert(5, "A");
            minHeap.Insert(3, "B");
            minHeap.Insert(8, "C");
            minHeap.Insert(4, "D");
            minHeap.Insert(1, "E");
            minHeap.Insert(2, "F");
            
            Console.ReadKey();
        }
    }
}
