using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.Excercises.Tries
{
    public class Trie
    {
        private const int ALPHABET_SIZE = 26;
        public Node Root { get; set; }
        public Trie()
        {
            Root = new Node("");
        }
        public Trie(string[] words)
        {
            if (words.Count() == 0)
                throw new ArgumentNullException("Word array is empty");

            Root = new Node("");
            words.ToList().ForEach(i => this.Insert(i));
        }
        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Word can't be empty");

            word = word.ToLower();
            var current = Root;

            foreach (char ch in word.ToCharArray())
            {
                if (!current.ContainsKey(ch))
                    current.AddNode(new Node(ch));

                current = current.GetCharNode(ch);
            }

            current.IsEndofWord = true;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            var charArray = word.ToLower().ToCharArray();
            var current = Root;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (!current.Children.ContainsKey(charArray[i]))
                    return false;

                current = current.GetCharNode(charArray[i]);
            }

            return current.IsEndofWord;
        }

        public bool ContainsRecursive(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            word = word.ToLower();

            return ContainsRecursive(Root, word, 0);
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
        }

        public void Remove(string word)
        {
            if (string.IsNullOrEmpty(word))
                return;

            word = word.ToLower();
            Remove(Root, word, 0);
        }

        public List<string> AutoComplete(string word)
        {
            List<string> wordList = new List<string>();
            StringBuilder sb = new StringBuilder(word);
            var current = Root;
            int index = 0;
            while (index < word.Length)
            {
                current = current.GetCharNode(word[index++]);
            }

            AutoComplete(current, sb, wordList);
            return wordList;
        }

        public int CountWords()
        {
            return CountWords(Root, 0);
        }

        public void Clear()
        {
            Root = new Node("");
        }

        public string LongestCommonPrefix()
        {
            if (Root.GetChildren().Count() > 1)
                return string.Empty;

            return LongestCommonPrefix(Root, new StringBuilder())?.ToString();
        }

        private StringBuilder LongestCommonPrefix(Node node, StringBuilder sb)
        {
            foreach (var child in node.GetChildren())
            {
                sb.Append(child.Value);
                var children = child.GetChildren();

                if (children == null || children.Count() > 1 || child.IsEndofWord)
                    return sb;

                sb = LongestCommonPrefix(child, sb);
            }

            return sb;
        }

        #region Private  Methods
        private void AutoComplete(Node node, StringBuilder sb, List<string> wordList)
        {
            if (node.IsEndofWord)
                wordList.Add(sb.ToString());

            foreach (var child in node.GetChildren())
            {
                var childNode = node.GetCharNode(child.Value);
                sb.Append(childNode.Value);
                AutoComplete(childNode, sb, wordList);
                sb.Remove(sb.Length - 1, 1);
            }
        }

        private void Remove(Node node, string word, int index)
        {
            if (index == word.Length && node.IsEndofWord)
            {
                node.IsEndofWord = false;
                return;
            }

            var childNode = node.GetCharNode(word[index++]);

            if (childNode == null)
                return;

            Remove(childNode, word, index);

            if (!childNode.HasChildren() && !childNode.IsEndofWord)
                node.RemoveChild(childNode.Value);
        }

        private void PreOrderTraversal(Node node)
        {
            Console.WriteLine(node.Value);
            foreach (var child in node.GetChildren())
            {
                PreOrderTraversal(child);
            }
        }

        private bool ContainsRecursive(Node node, string word, int index)
        {
            if (index == word.Length)
                return node.IsEndofWord;

            if (!node.ContainsKey(word[index]))
                return false;

            var childNode = node.GetCharNode(word[index]);
            return ContainsRecursive(childNode, word, ++index);
        }

        private int CountWords(Node node, int count)
        {
            foreach (var child in node.GetChildren())
            {
                if (child.IsEndofWord)
                    count++;

                count = CountWords(child, count);
            }
            return count;
        }
        #endregion
        public class Node
        {
            public Node(string value)
            {
                if (value.Length > 1)
                    throw new ArgumentException("Invalid character");

                if (value.Length == 1)
                    Value = value[0];
            }
            public Node(char value)
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentException("Invalid character");

                Value = value;
            }
            public char Value { get; set; }
            public Dictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>();
            public bool IsEndofWord { get; set; }

            public bool ContainsKey(char ch)
            {
                return Children.ContainsKey(ch);
            }

            public Node GetCharNode(char ch)
            {
                return Children.GetValueOrDefault(ch);
            }

            public void AddNode(Node node)
            {
                Children.Add(node.Value, node);
            }

            public IEnumerable<Node> GetChildren()
            {
                return Children.ToList().Select(i => i.Value);
            }

            public bool HasChildren()
            {
                return this.Children.Count > 0;
            }

            public void RemoveChild(char ch)
            {
                Children.Remove(ch);
            }
        }
    }
}