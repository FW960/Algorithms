using System;
using System.Collections.Generic;
using System.Linq;
using TreeStructure;

internal class EnumerateBinaryTree
{
    public static void BFS(Tree tree)
    {
        var queue = new Queue<Tree>(); queue.Enqueue(tree);

        BFS(queue);
    }
    public static void BFS(Queue<Tree> queue)
    {

        if(queue.Count == 0)
            return;

        if (queue.First().LeftBranch != null)
            queue.Enqueue(queue.First().LeftBranch);

        if (queue.First().RightBranch != null)
            queue.Enqueue(queue.First().RightBranch);

        Console.WriteLine(queue.Dequeue().Value);

        BFS(queue);
    }

    public static void DFS(Tree tree)
    {
        var stack = new Stack<Tree>(); stack.Push(tree);

        DFS(stack);
    }

    private static void DFS(Stack<Tree> stack)
    {
        if (stack.First().LeftBranch != null)
        {
            stack.Push(stack.First().LeftBranch);
            DFS(stack);
        }
        if (stack.First().RightBranch != null)
        {
            stack.Push(stack.First().RightBranch);
            DFS(stack);
        }
        Console.WriteLine(stack.Pop().Value);
    }
}
