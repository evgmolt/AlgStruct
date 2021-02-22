using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zigzag
{
    public class ChainLink
    {
        public ChainLink NextChainLink;

        private int sizeOfQ;
        public Queue<int> queueTop;
        public Queue<int> queueBot;
        public int CommonPoint;
        
        private void FillQueue(Queue<int> q, int fill)
        {
            for (int i = 0; i < sizeOfQ; i++)
            {
                q.Enqueue(fill);
            }
        }
        public ChainLink(int size, int fill)
        {
            sizeOfQ = size;
            queueTop = new Queue<int>();
            queueBot = new Queue<int>();
            FillQueue(queueTop, fill); //заполнение очередей для наглядности
            FillQueue(queueBot, fill + 1);
        }
        public void AddToTop(int val)
        {
            queueTop.Enqueue(val);
            NextChainLink?.AddToBot(CommonPoint);
            CommonPoint = queueTop.Dequeue();
        }

        public void AddToBot(int val)
        {
            queueBot.Enqueue(val);
            NextChainLink?.AddToTop(CommonPoint);
            CommonPoint = queueBot.Dequeue();
        }
    }
}
