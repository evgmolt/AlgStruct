using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
    class Program
    {
        static readonly int NumOfNodes = 6;
        static void Main()
        {
            int h = Console.LargestWindowHeight;
            int w = Console.LargestWindowWidth;
            Console.WindowHeight = h - h / 10;
            Console.WindowWidth = w - w / 10;

            BinaryTree BTree = new BinaryTree();
//            Random rand = new Random();
            //            for (int i = 0; i < NumOfNodes; i++)
            //                BTree.AddNode((int)(rand.NextDouble() * 100));
            BTree.AddNode(70);
            BTree.AddNode(60);
            BTree.AddNode(170);
            BTree.AddNode(30);
            BTree.AddNode(140);
            BTree.AddNode(130);
            BTree.AddNode(50);
            BTree.AddNode(190);
            BTree.AddNode(150);
            Node<int> n = BTree.SearchNode(130);
            string s = n?.Data.ToString() ?? "null";
            Console.WriteLine("Найдено: " + s);
            Console.WriteLine($"Удаление " + n.ToString());
            BTree.RemoveNode(130);
            n = BTree.SearchNode(130);
            s = n?.Data.ToString() ?? "null";
            Console.WriteLine("Найдено: " + s);

            Console.WriteLine($"Высота дерева : {BTree.GetTreeHeight(BTree.Head)}");
            BTree.ShowTree(BTree.Head);
            Console.ReadKey();
        }
    }
}
