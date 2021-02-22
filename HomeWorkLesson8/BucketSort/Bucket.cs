using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSort
{
    public static class Bucket
    {
		public static void Sort(int[] arr)
		{
			int minValue = arr[0];
			int maxValue = arr[0];

			for (int i = 1; i < arr.Length; i++)
			{
					maxValue = Math.Max(maxValue, arr[i]);
					minValue = Math.Min(minValue, arr[i]);
			}

			List<int>[] bucket = new List<int>[maxValue - minValue + 1];

			for (int i = 0; i < bucket.Length; i++)
			{
				bucket[i] = new List<int>();
			}

			for (int i = 0; i < arr.Length; i++)
			{
				bucket[arr[i] - minValue].Add(arr[i]);
			}

			int k = 0;
			for (int i = 0; i < bucket.Length; i++)
			{
				if (bucket[i].Count > 0)
				{
					for (int j = 0; j < bucket[i].Count; j++)
					{
						arr[k] = bucket[i][j];
						k++;
					}
				}
			}
		}

	}
}
