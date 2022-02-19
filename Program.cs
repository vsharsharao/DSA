using System;
using System.Collections.Generic;
using BinaryTrees;
using DSA.Excercises.AVLTrees;
using HashTables;
using Queues;
using DSA.Excercises.Helpers;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            // BinaryTreeExcercises();
            AvlTreeExcercises();
            Console.Read();
        }

        public static void AvlTreeExcercises()
        {
            AvlTree avlTree = new AvlTree();
            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(8);
            // avlTree.Insert(18);
            avlTree.Insert(9);
            avlTree.Insert(22);
            avlTree.Insert(25);
            // Console.WriteLine(avlTree.IsBalanced());
            Console.WriteLine(avlTree.Size());
            Console.WriteLine(avlTree.IsPerfectTree());
        }

        public static void BinaryTreeExcercises()
        {
            BinaryTree bt = new BinaryTree();
            bt.InsertBst(20);
            bt.InsertBst(10);
            bt.InsertBst(30);
            bt.InsertBst(5);
            bt.InsertBst(15);
            bt.InsertBst(21);
            bt.InsertBst(35);

            BinaryTree bt2 = new BinaryTree();
            bt2.Insert(20);
            bt2.Insert(10);
            bt2.Insert(30);
            bt2.Insert(3);
            bt2.Insert(15);
            bt2.Insert(21);
            bt2.Insert(29);

            // bt.SwapRoot();
            // Console.WriteLine($"Are Equal : {bt.Equals(bt2)}");
            // Console.WriteLine($"Is BST : {bt.IsBinarySearchTree()}");

            // bt.InOrderTraversal();
            // bt.PreOrderTraversal();
            // bt.PostOrderTraversal();
            // Console.WriteLine($"Min Value: {bt.Min()}");
            // Console.WriteLine($"Height: {bt.Height()}");

            // bt.NodesAtK(2);
            // bt.LevelOrderTraversal();
            Console.WriteLine(bt.Size());
            // Console.WriteLine(bt.CountLeaves());
            // Console.WriteLine(bt.Max());
            // Console.WriteLine(bt.Contains(36));
            // Console.WriteLine(bt.Depth(5));
            // Console.WriteLine(bt.AreSibling(10, 30));
            // var ancestors = bt.GetAncestors(21);
            // ancestors.ForEach(i => Console.WriteLine(i));
        }
    }
}
