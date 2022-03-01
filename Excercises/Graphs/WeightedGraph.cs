using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.Excercises.Graphs
{
    public class WeightedGraph
    {
        private Dictionary<string, Node> _nodes;
        public WeightedGraph()
        {
            _nodes = new Dictionary<string, Node>();
        }

        public void AddNode(string label)
        {
            var node = new Node(label);
            _nodes.Add(label, node);
        }

        public void AddEdge(string from, string to, int weight)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                throw new ArgumentException();

            if (!_nodes.TryGetValue(to, out Node toNode))
                throw new ArgumentException();

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public int GetShortestPathDistance(string from, string to, out string shortestPath)
        {
            if (!_nodes.TryGetValue(from, out Node fromNode))
                throw new ArgumentException();

            if (!_nodes.TryGetValue(to, out Node toNode))
                throw new ArgumentException();

            PriorityQueue<Node, int> pQueue = new PriorityQueue<Node, int>(
                    Comparer<int>.Create((i, j) => i.CompareTo(j))
                );

            pQueue.Enqueue(fromNode, 0);
            Dictionary<Node, int> distances = new Dictionary<Node, int>();
            Dictionary<Node, Node> previousNodes = new Dictionary<Node, Node>();
            HashSet<Node> visitedNodes = new HashSet<Node>();

            foreach (var node in _nodes.Values)
            {
                distances.Add(node, int.MaxValue);
            }
            distances[fromNode] = 0;

            GetShortestPathDistance(distances, previousNodes, pQueue, visitedNodes, fromNode);

            shortestPath = GetShortestPath(previousNodes, from, to);
            return distances[toNode];
        }

        private void GetShortestPathDistance(Dictionary<Node, int> distances, Dictionary<Node, Node> previousNodes, PriorityQueue<Node, int> pQueue, HashSet<Node> visitedNodes, Node fromNode)
        {
            while (pQueue.Count > 0)
            {
                var node = pQueue.Dequeue();

                if (visitedNodes.Contains(node))
                    continue;

                foreach (var edge in node.Edges)
                {
                    if (visitedNodes.Contains(edge.To))
                        continue;

                    if (distances.ContainsKey(edge.From) && distances[edge.To] > distances[edge.From] + edge.Weight)
                    {
                        var distance = distances[edge.From] + edge.Weight;
                        distances[edge.To] = distance;
                        previousNodes[edge.To] = edge.From;
                    }

                    pQueue.Enqueue(edge.To, distances[edge.To]);
                }
                visitedNodes.Add(node);
                GetShortestPathDistance(distances, previousNodes, pQueue, visitedNodes, fromNode);
            }
        }

        private string GetShortestPath(Dictionary<Node, Node> previousNodes, string from, string to)
        {
            Stack<string> shortestPathNodes = new Stack<string>();
            shortestPathNodes.Push(to);
            var current = previousNodes[_nodes[to]];
            while (current.Label != from)
            {
                shortestPathNodes.Push(current.Label);
                current = previousNodes[current];
            }
            shortestPathNodes.Push(from);
            return string.Join(" -> ", shortestPathNodes);
        }

        public void Print()
        {
            foreach (var node in _nodes.Values)
            {
                Console.WriteLine($"{node} is connected to [{string.Join(", ", node.Edges)}]");
            }
        }

        private class Node
        {
            public Node(string label)
            {
                Label = label;
                Edges = new List<Edge>();
            }
            public string Label { get; set; }

            public List<Edge> Edges { get; set; }

            public void AddEdge(Node to, int weight)
            {
                Edges.Add(new Edge(this, to, weight));
            }

            public override string ToString()
            {
                return Label;
            }
        }

        private class NodeEntry
        {
            public Node Node { get; set; }
            public int Priority { get; set; }

            public NodeEntry(Node node, int priority)
            {
                Priority = priority;
                Node = node;
            }
        }

        private class Edge
        {
            public Edge(Node from, Node to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }
            public Node From { get; set; }
            public Node To { get; set; }
            public int Weight { get; set; }

            public override string ToString()
            {
                return $"{From} - {To}";
            }
        }
    }
}