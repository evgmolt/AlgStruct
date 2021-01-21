using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes
{
    public class LinkedList : ILinkedList
    {
        private int count;
        private Node startNode;
        private Node endNode;

        public void AddNode(int value)
        {
            if (startNode == null)
            {
                startNode = new Node { Value = value };
                endNode = startNode;
            }
            else
            {
                var newNode = new Node { Value = value };
                endNode.NextNode = newNode;
                newNode.PrevNode = endNode;
                endNode = newNode;
            }
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            newNode.NextNode = node.NextNode;
            newNode.PrevNode = node;
            node.NextNode.PrevNode = newNode;
            node.NextNode = newNode;
            count++;
        }

        public Node FindNode(int searchValue)
        {
            var node = startNode;
            do
            {
                if (node.Value == searchValue)
                {
                    return node;
                }
                else
                {
                    node = node.NextNode;
                }
            }
            while (node.NextNode != null);
            return null;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            count--;
            if (index == 0)
            {
                startNode = startNode.NextNode;
                startNode.PrevNode = null;
                return;
            }
            var node = startNode;
            int i = 0;
            do
            {
                node = node.NextNode;
                i++;
            }
            while (i != index || node.NextNode == null);
            node.NextNode.PrevNode = node.PrevNode;
            node.PrevNode.NextNode = node.NextNode;
        }

        public void RemoveNode(Node node)
        {
            count--;
            if (node == startNode)
            {
                startNode = startNode.NextNode;
                startNode.PrevNode = null;
                return;
            }
            node.NextNode.PrevNode = node.PrevNode;
            node.PrevNode.NextNode = node.NextNode;
        }

        public void ShowList()
        {
            if (startNode == null) return;
            Node n = startNode;
            int i = 0;
            do
            {
                Console.Write($"{n.Value}\t");
                n = n.NextNode;
                i++;
            }
            while (n.NextNode != null);
            Console.Write($"{n.Value}\tCount:{count}");
            Console.WriteLine();
        }
    }
}
