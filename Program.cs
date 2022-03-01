using System;
using System.Collections.Generic;
using BinaryTrees;
using DSA.Excercises.AVLTrees;
using HashTables;
using Queues;
using DSA.Excercises.Helpers;
using Heaps = DSA.Excercises.Heaps;
using System.Linq;
using DSA.Excercises.Tries;
using DSA.Excercises.Graphs;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            // BinaryTreeExcercises();
            // AvlTreeExcercises();
            // HeapExcercises();
            // TrieExcercises();
            // GraphExcercises();
            WeightedGrapExcercises();
            Console.Read();
        }

        public static void WeightedGrapExcercises()
        {
            WeightedGraph graph = new WeightedGraph();
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");
            graph.AddNode("F");
            graph.AddNode("G");
            graph.AddNode("H");

            graph.AddEdge("A", "B", 2);
            graph.AddEdge("B", "F", 4);
            graph.AddEdge("F", "H", 1);
            graph.AddEdge("A", "C", 1);
            graph.AddEdge("D", "C", 3);
            graph.AddEdge("D", "G", 2);
            graph.AddEdge("D", "E", 1);
            graph.AddEdge("G", "H", 1);
            graph.AddEdge("B", "D", 1);
            graph.AddEdge("E", "H", 1);
            graph.GetShortestPathDistance("A", "H", out string shortestPath);
            // graph.Print();
        }

        public static void GraphExcercises()
        {
            // Graph graph = new Graph(true);
            // graph.AddNode("KA");
            // graph.AddNode("TN");
            // graph.AddNode("GOA");
            // graph.AddNode("KE");
            // graph.AddNode("AP");
            // graph.AddNode("TE");
            // graph.AddNode("MH");
            // graph.AddNode("UP");
            // graph.AddNode("MP");

            // graph.AddEdge("KA", "TN");
            // graph.AddEdge("KA", "GOA");
            // graph.AddEdge("KA", "AP");
            // graph.AddEdge("KA", "KE");
            // graph.AddEdge("KA", "TE");
            // graph.AddEdge("KA", "MH");
            // graph.AddEdge("TN", "KE");
            // graph.AddEdge("TN", "AP");
            // graph.AddEdge("MH", "MP");
            // graph.AddEdge("MH", "TE");
            // graph.AddEdge("AP", "TE");
            // graph.AddEdge("GOA", "TN");
            // graph.AddEdge("GOA", "MH");

            // graph.RemoveNode("TN");
            // graph.RemoveEdge("MH", "KA");
            // graph.DepthFirstTraversalUsingIteration("GOA");
            // Console.WriteLine("......................");
            // graph.DepthFirstTraversal("GOA");
            // Console.WriteLine("......................");
            // graph.BreadthFirstTraversalUsing("GOA");

            // graph.Print();

            // Graph graph = new Graph(true);
            // graph.AddNode("X");
            // graph.AddNode("A");
            // graph.AddNode("B");
            // graph.AddNode("P");

            // graph.AddEdge("X", "A");
            // graph.AddEdge("X", "B");
            // graph.AddEdge("A", "P");
            // graph.AddEdge("B", "P");

            // var sortedList = graph.TopologicalSort();

            Graph cyclicCheckGraph = new Graph(true);
            cyclicCheckGraph.AddNode("X");
            cyclicCheckGraph.AddNode("A");
            cyclicCheckGraph.AddNode("B");
            cyclicCheckGraph.AddNode("C");

            cyclicCheckGraph.AddEdge("X", "A");
            cyclicCheckGraph.AddEdge("A", "B");
            cyclicCheckGraph.AddEdge("B", "C");
            cyclicCheckGraph.AddEdge("C", "A");
            Console.WriteLine(cyclicCheckGraph.HasCyclicSet());
        }

        public static void TrieExcercises()
        {
            Trie trie = new Trie();
            trie.Insert("Cat");
            trie.Insert("Boy");
            trie.Insert("Book");
            trie.Insert("Border");
            trie.Insert("Bookworm");
            trie.Insert("Batman");
            trie.Insert("Caterpillar");
            trie.Insert("Caramel");
            trie.Insert("Camel");
            trie.Insert("Pick");
            trie.Insert("Pickle");
            trie.Insert("chess");

            // trie.Contains("cat");
            // trie.PreOrderTraversal();
            // trie.Remove("Pickle");
            // var suggestions = trie.AutoComplete("c");
            // Console.WriteLine(string.Join(", ", suggestions));
            // Console.WriteLine(trie.ContainsRecursive("care"));
            // Console.WriteLine(trie.CountWords());
            Console.WriteLine(LongestCommonPrefix(new string[] { "canopy", "canon", "cannibalism" }));
        }

        public static void HeapExcercises()
        {
            // MaxHeap maxHeap = new MaxHeap();
            // maxHeap.Insert(15);
            // maxHeap.Insert(10);
            // maxHeap.Insert(3);
            // maxHeap.Insert(8);
            // maxHeap.Insert(12);
            // maxHeap.Insert(9);
            // maxHeap.Insert(4);
            // maxHeap.Insert(1);
            // maxHeap.Insert(24);
            // maxHeap.Remove();
            // var heapClone = maxHeap.Clone<MaxHeap>();
            // Console.WriteLine(string.Join(' ', HeapSort(maxHeap)));
            // Console.WriteLine(string.Join(' ', HeapSort(heapClone, true)));
            // int[] arr = new int[6] { 5, 3, 8, 4, 1, 2 };
            // var heap = MaxHeap.Heapify(arr);
            // var heap = new MaxHeap(arr);
            // System.Console.WriteLine(heap.IsMaxHeap());
            // Console.WriteLine(heap.GetKthLargestElement(2));
            Heaps.PriorityQueue pQueue = new Heaps.PriorityQueue();
            pQueue.EnQueue(5, "Five");
            pQueue.EnQueue(23, "Twenty Three");
            pQueue.EnQueue(47, "Forty Seven");
            pQueue.EnQueue(1, "One");
            pQueue.EnQueue(4, "Four");
            pQueue.EnQueue(21, "Twenty One");

            while (pQueue.Size != 0)
            {
                Console.WriteLine(pQueue.DeQueue());
            }
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

        public static int[] HeapSort(Heaps.Heap heap, bool descending = false)
        {
            if (heap == null)
                throw new InvalidOperationException("Heap can't be nuill");

            int[] sortedArray = new int[heap.Values.Count];

            if (descending)
            {
                int count = heap.Values.Count;
                for (int i = 0; i < count; i++)
                {
                    sortedArray[i] = heap.Remove();
                }
            }

            else
            {
                for (int i = heap.Values.Count - 1; i >= 0; i--)
                {
                    sortedArray[i] = heap.Remove();
                }
            }

            return sortedArray;
        }

        public static string LongestCommonPrefix(string[] array)
        {
            Trie trie = new Trie(array);
            return trie.LongestCommonPrefix();
        }
    }
}
