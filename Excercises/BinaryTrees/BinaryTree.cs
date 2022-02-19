using System;
using System.Collections.Generic;
using DSA.Excercises.Trees;

namespace BinaryTrees
{
    public class BinaryTree : ITree
    {
        public INode Root { get; set; }

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
                var random = new Random().Next(0, 1);
                while (current != null)
                {
                    if (current.LeftChild == null || random == 0)
                    {
                        current.LeftChild = node;
                        break;
                    }

                    else if (current.RightChild == null || random == 1)
                    {
                        current.RightChild = node;
                        break;
                    }
                }
            }
        }

        public void InsertBst(int value)
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
            return IsBinarySearchTree(Root, int.MaxValue, int.MinValue);
        }

        public void SwapRoot()
        {
            var temp = Root.LeftChild;
            Root.LeftChild = Root.RightChild;
            Root.RightChild = temp;
        }

        public void NodesAtK(int k)
        {
            NodesAtK(Root, k);
        }

        public void GetNodesAtDistance(INode node, int distance, ref List<INode> nodes)
        {
            if (Height(node) == distance)
            {
                nodes.Add(node);
                return;
            }
            GetNodesAtDistance(node.LeftChild, distance, ref nodes);
            GetNodesAtDistance(node.RightChild, distance, ref nodes);
        }

        public void LevelOrderTraversal()
        {
            for (int i = Height(); i >= 0; i--)
            {
                List<INode> nodes = new List<INode>();
                GetNodesAtDistance(Root, i, ref nodes);
                foreach (INode node in nodes)
                {
                    Console.WriteLine(node.Value);
                }
            }
        }

        #region Private methods

        private void NodesAtK(INode node, int k)
        {
            if (k == 0)
            {
                Console.WriteLine(node.Value);
                return;
            }

            if (IsLeaf(node))
            {
                return;
            }

            k--;
            NodesAtK(node.LeftChild, k);
            NodesAtK(node.RightChild, k);
        }

        private bool IsBinarySearchTree(INode node, int max, int min)
        {
            if (node == null)
                return true;

            if (node.Value < min || node.Value > max)
                return false;

            return IsBinarySearchTree(node.LeftChild, node.Value - 1, min) && IsBinarySearchTree(node.RightChild, max, node.Value + 1);
        }
        private void InOrderTraversal(INode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.LeftChild);
                Console.Write($"{node.Value} ");
                InOrderTraversal(node.RightChild);
            }
        }

        private void PreOrderTraversal(INode node)
        {
            if (node != null)
            {
                Console.Write($"{node.Value} ");
                PreOrderTraversal(node.LeftChild);
                PreOrderTraversal(node.RightChild);
            }
        }

        private void PostOrderTraversal(INode node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.LeftChild);
                PostOrderTraversal(node.RightChild);
                Console.Write($"{node.Value} ");
            }
        }

        private int Height(INode node)
        {
            if (node == null) throw new ArgumentException("Node is null");

            if (IsLeaf(node)) return 0;

            return 1 +
            Math.Max(Height(node.LeftChild), Height(node.RightChild));
        }

        private bool IsLeaf(INode node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        private bool IsRoot(INode node)
        {
            return node == Root;
        }

        private int Min(INode node)
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

    public class Node : INode
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public INode LeftChild { get; set; }

        public INode RightChild { get; set; }
    }
}
