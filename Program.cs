using System;
using System.Collections.Generic;
using BinaryTrees;
using HashTables;
using Queues;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BinaryTree examples
            BinaryTree bt = new BinaryTree();
            bt.Insert(20);
            bt.Insert(10);
            bt.Insert(30);
            bt.Insert(5);
            bt.Insert(15);
            bt.Insert(21);
            bt.Insert(35);

            BinaryTree bt2 = new BinaryTree();
            bt2.Insert(20);
            bt2.Insert(10);
            bt2.Insert(30);
            bt2.Insert(3);
            bt2.Insert(15);
            bt2.Insert(21);
            bt2.Insert(35);

            Console.WriteLine($"Are Equal : {bt.Equals(bt2)}");
            Console.WriteLine($"Is BST : {bt.IsBinarySearchTree()}");

            // bt.InOrderTraversal();
            // bt.PreOrderTraversal();
            // bt.PostOrderTraversal();
            // Console.WriteLine($"Min Value: {bt.Min()}");
            // Console.WriteLine($"Height: {bt.Height()}");
            #endregion

            Console.Read();
        }
    }
}
