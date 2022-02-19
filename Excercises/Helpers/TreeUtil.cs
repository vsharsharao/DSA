using System;
using System.Collections.Generic;
using DSA.Excercises.Trees;

namespace DSA.Excercises.Helpers
{
    public static class TreeUtil
    {
        public static int Size(this ITree tree) => Size(tree.Root);

        public static int CountLeaves(this ITree tree) => Size(tree.Root, true);

        public static int Max(this ITree tree) => Max(tree.Root);

        public static bool Contains(this ITree tree, int value) => Contains(tree.Root, value);

        public static bool IsPerfectTree(this ITree tree)
        {
            return Math.Pow(2, tree.Root.Height + 1) - 1 == tree.Size();
        }

        public static bool AreSibling(this ITree tree, int value1, int value2)
        {
            INode node2 = GetNodeByValue(tree, value2);
            INode node1 = GetNodeByValue(tree, value1);

            if (node1 == null || node2 == null)
                return false;

            return (GetParent(tree, node1) == GetParent(tree, node2));
        }

        public static List<int> GetAncestors(this ITree tree, int value)
        {
            List<int> ancestors = new List<int>();
            INode node = GetNodeByValue(tree, value);
            while (true)
            {
                try
                {
                    node = GetParent(tree, node);
                    ancestors.Add(node.Value);
                }

                catch (InvalidOperationException)
                {
                    break;
                }

            }
            return ancestors;
        }

        public static INode GetNodeByValue(this ITree tree, int value)
        {
            return GetNodeByValue(tree.Root, value);
        }

        public static int Depth(this ITree tree, int value)
        {
            return Depth(tree, tree.GetNodeByValue(value));
        }

        private static int Size(INode node, bool onlyLeaves = false)
        {
            if (IsLeaf(node))
                return 1;

            if (onlyLeaves)
                return Size(node.LeftChild, true) + Size(node.RightChild, true);

            return 1
            + (node.LeftChild == null ? 0 : Size(node.LeftChild))
            + (node.RightChild == null ? 0 : Size(node.RightChild));
        }

        private static bool IsLeaf(INode node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        private static INode GetParent(ITree tree, INode node)
        {
            if (node == tree.Root)
                throw new InvalidOperationException("Root has no parent element");

            var current = tree.Root;
            while (current != null)
            {
                if (current.LeftChild.Value == node.Value || current.RightChild.Value == node.Value)
                    return current;

                if (current.Value > node.Value)
                    current = current.LeftChild;

                else if (current.Value < node.Value)
                    current = current.RightChild;
            }

            throw new InvalidOperationException("The requested node is not present in the tree");
        }

        private static int Depth(ITree tree, INode node)
        {
            if (node == null)
                throw new InvalidOperationException("The value doesn't exist in the tree");

            var current = tree.Root;
            int depth = 0;

            while (current != null)
            {
                if (current.Value == node.Value)
                    return depth;

                else if (current.Value > node.Value)
                {
                    current = current.LeftChild;
                    depth++;
                }

                else if (current.Value < node.Value)
                {
                    current = current.RightChild;
                    depth++;
                }
            }
            return 0;
        }

        private static INode GetNodeByValue(INode node, int value)
        {
            if (node == null)
                return null;

            if (node.Value == value)
                return node;

            if (node.Value < value)
                return GetNodeByValue(node.RightChild, value);

            if (node.Value > value)
                return GetNodeByValue(node.LeftChild, value);

            return null;
        }

        private static int Max(INode node)
        {
            if (IsLeaf(node))
                return node.Value;

            return Max(node.RightChild);
        }

        private static bool Contains(INode node, int value)
        {
            if (node == null)
                return false;

            if (node.Value == value)
                return true;

            if (node.Value < value)
                return Contains(node.RightChild, value);

            if (node.Value > value)
                return Contains(node.LeftChild, value);

            return false;
        }
    }
}