 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearch
{
    class Program
    {
        static Node CreateGraph()
        {
            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);
            var n5 = new Node(5);
            var n6 = new Node(6);
            var n7 = new Node(7);
            var n8 = new Node(8);
            n1.AddChild(n2, false);
            n2.AddChild(n4, false);
            n1.AddChild(n3);
            n1.AddChild(n5);
            n5.AddChild(n6);
            n6.AddChild(n4, false);
            n6.AddChild(n7);
            n7.AddChild(n8, false);
            n8.AddChild(n5);
            return n1;
        }

        static void ShowQueue(Queue<Node> q)
        {
            Console.Write("\tQueue : ");
            foreach (var v in q)
            {
                Console.Write(v.Value.ToString() + " ");
            }
            Console.WriteLine();
        }

        static void ShowStack(Stack<Node> s)
        {
            Console.WriteLine("\tStack : ");
            foreach (var v in s)
            {
                Console.WriteLine($"\t{v.Value}");
            }
            Console.WriteLine();
        }

        static Node BFS(Node node, int val)
        {
            Node n;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            Console.WriteLine($"Enqueue {node.Value}");
            while (q.Count != 0)
            {
                n = q.Dequeue();
                Console.WriteLine($"Dequeue {n.Value}");
                ShowQueue(q);
                if (n.Value.Equals(val))
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Found: {n.Value}");
                    Console.WriteLine("");
                    ShowQueue(q);
                    return n;
                }
                for (int i = 0; i < n.Children.Count; i++)
                {
                    if (!n.Children[i].Visited)
                    {
                        n.Children[i].Visited = true;
                        q.Enqueue(n.Children[i]);
                        Console.WriteLine($"Enqueue {n.Children[i].Value}");
                    }
                }
            }
            Console.WriteLine("Not found");
            ShowQueue(q);
            return null;
        }


        static Node DFS(Node node, int val)
        {
            Node n;
            Stack<Node> s = new Stack<Node>();
            s.Push(node);
            node.Visited = true;
            Console.WriteLine($"Push {node.Value}");
            while (s.Count != 0)
            {
                n = s.Pop();
                Console.WriteLine($"Pop {n.Value}");
                if (n.Value.Equals(val))
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Found: {n.Value}");
                    Console.WriteLine("");
                    ShowStack(s);
                    return n;
                }
                for (int i = 0; i < n.Children.Count; i++)
                {
                    if (!n.Children[i].Visited)
                    {
                        n.Children[i].Visited = true;
                        s.Push(n.Children[i]);
                        Console.WriteLine($"Push {n.Children[i].Value}");
                    }
                }
                ShowStack(s);
            }
            Console.WriteLine("Not found");
            return null;
        }


        static void Main(string[] args)
        {
            Node head = CreateGraph();
            DFS(head, 7);
            Console.WriteLine("Press any key");
            Console.ReadKey();
            head = CreateGraph();
            BFS(head, 6);
            Console.ReadKey();
        }
    }
}
