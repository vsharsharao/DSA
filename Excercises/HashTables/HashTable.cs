using System;
using System.Collections.Generic;

namespace HashTables
{
    public class HashTable
    {
        private class KeyValuePair
        {
            public KeyValuePair(int key, string value)
            {
                Key = key;
                Value = value;
            }

            public int Key { get; set; }

            public string Value { get; set; }
        }

        private LinkedList<KeyValuePair>[] _array { get; set; }

        private readonly int Size = 5;

        public string this[int index]
        {
            get
            {
                return Get(index);
            }
            set
            {
                Add (index, value);
            }
        }

        public HashTable()
        {
            _array = new LinkedList<KeyValuePair>[Size];
        }

        public void Add(int key, string value)
        {
            int hash = GetHashValue(key);

            if (_array[hash] == null)
                _array[hash] = new LinkedList<KeyValuePair>();

            var bucket = _array[hash];

            foreach (var item in bucket)
            {
                if (item.Key == key)
                {
                    item.Value = value;
                    return;
                }
            }

            bucket.AddLast(new KeyValuePair(key, value));
        }

        public void Remove(int key)
        {
            var bucket = GetBucket(key);
            if (bucket != null)
            {
                var node = GetKeyValuePair(key);
                bucket.Remove (node);
            }
            else
                throw new InvalidOperationException();
        }

        public string Get(int key)
        {
            var bucket = GetBucket(key);
            if (bucket != null) return GetKeyValuePair(key).Value.Value;

            return null;
        }

        private int GetHashValue(int key)
        {
            return key % Size - 1;
        }

        private LinkedList<KeyValuePair> GetBucket(int key)
        {
            int hash = GetHashValue(key);
            return _array[hash];
        }

        private LinkedListNode<KeyValuePair> GetKeyValuePair(int key)
        {
            var bucket = GetBucket(key);
            if (bucket != null)
            {
                var llNode = bucket;
                for (var node = llNode.First; node != null; node = node.Next)
                {
                    if (node.Value.Key == key)
                    {
                        return node;
                    }
                }
            }
            return null;
        }
    }
}
