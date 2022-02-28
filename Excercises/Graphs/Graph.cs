using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Excercises.Graphs
{
    public class Graph
    {
        private readonly Dictionary<string, Node> _nodes;
        private readonly Dictionary<Node, List<Node>> _adjacencyList;
        private readonly bool _directed;

        public Graph(bool directed = false)
        {
            _directed = directed;
            _nodes = new Dictionary<string, Node>();
            _adjacencyList = new Dictionary<Node, List<Node>>();

        }
        public void AddNode(string label)
        {
            var node = new Node(label);
            _nodes.TryAdd(label, node);
            _adjacencyList.Add(node, new List<Node>());
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

            _adjacencyList[fromNode].Remove(toNode);

            if (!_directed)
                _adjacencyList[toNode].Remove(fromNode);
        }

        private void RemoveAllEdges(Node node)
        {
            _adjacencyList.Remove(node);
            foreach (var parentNode in _adjacencyList)
            {
                if (parentNode.Value.Contains(node))
                    parentNode.Value.Remove(node);
            }
        }

        public void AddEdge(string from, string to)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                throw new ArgumentException();

            if (!_nodes.TryGetValue(to, out Node toNode))
                throw new ArgumentException();

            _adjacencyList[fromNode].Add(toNode);

            if (!_directed)
                _adjacencyList[toNode].Add((fromNode));
        }

        public void Print()
        {
            foreach (var source in _adjacencyList.Keys)
            {
                var targets = _adjacencyList[source];
                if (targets?.Count > 0)
                    targets.ForEach(i => Console.WriteLine($"{source} is sharing border with {i}"));
            }
        }

        private class Node
        {
            public Node(string label)
            {
                Label = label;
            }
            public string Label { get; set; }
            public List<Node> Edges { get; set; }

            public override string ToString()
            {
                return Label;
            }
        }
    }
}