using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadth_Deep
{
    class Program
    {
        static void ShowQueue(Queue<Node<int>> q)
        {
            Console.Write("\tQueue : ");
            foreach (var v in q)
            {
                Console.Write(v.Data.ToString() + " ");
            }
            Console.WriteLine();
        }
        static void ShowStack(Stack<Node<int>> s)
        {
            Console.WriteLine("\tStack : ");
            foreach (var v in s)
            {
                Console.WriteLine($"\t{v.Data}");
            }
            Console.WriteLine();
        }
        static Node<int> BFS(Node<int> node, int val)
        {
            Node<int> n;
            Queue<Node<int>> q = new Queue<Node<int>>();
            q.Enqueue(node);
            Console.WriteLine($"Enqueue {node.Data}");
            while (q.Count != 0)
            {
                n = q.Dequeue();
                Console.WriteLine($"Dequeue {n.Data}");
                ShowQueue(q);
                if (n.Data.Equals(val))
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Found: {n.Data}");
                    Console.WriteLine("");
                    ShowQueue(q);
                    return n;
                }
                if (n.Left != null)
                {
                    q.Enqueue(n.Left);
                    Console.WriteLine($"Enqueue {n.Data}");
                    ShowQueue(q);
                }
                if (n.Right != null)
                {
                    q.Enqueue(n.Right);
                    Console.WriteLine($"Enqueue {n.Data}");
                    ShowQueue(q);
                }
            }
            Console.WriteLine("Not found");
            ShowQueue(q);
            return null;
        }

        static Node<int> DFS(Node<int> node, int val)
        {
            Node<int> n;
            Stack<Node<int>> s = new Stack<Node<int>>();
            s.Push(node);
            Console.WriteLine($"Push {node.Data}");
            while (s.Count != 0)
            {
                n = s.Pop();
                Console.WriteLine($"Pop {n.Data}");
                ShowStack(s);
                if (n.Data.Equals(val))
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Found: {n.Data}");
                    Console.WriteLine("");
                    ShowStack(s);
                    return n;
                }
                if (n.Left != null)
                {
                    s.Push(n.Left);
                    Console.WriteLine($"Push {n.Data}");
                    ShowStack(s);
                }
                if (n.Right != null)
                {
                    s.Push(n.Right);
                    Console.WriteLine($"Push {n.Data}");
                    ShowStack(s);
                }
            }
            Console.WriteLine("Not found");
            ShowStack(s);
            return null;
        }

        static void Main()
        {
            int h = Console.LargestWindowHeight;
            int w = Console.LargestWindowWidth;
            Console.WindowHeight = h - h / 10;
            Console.WindowWidth = w - w / 10;
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            BinaryTree bTree = new BinaryTree();
            bTree.AddNode(70);
            bTree.AddNode(60);
            bTree.AddNode(170);
            bTree.AddNode(30);
            bTree.AddNode(140);
            bTree.AddNode(130);
            bTree.AddNode(50);
            bTree.AddNode(190);
            bTree.AddNode(150);
            bTree.ShowTree(bTree.Head);
            BFS(bTree.Head, 140);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            DFS(bTree.Head, 140);
            Console.ReadKey();
        }
    }
}
