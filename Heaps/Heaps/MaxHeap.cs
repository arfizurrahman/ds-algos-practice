﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class MaxHeap
    {
        public static void Heapify(int[] array)
        {
            var lastParentIndex = array.Length / 2 - 1;
            for (int i = lastParentIndex; i >= 0 ; i--)
            {
                Heapify(array, i);
            }
        }

        public static void Heapify(int[] array, int index)
        {
            var largerIndex = index;

            var leftIndex = index * 2 + 1;
            if (leftIndex < array.Length && array[leftIndex] > array[index])
                largerIndex = leftIndex;

            var rightIndex = index * 2 + 2;
            if (rightIndex < array.Length && array[rightIndex] > array[index])
                largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);

            Heapify(array, largerIndex);
        }

        private static void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        public static int GetKthLargest(int[] array, int k)
        {
            if (k < 1 || k > array.Length)
                throw new ArgumentException();

            var heap = new Heap();

            foreach (var i in array)
                heap.Insert(i);

            for (int i = 0; i < k - 1; i++)
                heap.Remove();

            return heap.Max();
        }
    }
}
