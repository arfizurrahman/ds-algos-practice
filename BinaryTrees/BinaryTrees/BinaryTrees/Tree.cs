using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class Tree
    {
        private class Node
        {
            public int value;
            public Node leftChild;
            public Node rightChild;

            public Node(int value)
            {
                this.value = value;
            }

            override
            public string ToString()
            {
                return "Node=" + value;
            }
        }

        private Node root;

        public void Insert(int value)
        {
            var node = new Node(value);
            if (root == null)
            {
                root = node;
                return;
            }

            var current = root;

            while (true)
            {
                if (value > current.value)
                {
                    if (current.rightChild != null)
                    {
                        current = current.rightChild;
                        continue;
                    }
                    current.rightChild = node;
                    break;
                }
                else {
                    if (current.leftChild != null)
                    {
                        current = current.leftChild;
                        continue;
                    }
                    current.leftChild = node;
                    break;
                }
            }
        }

        public bool Find(int value)
        {
            if (root == null)
                throw new InvalidOperationException();

            var current = root;
            while (current != null)
            {
                //if (current.value == value) return true;
                if (value > current.value)
                    current = current.rightChild;
                else if (value < current.value)
                    current = current.leftChild;
                else
                    return true;
            }

            return false;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(root);
        }
        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.value);
            TraversePreOrder(root.leftChild);
            TraversePreOrder(root.rightChild);
        }

        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;
            TraverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            TraverseInOrder(root.rightChild);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;
            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return 0;

            return 1 + Math.Max(Height(root.leftChild), Height(root.rightChild));
        }

        // O(log n)
        public int Minimum()
        {
            if (root == null)
                throw new InvalidOperationException();

            var current = root;
            var last = current;
            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }

            return last.value;
        }

        public bool Equals(Tree other)
        {
            if (other == null)
                return false;

            return Equals(root, other.root);
        }

        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.value == second.value &&
                       Equals(first.leftChild, second.leftChild) &&
                       Equals(first.rightChild, second.rightChild);

            return false;
        }

        //O(n)
        private bool IsLeaf(Node node)
        {
            return root.leftChild == null && root.rightChild == null;
        }
        private int Minimum(Node root)
        {
            if (root == null)
                return -1;

            if (IsLeaf(root))
                return root.value;

            var left = Minimum(root.leftChild);
            var right = Minimum(root.rightChild);

            return Math.Min(Math.Min(left, right), root.value);
        }
    }
}
