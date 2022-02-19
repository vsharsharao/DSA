namespace DSA.Excercises.Trees
{
    public interface ITree
    {
        public INode Root { get; set; }
        public void Insert(int value);
    }
}