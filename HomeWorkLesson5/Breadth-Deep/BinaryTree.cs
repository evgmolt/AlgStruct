using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadth_Deep
{

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
    }

    public class BinaryTree
    {
        public Node<int> Head;

        public Node<int> GetNode(Node<int> parent, int data)
        {
            var newNode = new Node<int>
            {
                Data = data,
                Parent = parent
            };
            return newNode;
        }

        public int GetTreeHeight(Node<int> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(GetTreeHeight(node.Left), GetTreeHeight(node.Right));
            }
        }


        private void ShowFrame(int num, int interval)
        {
            string sL = "|";
            string sR = "|";
            char cLine = '_';
            string s = String.Empty;
            string s1;

            for (int i = 0; i < num; i++)
            {
                s = String.Empty;
                s1 = String.Empty;
                s = s.PadLeft(interval - interval / 2);
                s1 = s1.PadRight(interval - 1, cLine);
                Console.Write(s + s1 + s);
            }
            Console.WriteLine();
            for (int i = 0; i < num; i++)
            {
                s = string.Empty;
                s = s.PadLeft(interval - 1 - interval / 2);
                s1 = sL;
                s1 = s1.PadRight(interval) + sR;
                Console.Write(s + s1 + s);
            }
            Console.WriteLine();
        }

        private void ShowNodes(List<Node<int>> nodesL, int interval)
        {
            string s = String.Empty;
            string s1 = String.Empty;
            for (int i = 0; i < nodesL.Count; i++)
            {
                s = string.Empty;
                s = s.PadLeft(interval - 2  - interval / 2);
                string sData = nodesL[i]?.Data.ToString() ?? "  ";
                s1 = "[" + sData + "]";
                Console.Write(s + s1 + s);
            }
            Console.WriteLine();
        }
        public void ShowTree(Node<int> head)
        {
            int Center = Console.WindowWidth / 2;
            string OutS;
            List<Node<int>> nodesList = new List<Node<int>>();
            List<Node<int>> nodesListNext = new List<Node<int>>();
            if (head != null)
            {
                int H = GetTreeHeight(Head);
                nodesList.Add(Head);
                OutS = "["+Head.Data.ToString()+"]";
                OutS = OutS.PadLeft(Center);
                Console.WriteLine(OutS);
                for (int i = 1; i < H; i++ )
                {
                    ShowFrame((int)Math.Pow(2, i - 1), Center / (int)Math.Pow(2, i - 1));
                    for (int j = 0; j < nodesList.Count; j++)
                    {
                        nodesListNext.Add(nodesList[j]?.Left);
                        nodesListNext.Add(nodesList[j]?.Right);
                    }
                    ShowNodes(nodesListNext, Center / (int)Math.Pow(2, i - 1));
                    nodesList.Clear();
                    nodesList.AddRange(nodesListNext);
                    nodesListNext.Clear();
                }
            }
        }

        public Node<int> SearchNode(Node<int> node, int data)
        {
            if (node == null) return null;
            switch (data.CompareTo(node.Data))
            {
                case 1: return SearchNode(node.Right, data);
                case -1: return SearchNode(node.Left, data);
                case 0: return node;
                default: return null;
            }
        }

        public Node<int> SearchNode(int data)
        {
            return SearchNode(Head, data);
        }

        public bool RemoveNode(int data)
        {
            Node<int> nodeForRemove = SearchNode(data);
            if (nodeForRemove == null) return false;

            Node<int> curNode;
            if (nodeForRemove == Head)
            {
                curNode = nodeForRemove?.Right ?? nodeForRemove.Left;
                while (curNode.Left != null) curNode = curNode.Left;
                int tmp = curNode.Data;
                RemoveNode(tmp);
                nodeForRemove.Data = tmp;
                return true;
            }
            //                                                                                                                O
            if (nodeForRemove.Left == null && nodeForRemove.Right == null && nodeForRemove.Parent != null)
            {
                if (nodeForRemove == nodeForRemove.Parent.Left)
                {
                    nodeForRemove.Parent.Left = null;
                }
                else
                {
                    nodeForRemove.Parent.Right = null;
                }
            }
            //                                                                  O
            if (nodeForRemove.Left != null && nodeForRemove.Right == null)//   /
            {
                nodeForRemove.Left.Parent = nodeForRemove.Parent;
                if (nodeForRemove == nodeForRemove.Parent.Left)
                {
                    nodeForRemove.Parent.Left = nodeForRemove.Left;
                }
                else if (nodeForRemove == nodeForRemove.Parent.Right)
                {
                    nodeForRemove.Parent.Right = nodeForRemove.Left;
                }
                return true;
            }
            //                                                                  O
            if (nodeForRemove.Left == null && nodeForRemove.Right != null)//     \
            {
                nodeForRemove.Right.Parent = nodeForRemove.Parent;
                if (nodeForRemove == nodeForRemove.Parent.Left)
                {
                    nodeForRemove.Parent.Left = nodeForRemove.Right;
                }
                else if (nodeForRemove == nodeForRemove.Parent.Right)
                {
                    nodeForRemove.Parent.Right = nodeForRemove.Right;
                }
                return true;
            }
            //                                                                  O
            if (nodeForRemove.Right != null && nodeForRemove.Left != null)//   / \
            {
                curNode = nodeForRemove.Right;
                while (curNode.Left != null)
                {
                    curNode = curNode.Left;
                }
                if (curNode.Parent == nodeForRemove)
                {
                    curNode.Left = nodeForRemove.Left;
                    nodeForRemove.Left.Parent = curNode;
                    curNode.Parent = nodeForRemove.Parent;
                    if (nodeForRemove == nodeForRemove.Parent.Left)
                    {
                        nodeForRemove.Parent.Left = curNode;
                    }
                    else if (nodeForRemove == nodeForRemove.Parent.Right)
                    {
                        nodeForRemove.Parent.Right = curNode;
                    }
                    return true;
                }
                else
                {
                    if (curNode.Right != null)
                    {
                        curNode.Right.Parent = curNode.Parent;
                    }
                    curNode.Parent.Left = curNode.Right;
                    curNode.Right = nodeForRemove.Right;
                    curNode.Left = nodeForRemove.Left;
                    nodeForRemove.Left.Parent = curNode;
                    nodeForRemove.Right.Parent = curNode;
                    curNode.Parent = nodeForRemove.Parent;
                    if (nodeForRemove == nodeForRemove.Parent.Left)
                    {
                        nodeForRemove.Parent.Left = curNode;
                    }
                    else if (nodeForRemove == nodeForRemove.Parent.Right)
                    {
                        nodeForRemove.Parent.Right = curNode;
                    }
                    return true;
                }
            }
            return false;
        }
        
        public Node<int> AddNode(int data)
        {
            Node<int> tmpN = Head;
            if (Head == null)
            {
                Head = GetNode(null, data);
                return Head;
            }
            tmpN = Head;
            while (tmpN != null)
            {
                if (data > tmpN.Data)
                {
                    if (tmpN.Right != null)
                    {
                        tmpN = tmpN.Right;
                        continue;
                    }
                    else
                    {
                        tmpN.Right = GetNode(tmpN, data);
                        return Head;
                    }
                }
                else if (data <= tmpN.Data)
                {
                    if (tmpN.Left != null)
                    {
                        tmpN = tmpN.Left;
                        continue;
                    } 
                    else
                    {
                        tmpN.Left = GetNode(tmpN, data);
                        return Head;
                    }
                }
                else
                {
                    return Head;
                }

            }
            return Head;
        }
    }
}
