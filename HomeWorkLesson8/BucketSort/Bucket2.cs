using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSort
{
    public static class Bucket2
    {
// Сортировка с использованием массива в качестве bucket и Merge сортировки 
        public static void SortArr(int[] arr, int numOfBuckets)
        {
            int[,] buckets = new int[numOfBuckets, arr.Length];
            int[] borders = new int[numOfBuckets + 1];
            int[] counters = new int[numOfBuckets]; //Количество элементов в каждой корзине
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
                max = Math.Max(max, arr[i]);
            for (int i = 0; i < numOfBuckets + 1; i++)
            {
                borders[i] = i * (max + 1) / numOfBuckets;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < numOfBuckets; j++)
                {
                    if (arr[i] >= borders[j] && arr[i] < borders[j + 1])
                    {
                        buckets[j, counters[j]] = arr[i];
                        counters[j]++;
                        break;
                    }
                }
            }
            int[,] sortedBuckets = new int[numOfBuckets, arr.Length];
            for (int k =0; k < numOfBuckets; k++)
            {
                int[] singleArr = new int[counters[k]];
                for (int i = 0; i < counters[k]; i++)
                {
                    singleArr[i] = buckets[k, i]; 
                }
                int[] sortedArr = Merge.Sort(singleArr);
                for (int i = 0; i < counters[k]; i++)
                {
                    sortedBuckets[k, i] = sortedArr[i];
                }
            }
            //Собираем корзинки в выходной массив
            int index = 0;
            for (int k = 0; k < numOfBuckets; k++)
            {
                for (int i = 0; i < counters[k]; i++)
                {
                    arr[index] = sortedBuckets[k, i];
                    index++;
                }
            }
        }

        // Сортировка с использованием List в качестве bucket и встроенного метода Sort
        public static void Sort(int[] arr, int numOfBuckets)
        {
            List<List<int>> buckets;
            List<int> borders = new List<int>();
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
                max = Math.Max(max, arr[i]);
            buckets = new List<List<int>>();
            for (int i =  0; i < numOfBuckets; i++)
                buckets.Add(new List<int>());
            for (int i = 0; i < numOfBuckets + 1; i++)
            {
                borders.Add( i * (max + 1) / numOfBuckets);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < numOfBuckets; j++)
                {
                    if (arr[i] >= borders[j] && arr[i] < borders[j + 1])
                    {
                        buckets[j].Add(arr[i]);
                        break;
                    }
                }
            }
            for (int k = 0; k < numOfBuckets; k++)
                buckets[k].Sort();
            //Собираем корзинки в выходной массив
            int index = 0;
            for (int k = 0; k < numOfBuckets; k++)
            {
                for (int i = 0; i < buckets[k].Count; i++)
                {
                    arr[index] = buckets[k][i];
                    index++;
                }
            }
        }
    }
}
