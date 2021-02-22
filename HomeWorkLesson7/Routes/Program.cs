using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routes
{
    class Program
    {
        static int bSize = 5;
        static int[,] resultBuffer = new int[bSize, bSize];
        static int[,] forbiddenBuffer = new int[bSize, bSize];

         static void ShowBuffer(int[,] arr)
        {
            int i, j;
            for (i = 0; i < bSize; i++)
            {
                for (j = 0; j < bSize; j++)
                    Console.Write($"{arr[i, j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void FillBuffer()
        {
            {
                int i, j;
                for (j = 0; j < bSize; j++)
                    resultBuffer[0, j] = (forbiddenBuffer[0, j] == 0) ? 1 : 0; 
                for (i = 1; i < bSize; i++)
                {
                    resultBuffer[i, 0] = (forbiddenBuffer[i, 0] == 0) ? 1 : 0;
                    for (j = 1; j < bSize; j++)
                    {
                        resultBuffer[i, j] = (forbiddenBuffer[i, j] == 0)? resultBuffer[i, j - 1] + resultBuffer[i - 1, j] : 0;
                    }
                }
            }
        }

        static void Main()
        {
            forbiddenBuffer[2, 4] = 1;
            forbiddenBuffer[0, 2] = 1;
            forbiddenBuffer[3, 2] = 1;
            forbiddenBuffer[2, 0] = 1;
            FillBuffer();
            Console.WriteLine("Запрещенные клетки помечены [1]");
            ShowBuffer(forbiddenBuffer);
            Console.WriteLine("Результат :");
            ShowBuffer(resultBuffer);
            Console.ReadKey();
        }
    }
}
