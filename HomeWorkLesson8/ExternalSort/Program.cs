using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSort
{
    class Program
    {
        static readonly string fileName = "array.bin";
        static readonly string fileNameSorted = "sortedarray.bin";
        static readonly int arrSize = 1000000;
        static readonly int bufferSize = 1000;
        static readonly int maxValue = 100;
        static byte[] arrayForSort = new byte[arrSize];
        static int[] arrayBuckets = new int[maxValue + 1];
        static List<byte> listBuffer = new List<byte>();
        static byte[] arrayBuffer = new byte[bufferSize];
        static FileStream fileStream;

        static void FillArray(byte[] a)
        {
            Random rand = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = (byte)rand.Next(1, maxValue);
            }
        }

        static void Main(string[] args)
        {
            FillArray(arrayForSort);
            using (fileStream = new FileStream(fileName, FileMode.Create))
            {
                fileStream.Write(arrayForSort, 0, arrayForSort.Length);
                fileStream.Close();
            }

            using (fileStream = new FileStream(fileName, FileMode.Open))
            {
                int bytesRead;
                do
                {
                    bytesRead = fileStream.Read(arrayBuffer, 0, arrayBuffer.Length);//Читаем входной файл по частям
                    for (int i = 0; i < bytesRead; i++)
                    {
                        arrayBuckets[arrayBuffer[i]]++;
                    }
                }
                while (bytesRead == arrayBuffer.Count());//Если не равно, значит достигнут конец файла
                fileStream.Close();
            }

            using (fileStream = new FileStream(fileNameSorted, FileMode.Create))
            {
                for (int i = 0; i < arrayBuckets.Length; i++)
                {
                    listBuffer.Clear();
                    for (int j = 0; j < arrayBuckets[i]; j++)
                    {
                        listBuffer.Add((byte)i);//Использован List, чтобы избежать OutOfRange при большом количестве одинаковых элементов
                    }
                    byte[] tmpArray = listBuffer.ToArray();
                    fileStream.Write(tmpArray, 0, arrayBuckets[i]);
                }
                fileStream.Close();
            }

            using (fileStream = new FileStream(fileNameSorted, FileMode.Open))
            {
                fileStream.Read(arrayForSort, 0, arrayForSort.Length); //Читаем чтобы посмотреть, что получилось
                fileStream.Close();
            }
        }
    }
}
