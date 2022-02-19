using System;
using DSA.Excercises.Trees;

namespace DSA.Excercises.AVLTrees
{
    public class AvlTree : ITree
    {
        public INode Root { get; set; }

        public void Insert(int value)
        {
            Root = Insert(Root, value);
        }

        public bool IsBalanced()
        {
            return IsBalanced(Root);
        }

        #region Private methods

        private bool IsBalanced(INode node)
        {
            var balanceFactor = BalanceFactor(node);
            var unbalanced = balanceFactor > 1 || balanceFactor < -1;

            if (unbalanced)
            {
                return !unbalanced;
            }

            return node.LeftChild == null ? true : IsBalanced(node.LeftChild) && node.RightChild == null ? true : IsBalanced(node.RightChild);
        }
        private INode Insert(INode node, int value)
        {
            if (node == null)
                return new AvlNode(value);

            if (node.Value < value)
                node.RightChild = Insert(node.RightChild, value);

            else if (node.Value > value)
                node.LeftChild = Insert(node.LeftChild, value);

            SetHeight(node);

            return Balance(node);
            // return node;
        }

        private INode Balance(INode node)
        {
            if (IsLeftHeavy(node))
            {
                if (BalanceFactor(node.LeftChild) < 0)
                    node.LeftChild = LeftRotate(node.LeftChild);
                node = RightRotate(node);
            }

            else if (IsRighttHeavy(node))
            {
                if (BalanceFactor(node.RightChild) > 0)
                    node.RightChild = RightRotate(node.RightChild);
                node = LeftRotate(node);
            }

            return node;
        }

        private INode LeftRotate(INode node)
        {
            var newRoot = node.RightChild;
            var oldRoot = node;
            oldRoot.RightChild = newRoot.LeftChild?.Value > oldRoot.Value ? newRoot.LeftChild : null;
            newRoot.LeftChild = oldRoot;

            SetHeight(oldRoot);
            SetHeight(newRoot);

            return newRoot;
        }

        private INode RightRotate(INode node)
        {
            var newRoot = node.LeftChild;
            var oldRoot = node;
            oldRoot.LeftChild = newRoot.RightChild?.Value < oldRoot.Value ? newRoot.RightChild : null;
            newRoot.RightChild = oldRoot;

            SetHeight(oldRoot);
            SetHeight(newRoot);

            return newRoot;
        }

        private bool IsLeftHeavy(INode node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRighttHeavy(INode node)
        {
            return BalanceFactor(node) < -1;
        }

        private int BalanceFactor(INode node)
        {
            return Height(node?.LeftChild) - Height(node?.RightChild);
        }

        private int Height(INode node)
        {
            return node == null ? -1 : node.Height;
        }

        private void SetHeight(INode node)
        {
            node.Height = 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));
        }

        #endregion
    }

    public class AvlNode : INode
    {
        public AvlNode(int value)
        {
            Value = value;
        }
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }
        public int Value { get; set; }
        public int Height { get; set; }
    }
}