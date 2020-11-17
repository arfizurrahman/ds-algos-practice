using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Heap
    {
        private int[] items = new int[10];
        private int size;

        public void Insert(int value)
        {
            if (IsFull())
                throw new InvalidOperationException();

            items[size++] = value;

            BubbleUp();
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var root = items[0];
            items[0] = items[--size];

            BubbleDown();

            return root;
        }

        public bool IsFull()
        {
            return size == items.Length; ;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return items[0];
        }

        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index] > items[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index) > RightChild(index))
                ? LeftChildIndex(index)
                : RightChildIndex(index);
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = items[index] >= LeftChild(index);

            if (HasRightChild(index))
                isValid &= items[index] >= RightChild(index);

            return isValid;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private int LeftChild(int index)
        {
            return items[LeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return items[RightChildIndex(index)];
        }
        private int LeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }
        private int RightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

        private void Swap(int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

        public static bool IsMaxHeap(int[] array)
        {
            return IsMaxHeap(array, 0);
        }

        public static bool IsMaxHeap(int[] array, int index)
        {
            var lastParentIndex = array.Length / 2 - 1;

            if (index > lastParentIndex)
                return true;

            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;

            var isValidParent = array[lastParentIndex] >= array[leftChildIndex] &&
                                array[lastParentIndex] >= array[rightChildIndex];

            return isValidParent && IsMaxHeap(array, leftChildIndex) && IsMaxHeap(array, rightChildIndex);

        }

    }
}
