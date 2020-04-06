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
            if (root == null) {
                root = node;
                return;
            }

            var current = root;

            while (true) {
                if (value > current.value) {
                    if (current.rightChild != null) {
                        current = current.rightChild;
                        continue;
                    }
                    current.rightChild = node;
                    break;
                } else {
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
    }
}
