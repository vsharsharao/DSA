namespace LinkedLists
{
    public class Node<T>
    {
        internal Node(T value)
        {
            Value = value;
        }
        internal T Value;
        internal Node<T> Next;
    }
}