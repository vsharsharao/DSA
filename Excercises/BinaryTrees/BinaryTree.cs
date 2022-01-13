using System;

namespace BinaryTrees
{
    public class BinaryTree
    {
        public Node Root { get; set; }

        public bool Find(int value)
        {
            var current = Root;
            while (current != null)
            {
                if (value > current.Value)
                    current = current.RightChild;
                else if (value < current.Value)
                    current = current.LeftChild;
                else
                    return true;
            }

            return false;
        }

        public void Insert(int value)
        {
            var node = new Node(value);

            if (Root == null)
                Root = node;
            else
            {
                var current = Root;
                while (current != null)
                {
                    if (value > current.Value)
                    {
                        if (current.RightChild == null)
                        {
                            current.RightChild = node;
                            break;
                        }
                        else
                            current = current.RightChild;
                    }
                    else if (value < current.Value)
                    {
                        if (current.LeftChild == null)
                        {
                            current.LeftChild = node;
                            break;
                        }
                        else
                            current = current.LeftChild;
                    }
                }
            }
        }

        public void PreOrderTraversal()
        {
            Console.WriteLine("PreOrder Traversal:");
            Console.WriteLine("-------------------");
            PreOrderTraversal(Root);
            Console.WriteLine("\n-------------------");
        }

        public void InOrderTraversal()
        {
            Console.WriteLine("InOrder Traversal:");
            Console.WriteLine("-------------------");
            InOrderTraversal(Root);
            Console.WriteLine("\n-------------------");
        }

        public void PostOrderTraversal()
        {
            Console.WriteLine("PostOrder Traversal:");
            Console.WriteLine("-------------------");
            PostOrderTraversal(Root);
            Console.WriteLine("\n-------------------");
        }

        public int Height()
        {
            return Height(Root);
        }

        public int Min()
        {
            return Min(Root);
        }

        public bool Equals(BinaryTree tree)
        {
            if (tree == null || Root == null)
                return false;

            return Equals(Root, tree.Root);
        }

        public bool IsBinarySearchTree()
        {
            if (Root == null)
                return false;

            var current = Root;
            while (current != null)
            {
                if (current.LeftChild.Value > current.Value || current.RightChild.Value < current.Value)
                    return false;
                current = current.LeftChild;
            }

            return true;
        }

        #region Private methods
        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.LeftChild);
                Console.Write($"{node.Value} ");
                InOrderTraversal(node.RightChild);
            }
        }

        private void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write($"{node.Value} ");
                PreOrderTraversal(node.LeftChild);
                PreOrderTraversal(node.RightChild);
            }
        }

        private void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.LeftChild);
                PostOrderTraversal(node.RightChild);
                Console.Write($"{node.Value} ");
            }
        }

        private int Height(Node node)
        {
            if (node == null) throw new ArgumentException("Node is null");

            if (IsLeaf(node)) return 0;

            return 1 +
            Math.Max(Height(node.LeftChild), Height(node.RightChild));
        }

        private bool IsLeaf(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        private bool IsRoot(Node node)
        {
            return node == Root;
        }

        private int Min(Node node)
        {
            if (IsLeaf(node)) return node.Value;

            var left = Min(node.LeftChild);
            var right = Min(node.RightChild);

            return Math.Min(Math.Min(left, right), node.Value);
        }

        private bool Equals(Node primaryNode, Node node)
        {
            if (primaryNode == null && node == null)
                return true;

            else if (primaryNode != null && node != null)
                return primaryNode.Value == node.Value && Equals(primaryNode.LeftChild, node.LeftChild) && Equals(primaryNode.RightChild, node.RightChild);

            return false;
        }
        #endregion
    }

    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public Node LeftChild { get; set; }

        public Node RightChild { get; set; }
    }
}
