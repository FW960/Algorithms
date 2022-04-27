using NodesInterface;
namespace LinkedListNode
{
    public class Node : ILinkedList
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public void AddNode(int value)
        {
            Node newNode = new Node { Value = value };

            this.NextNode = newNode;

            this.NextNode.PrevNode = this;
        }

        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node { Value = value };

            Node nextItem = node;

            node.PrevNode.NextNode = newNode;

            newNode.PrevNode = node.PrevNode;

            newNode.NextNode = nextItem;

            nextItem.PrevNode = newNode;
        }
        public Node FindNode(int searchValue)
        {
            Node newNode = this;

            while (newNode != null)
            {
                if (newNode.Value == searchValue)
                {
                    return newNode;
                }
                newNode = newNode.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            Node node = this.NextNode;

            int count = 1;

            while (node != null)
            {
                count++;

                node = node.NextNode;
            }

            return count;
        }

        public void RemoveNode(int index)
        {
            int count = 0;

            Node node = this;

            if (index == 0)
            {
                node = node.NextNode;

                this.Value = node.Value;

                this.NextNode = node.NextNode;

                this.NextNode.PrevNode = this.PrevNode;

                while (true)
                {
                    if (node.NextNode == null)
                    {
                        while (true)
                        {
                            if (node.PrevNode == null)
                            {
                                node.PrevNode = this;

                                return;
                            }
                            node = node.PrevNode;
                        }
                    }

                    node = node.NextNode;
                }
            }

            while (true)
            {
                if (index == count)
                {
                    node.PrevNode.NextNode = node.NextNode;

                    if (node.NextNode != null)
                        node.NextNode.PrevNode = node.PrevNode;

                    return;
                }
                node = node.NextNode;
                count++;
            }

        }
        public void RemoveNode(Node node)
        {
            Node toDeleteNode = this;

            int count = 0;

            while (true)
            {
                if (node == toDeleteNode)
                {
                    RemoveNode(count);

                    return;
                }
                count++;
                toDeleteNode = toDeleteNode.NextNode;

            }
        }
    }
}
