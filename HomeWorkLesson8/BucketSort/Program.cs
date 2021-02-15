using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSort
{
    class Program
    {
        static int arrSize = 100;
        static int maxValue = 50;
        static int numOfBuckets = 4;
        static int[] arrayForSort = new int[arrSize];

        static void FillArray(int[] a)
        {
            Random rand = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(maxValue);
            }
        }


        static void Main()
        {
            FillArray(arrayForSort);
            Bucket2.SortArr(arrayForSort, numOfBuckets);
//            Bucket.Sort(arrayForSort);
//            Merge.Sort(arrayForSort);
        }
    }
}
