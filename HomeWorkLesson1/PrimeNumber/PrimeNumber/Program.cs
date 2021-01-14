using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    class Program
    {
        static string strPrimeNum = "Простое число";
        static string strNoPrimeNum = "Непростое число";

        static bool IsPrime(int number)
        {
            int d = 0;
            for (int i = 2; i < number; i++)
                if (number % i == 0)
                    d++;
            return d == 0;
        }
        static void Main()
        {
            int num = 1;
            do
            {
                Console.Write("Введите число, 0 для выхода : ");
                if (!Int32.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Ошибка ввода. Введите число.");
                    num = 1;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(IsPrime(num) ? strPrimeNum : strNoPrimeNum);
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (num != 0);
        }
    }
}
