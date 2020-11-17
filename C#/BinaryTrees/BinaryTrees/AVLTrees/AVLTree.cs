﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTrees
{
    class AVLTree
    {
        private class AVLNode
        {
            public int value;
            public int height;
            public AVLNode leftChild;
            public AVLNode rightChild;

            public AVLNode(int value)
            {
                this.value = value;
            }

            override
                public string ToString()
            {
                return "Node=" + value;
            }
        }

        private AVLNode root;
        public void Insert(int value)
        {
            root = Insert(root, value);
        }

        private AVLNode Insert(AVLNode root, int value)
        {
            if (root == null)
                return new AVLNode(value);

            if (root.value < value)
                root.rightChild = Insert(root.rightChild, value);
            else
                root.leftChild = Insert(root.leftChild, value);

            SetHeight(root);

            return Balance(root);
        }

        private AVLNode Balance(AVLNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.leftChild) < 0)
                    root.leftChild = RotateLeft(root.leftChild);
                return RotateRight(root);

            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.rightChild) > 0)
                    root.rightChild = RotateRight(root.rightChild);
                return RotateLeft(root);

            }

            return root;
        }

        private AVLNode RotateRight(AVLNode root)
        {
            var newRoot = root.leftChild;
            root.leftChild = newRoot.rightChild;
            newRoot.rightChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private AVLNode RotateLeft(AVLNode root)
        {
            var newRoot = root.rightChild;
            root.rightChild = newRoot.leftChild;
            newRoot.leftChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private void SetHeight(AVLNode node)
        {
            node.height = Math.Max(Height(node.leftChild), Height(node.rightChild)) + 1;
        }

        private bool IsLeftHeavy(AVLNode node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(AVLNode node)
        {
            return BalanceFactor(node) < -1;
        }

        private int BalanceFactor(AVLNode node)
        {
            return node == null ? 0 : Height(node.leftChild) - Height(node.rightChild);
        }

        private int Height(AVLNode node)
        {
            return node?.height ?? -1;
        }
    }
}
