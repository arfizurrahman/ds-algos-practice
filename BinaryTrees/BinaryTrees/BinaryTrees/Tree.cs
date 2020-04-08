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

        public List<int> GetAncestors(int value)
        {
            List<int> list = new List<int>();
            GetAncestors(root, value, list);
            return list;
        }

        private bool GetAncestors(Node root, int value, List<int> list)
        {
            if (root == null)
                return false;

            if (root.value == value)
                return true;


            if (GetAncestors(root.leftChild, value, list) ||
                GetAncestors(root.rightChild, value, list))
            {
                list.Add(root.value);
                return true;
            }

            return false;
        }
        private Node GetNode(int value)
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
                    return current;
            }

            return null;
        }

        public bool Contains(int value)
        {
            return Contains(root, value);
        }

        private bool Contains(Node root, int value)
        {
            if (root == null)
                return false;
            
            if (root.value == value)
                return true;

            return Contains(root.leftChild, value) || Contains(root.rightChild, value);
        }

        public bool AreSibling(int value1, int value2)
        {
            return AreSibling(root, value1, value2);
        }

        private bool AreSibling(Node root, int value1, int value2)
        {
            if (root == null)
                return false;

            var areSibling = false;

            if (root.leftChild != null && root.rightChild != null)
            {
                areSibling = (root.leftChild.value == value1 && root.rightChild.value == value2)
                             || (root.rightChild.value == value1 && root.leftChild.value == value2);
            }

            return areSibling || 
                   AreSibling(root.leftChild, value1, value2) ||
                   AreSibling(root.rightChild, value1, value2);
        }

        //private bool AreSibling(Node root, int value1, int value2)
        //{
        //    if (IsLeaf(root))
        //        return false;

        //    if ((root.leftChild.value == value1 && root.rightChild.value == value2)
        //        || (root.rightChild.value == value1 && root.leftChild.value == value2))
        //    {
        //        return true;
        //    }

        //    return AreSibling(root.leftChild, value1, value2) || AreSibling(root.rightChild, value1, value2);
        //}

        public void TraverseLevelOrder()
        {
            for (int i = 0; i <= Height(); i++)
            {
                foreach (var value in GetNodesAtDistance(i))
                {
                    Console.WriteLine(value);
                }
            }
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

        public void SwapRoot()
        {
            var temp = root.leftChild;
            root.leftChild = root.rightChild;
            root.rightChild = temp;
        }

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root, Int32.MaxValue, Int32.MinValue);
        }

        private bool IsBinarySearchTree(Node root, int max, int min)
        {
            if (root == null)
                return true;

            if (root.value < min || root.value > max)
                return false;

            return IsBinarySearchTree(root.leftChild, root.value - 1, min) &&
                   IsBinarySearchTree(root.rightChild, max, root.value + 1);

        }

        public List<int> GetNodesAtDistance(int distance)
        {
            List<int> list = new List<int>();
            GetNodesAtDistance(root, distance, list);
            return list;
        }

        private void GetNodesAtDistance(Node root, int distance, List<int> list)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                list.Add(root.value);
                return;
            }

            GetNodesAtDistance(root.leftChild, distance - 1, list);
            GetNodesAtDistance(root.rightChild, distance - 1, list);
        }

        //O(n)
        private bool IsLeaf(Node node)
        {
            return node.leftChild == null && node.rightChild == null;
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

        public int Maximum()
        {
            if (root == null)
                throw new InvalidOperationException();

            return Maximum(root);
            //var current = root;
            //var last = current;
            //while (current != null)
            //{
            //    last = current;
            //    current = current.rightChild;
            //}

            //return last.value;
        }

        private int Maximum(Node root)
        {
            if (root.rightChild == null)
                return root.value;

            return Maximum(root.rightChild);
        }

        //public int Size()
        //{
        //    var count = 0;
        //    for (int i = 0; i <= Height(); i++)
        //    {
        //        count += GetNodesAtDistance(i).Count;
        //    }

        //    return count;
        //}

        public int Size()
        {
            return Size(root);
        }
        private int Size(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return 1 + Size(root.leftChild) + Size(root.rightChild);
        }

        public int CountLeaves()
        {
            return CountLeaves(root);
        }
        private int CountLeaves(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return CountLeaves(root.leftChild) + CountLeaves(root.rightChild);
        }
    }
}
