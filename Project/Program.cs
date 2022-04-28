using TreeStructure;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree tree = Tree.GenTree();

            EnumerateBinaryTree.BFS(tree); EnumerateBinaryTree.BFS(tree);
        }
    }
}
