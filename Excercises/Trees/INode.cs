using System;

namespace DSA.Excercises.Trees
{
    public interface INode
    {
        public int Value { get; set; }

        public INode LeftChild { get; set; }

        public INode RightChild { get; set; }

        public int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}