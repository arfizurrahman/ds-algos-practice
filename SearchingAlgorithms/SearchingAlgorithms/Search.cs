using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAlgorithms
{
    class Search
    {
        public int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == target)
                    return i;

            return -1;
        }

        public int BinarySearch(int[] array, int target)
        {
            return BinarySearch(array, target, 0, array.Length - 1);
        }

        private int BinarySearch(int[] array, int target, int left, int right)
        {
            if (right < left)
                return -1;

            var middle = (left + right) / 2;
            if (array[middle] == target)
                return middle;

            if (array[middle] > target)
            {
                return BinarySearch(array, target, left, middle-1);
            }
            return BinarySearch(array, target, middle + 1, right);
        }

        public int BinarySearchIter(int[] array, int target)
        {
            var left = 0;
            var right = array.Length - 1;

            while (right >= left)
            {
                var middle = (left + right) / 2;
                if (array[middle] == target)
                    return middle;

                if (array[middle] > target)
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;

        }
    }
}
