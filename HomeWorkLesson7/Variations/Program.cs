using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variations
{
    class Program
    {
        static readonly int bSize = 7;
        static int[,] resultBuffer = new int[bSize, bSize];

        static int GetCombination(int k, int n)
        {
            if (k == 0)
                return 1;
            if (k == n)
                return 1;
            if (k >= 0 && n >= 0)
            {
                if (resultBuffer[k, n] > 0)
                    return resultBuffer[k, n];
            }
            var res = GetCombination(k - 1, n - 1) + GetCombination(k - 1, n);
            if (k >= 0 && n >= 0)
            {
                resultBuffer[k, n] = res;
            }
            return res;
        }

        static void ShowBuffer(int[,] arr)
        {
            int i, j;
            for (i = 0; i < bSize; i++)
            {
                for (j = 0; j < i + 1; j++)
                    Console.Write($"{arr[i, j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < bSize; i++)
            {
                resultBuffer[0, i] = 1;
                resultBuffer[i, 0] = 1;
                resultBuffer[i, i] = 1;
            }
            for (int i = 0; i < bSize; i++)
            {
                for (int j = 0; j < bSize; j++)
                {
                    GetCombination(i, j);
                }
            }
            ShowBuffer(resultBuffer);
            Console.ReadKey();
        }
    }
}
