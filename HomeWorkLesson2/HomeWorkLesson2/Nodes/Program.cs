using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes
{
    class Program
    {
        static readonly int ArrSize = 10;
        static void Main()
        {
            int[] TestArray = new int[ArrSize];
            var linkedList = new LinkedList();
            for (int i = 0; i < TestArray.Length; i++)
            {
                linkedList.AddNode(i * 10);
            }
            linkedList.ShowList();
            var prevNode = linkedList.FindNode(30);
            linkedList.AddNodeAfter(prevNode, 1000);
            linkedList.ShowList();
            linkedList.RemoveNode(0);
            linkedList.ShowList();
            linkedList.RemoveNode(linkedList.FindNode(80));
            linkedList.ShowList();
            Console.ReadKey();
        }
    }
}
