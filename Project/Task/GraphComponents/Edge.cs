namespace GraphComponents
{
    internal class Edge<edgeT, nodeT>
    {
        public nodeT Weight { get; set; }

        public Node<edgeT,nodeT> NextNode = new Node<edgeT,nodeT>();

        public override int GetHashCode()
        {
            return Weight.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            obj = obj as Edge<edgeT, nodeT>;

            return obj.GetHashCode() == GetHashCode();
        }
    }
}
