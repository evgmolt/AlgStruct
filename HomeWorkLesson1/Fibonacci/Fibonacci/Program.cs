using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{

    class Program
    {
        static int numOfCalls;
        static long FibRecurs(int n)
        {
            numOfCalls++;
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;
            return FibRecurs(n - 1) + FibRecurs(n - 2);
        }

        static long FibCircle(int n)
        {
            long a = 0;
            long b = 1;
            for (int i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }


        static void Main()
        {
            Console.Write("Введите число : ");
            if (!Int32.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Ошибка ввода. Введите число.");
                Console.ReadKey();
                return;
            };
            Console.WriteLine($"Число Фибоначчи для {num} : {FibRecurs(num)}, рекурсивно");
            Console.WriteLine($"Число рекурсивных вызовов : {numOfCalls}");
            Console.WriteLine($"Число Фибоначчи для {num} : {FibCircle(num)}, нерекурсивно (цикл)");
            Console.ReadKey();
        }
    }

}
