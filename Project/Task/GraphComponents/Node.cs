using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphComponents
{
    public class Node<nodeT, edgeT>
    {
        public nodeT Value { get; set; }

        private List<Edge<nodeT, edgeT>> Edges = new List<Edge<nodeT, edgeT>>();

        private static int Count = 1;

        public Node<nodeT, edgeT> AddNode(edgeT weight, nodeT value)
        {
            var node = new Node<nodeT, edgeT> { Value = value };

            var edge = new Edge<nodeT, edgeT> { NextNode = node, Weight = weight };

            if (Edges.Contains(edge))
                throw new Exception($"Edge with weight {weight} already exists.");

            Edges.Add(edge); Count++;

            return node;
        }
        public Node<nodeT, edgeT> AddNode(edgeT weight, Node<nodeT, edgeT> node)
        {
            var edge = new Edge<nodeT, edgeT> { NextNode = node, Weight = weight };

            if(Edges.Contains(edge))
                throw new Exception($"Edge with weight {weight} already exists.");

            Edges.Add(edge);

            if(tryFindBFS(node.Value) == null)
                Count++;

            return node;
        }

        public bool DelEdge(edgeT weight)
        {
            var edgeToDel = new Edge<nodeT, edgeT> { Weight = weight };

            if (Edges.Contains(edgeToDel))
            {
                var edge = Edges.Find(item => item.Weight.Equals(weight));

                Edges.Remove(edge);

                return true;
            }

            return false;
        }

        public Node<nodeT, edgeT> tryFindDFS(nodeT value)
        {
            return tryFindDFS(new HashSet<Node<nodeT, edgeT>>(), new Stack<Node<nodeT, edgeT>>(), value);
        }
        private Node<nodeT, edgeT> tryFindDFS(HashSet<Node<nodeT, edgeT>> hs, Stack<Node<nodeT, edgeT>> stack, nodeT value)
        {
            Node<nodeT, edgeT> toFind = null;

            hs.Add(this); stack.Push(this);

            var enumerator = Edges.GetEnumerator(); enumerator.MoveNext();

            if (Value.Equals(value))
                return this;

            if (hs.Count == Count)
                return null;

            for (int i = 0; i < Edges.Count; i++)
            {
                if (enumerator.Current == null)
                    break;

                if (!hs.Contains(enumerator.Current.NextNode))
                    toFind = enumerator.Current.NextNode.tryFindDFS(hs, stack, value);
            }
            stack.Pop();

            if (toFind == null)
            {
                return null;
            }
            else { return toFind; }
        }

        public Node<nodeT, edgeT> tryFindBFS(nodeT value)
        {
            var hs = new HashSet<Node<nodeT, edgeT>>(); hs.Add(this);

            var queue = new Queue<Node<nodeT, edgeT>>(); queue.Enqueue(this);

            return tryFindBFS(hs, queue, value);
        }

        private Node<nodeT, edgeT> tryFindBFS(HashSet<Node<nodeT, edgeT>> hs, Queue<Node<nodeT, edgeT>> queue, nodeT value)
        {
            var enumerator = Edges.GetEnumerator(); enumerator.MoveNext();

            if (Value.Equals(value))
                return this;

            if (hs.Count == Count)
                return null;

            for (int i = 0; i < hs.Count; i++)
            {
                if (enumerator.Current == null)
                    break;

                if (!hs.Contains(enumerator.Current.NextNode))
                {
                    hs.Add(enumerator.Current.NextNode); queue.Enqueue(enumerator.Current.NextNode);
                }

                enumerator.MoveNext();
            }
            queue.Dequeue();

            var toFind = queue.First().tryFindBFS(hs, queue, value);

            if (toFind == null)
            {
                return null;
            }
            else { return toFind; }

        }

        public void DFSEnum()
        {
            DFSEnum(new HashSet<Node<nodeT, edgeT>>(), new Stack<Node<nodeT, edgeT>>());
        }

        private void DFSEnum(HashSet<Node<nodeT, edgeT>> hs, Stack<Node<nodeT, edgeT>> stack)
        {
            var enumerator = Edges.GetEnumerator(); enumerator.MoveNext();

            stack.Push(this); hs.Add(this);

            for (int i = 0; i < Edges.Count; i++)
            {
                if (enumerator.Current == null)
                    break;

                if (!hs.Contains(enumerator.Current.NextNode))
                    enumerator.Current.NextNode.DFSEnum(hs, stack);

                enumerator.MoveNext();
            }
            Console.WriteLine(stack.Pop().Value);
        }

        public void BFSEnum()
        {
            var hs = new HashSet<Node<nodeT, edgeT>>(); hs.Add(this);

            var queue = new Queue<Node<nodeT, edgeT>>(); queue.Enqueue(this);

            BFSEnum(hs, queue);
        }
        private void BFSEnum(HashSet<Node<nodeT, edgeT>> hs, Queue<Node<nodeT, edgeT>> queue)
        {
            var enumerator = Edges.GetEnumerator(); enumerator.MoveNext();

            for (int i = 0; i < Edges.Count; i++)
            {
                if (enumerator.Current == null)
                    break;

                if (!hs.Contains(enumerator.Current.NextNode))
                {
                    queue.Enqueue(enumerator.Current.NextNode); hs.Add(enumerator.Current.NextNode);
                }
                enumerator.MoveNext();
            }
            Console.WriteLine(queue.Dequeue().Value);

            if (queue.Count > 0)
                queue.First().BFSEnum(hs, queue);
        }
        public override int GetHashCode()
        {
            int val = Value.GetHashCode();

            var edges = Edges.GetEnumerator();

            int sumOfEdgeVal = 0;

            for (int i = 0; i < Edges.Count; i++)
            {
                edges.MoveNext();

                sumOfEdgeVal += edges.Current.Weight.GetHashCode();
            }

            return val + sumOfEdgeVal;
        }
        public override bool Equals(object obj)
        {
            obj = obj as Node<nodeT, edgeT>;

            return GetHashCode() == obj.GetHashCode();
        }
    }
}
