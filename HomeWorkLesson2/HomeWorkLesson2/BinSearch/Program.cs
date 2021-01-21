using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearch
{
    class Program
    {
        static readonly int ArrSize = 100;

        static void Main()
        {
            var rand = new Random();
            byte[] TestArray = new byte[ArrSize];
            rand.NextBytes(TestArray);
            Array.Sort(TestArray);
            Console.Write("Введите число : ");
            if (!Int32.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Ошибка ввода. Введите число.");
                Console.ReadKey();
                return;
            };
            int res = BinarySearch(TestArray, num);
            string mess = (res > 0) ? $"Число найдено в массиве в позиции {res}" : "Число не найдно в массиве";
            Console.WriteLine(mess);
            Console.ReadKey();
        }

        //Асимптотическая cложность O(log(N))
        public static int BinarySearch(byte[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
