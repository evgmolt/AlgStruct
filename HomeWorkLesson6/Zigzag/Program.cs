using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zigzag
{
    class Program
    {
        static readonly int chainLength = 3;//Длина цепочки
        static readonly int capacity = 5;//Длина очереди в одном звене. Общий элемент не входит.

        static string QueueToString(Queue<int> parq)
        {
            string s = "";
            int[] arr = parq.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                s += arr[arr.Length - i -1].ToString() + " ";
            }
            return s;
        }

        static void ShowChain(ChainLink parent)
        {
            ChainLink p = parent;
            string s1 = String.Empty;
            string s2 = String.Empty;
            string s3 = String.Empty;
            while (p.NextChainLink != null)
            {
                string curQstr = QueueToString(p.queueTop);
                s1 += curQstr;
                s1 += "   ";
                string s = p.CommonPoint.ToString();
                s2 += s.PadLeft(curQstr.Length + 2);
                p = p.NextChainLink;
            }
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            p = parent;
            while (p.NextChainLink != null)
            {
                s3 += QueueToString(p.queueBot);
                s3 += "   ";
                p = p.NextChainLink;
            }
            Console.WriteLine(s3);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ChainLink parentChainLink = new ChainLink(capacity, 100);
            ChainLink prevChainLink = parentChainLink;
            for (int i = 0; i < chainLength; i++)
            {
                ChainLink nextChainLink = new ChainLink(capacity, i);
                prevChainLink.NextChainLink = nextChainLink;
                prevChainLink = nextChainLink;
            }
            ShowChain(parentChainLink);
            Console.Write("Введите число. Четные добавляются в верхнюю ветку, нечетные - в нижнюю. ");
            int num = 1;
            while (num != 0)
            {
                if (!Int32.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Ошибка ввода. Введите число.");
                    Console.ReadKey();
                    num = 1;
                };
                if (num % 2 == 0)
                {
                    parentChainLink.AddToTop(num);
                }
                else
                {
                    parentChainLink.AddToBot(num);
                }
                ShowChain(parentChainLink);
            }
        }
    }
}
