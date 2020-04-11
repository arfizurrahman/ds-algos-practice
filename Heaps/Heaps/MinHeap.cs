using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class MinHeap
    {
        private class Node
        {
            public int key;
            public string value;

            public Node(int key, string value)
            {
                this.key = key;
                this.value = value;
            }

            public override string ToString()
            {
                return "Key: " + key;
            }
        }

        private Node[] items = new Node[10];
        private int size;

        public void Insert(int key, string value)
        {
            if (IsFull())
                throw new InvalidOperationException();

            items[size++] = new Node(key, value);

            BubbleUp();
        }

        public int Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            var root = items[0];
            items[0] = items[size - 1];

            BubbleDown();

            return root.key;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == items.Length;
        }
        private int Parent(int index)
        {
            return (index - 1) / 2;
        }
        
        private void Swap(int first, int second)
        {
            var temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && items[index].key < items[Parent(index)].key)
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
                var smallerChildIndex = SmallerChildIndex(index);
                Swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }

        private int SmallerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index).key < RightChild(index).key)
                ? LeftChildIndex(index)
                : RightChildIndex(index);
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = items[index].key <= LeftChild(index).key;

            if (HasRightChild(index))
                isValid &= items[index].key <= RightChild(index).key;

            return isValid;
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }

        private Node LeftChild(int index)
        {
            return items[LeftChildIndex(index)];
        }
        private Node RightChild(int index)
        {
            return items[RightChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }
    }
}
