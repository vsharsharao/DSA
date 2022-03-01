using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Excercises.Graphs
{
    public class Graph
    {
        private readonly Dictionary<string, Node> _nodes;
        private readonly bool _directed;

        public Graph(bool directed = false)
        {
            _directed = directed;
            _nodes = new Dictionary<string, Node>();

        }
        public void AddNode(string label)
        {
            var node = new Node(label);
            _nodes.TryAdd(label, node);
        }

        public void RemoveNode(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;

            _nodes.Remove(node.Label);
            RemoveAllEdges(node);
        }

        public void RemoveEdge(string from, string to)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                throw new ArgumentException();

            if (!_nodes.TryGetValue(to, out Node toNode))
                throw new ArgumentException();

            fromNode.Edges.Remove(toNode);

            if (!_directed)
                toNode.Edges.Remove(fromNode);
        }

        public void DepthFirstTraversal(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;

            DepthFirstTraversal(node, new HashSet<Node>());
        }

        public void BreadthFirstTraversalUsing(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;

            Queue<Node> stack = new Queue<Node>();
            HashSet<Node> visitedSet = new HashSet<Node>();
            stack.Enqueue(node);

            while (stack.Count != 0)
            {
                var current = stack.Dequeue();
                if (visitedSet.Contains(current))
                    continue;
                visitedSet.Add(current);
                Console.WriteLine(current);
                if (current?.Edges?.Count > 0)
                    current.Edges.ToList().ForEach(i => stack.Enqueue(i));
            }
        }

        public void DepthFirstTraversalUsingIteration(string label)
        {
            if (!_nodes.TryGetValue(label, out Node node))
                return;

            Stack<Node> stack = new Stack<Node>();
            HashSet<Node> visitedSet = new HashSet<Node>();
            stack.Push(node);

            while (stack.Count != 0)
            {
                var current = stack.Pop();
                visitedSet.Add(current);
                Console.WriteLine(current);
                if (current?.Edges?.Count > 0)
                    current.Edges.Where(i => !visitedSet.Contains(i)).ToList().ForEach(i => stack.Push(i));
            }
        }

        public List<string> TopologicalSort()
        {
            var sortedStack = new Stack<string>();
            var visitedNodes = new HashSet<Node>();
            List<string> sortedList = new List<string>();

            foreach (var parentNode in _nodes.Values)
                TopologicalSort(parentNode, visitedNodes, sortedStack);

            if (sortedStack.Count > 0)
            {
                while (sortedStack.Count != 0)
                    sortedList.Add(sortedStack.Pop());
            }

            return sortedList;
        }

        public void AddEdge(string from, string to)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                throw new ArgumentException();

            if (!_nodes.TryGetValue(to, out Node toNode))
                throw new ArgumentException();

            fromNode.Edges.Add(toNode);

            if (!_directed)
                toNode.Edges.Add(fromNode);

        }

        public bool HasCyclicSet()
        {
            List<Node> visitedNodes = new List<Node>();
            foreach (Node node in _nodes.Values)
            {
                if (HasCyclicSet(node, _nodes.Values.ToList(), new List<Node>(), ref visitedNodes))
                    return true;

                else continue;
            }

            return false;
        }

        private bool HasCyclicSet(Node node, List<Node> allNodes, List<Node> visitingNodes, ref List<Node> visitedNodes)
        {
            bool hasCyclicSet = default;

            allNodes.Remove(node);
            visitingNodes.Add(node);

            if (visitedNodes.Contains(node))
                return false;

            foreach (Node edge in node.Edges)
            {
                if (visitedNodes.Contains(edge))
                    continue;

                if (visitingNodes.Contains(edge))
                    return true;

                if (HasCyclicSet(edge, allNodes, visitingNodes, ref visitedNodes))
                    return true;
            }

            visitedNodes.Add(node);
            visitingNodes.Remove(node);

            return false;
        }

        public void Print()
        {
            foreach (var source in _nodes.Values)
            {
                source.Edges.ForEach(i => Console.WriteLine($"{source} is sharing border with {i}"));
            }
        }

        private void RemoveAllEdges(Node node)
        {
            foreach (var parentNode in _nodes.Values)
            {
                if (parentNode.Edges.Contains(node))
                    parentNode.Edges.Remove(node);
            }
        }

        private void TopologicalSort(Node node, HashSet<Node> visitedNodes, Stack<string> sortedStack)
        {
            if (visitedNodes.Contains(node))
                return;

            visitedNodes.Add(node);

            foreach (var edge in node.Edges)
                TopologicalSort(edge, visitedNodes, sortedStack);

            sortedStack.Push(node.Label);
        }

        private void DepthFirstTraversal(Node node, HashSet<Node> nodeSet)
        {
            Console.WriteLine(node);
            nodeSet.Add(node);
            foreach (var edge in node.Edges)
            {
                if (!nodeSet.Contains(edge))
                    DepthFirstTraversal(edge, nodeSet);
            }
        }

        private class Node
        {
            public Node(string label)
            {
                Label = label;
            }
            public string Label { get; set; }
            public List<Node> Edges { get; set; } = new List<Node>();

            public override string ToString()
            {
                return Label;
            }
        }
    }
}