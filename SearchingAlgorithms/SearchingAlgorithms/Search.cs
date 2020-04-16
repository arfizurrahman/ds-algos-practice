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
                return BinarySearch(array, target, left, middle - 1);

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

        public int TernarySearch(int[] array, int target)
        {
            return TernarySearch(array, target, 0, array.Length - 1);
        }

        private int TernarySearch(int[] array, int target, int left, int right)
        {
            if (right < left)
                return -1;

            var partitionSize = (right - left) / 3;
            var mid1 = left + partitionSize;
            var mid2 = right - partitionSize;
            if (array[mid1] == target)
                return mid1;

            if (array[mid2] == target)
                return mid2;

            if (target < array[mid1])
                return TernarySearch(array, target, left, mid1 - 1);

            if (target > array[mid2])
                return TernarySearch(array, target, mid2 + 1, right);

            return TernarySearch(array, target, mid1 + 1, mid2 - 1);
        }

        public int JumpSearch(int[] array, int target)
        {
            var blockSize = Convert.ToInt32(Math.Sqrt(array.Length));
            var start = 0;
            var next = blockSize + 1;
            while (start < array.Length && array[next - 1] < target)
            {
                start = next;
                next += blockSize;

                if (next > array.Length)
                    next = array.Length;
            }

            for (int i = start; i < next; i++)
                if (array[i] == target)
                    return i;

            return -1;
        }

        public int ExponentialSearch(int[] array, int target)
        {
            var bound = 1;
            while (bound < array.Length && array[bound] < target)
                    bound *= 2;
            int left = bound / 2;
            int right = Math.Min(bound, array.Length-1);
            return BinarySearch(array, target, left, right);
        }
    }
}
