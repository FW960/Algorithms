using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Sort
    {
        private int[][] buckets;

        public int[] BucketSort(int[] array)
        {
            return DivideBucket(array);
        }

        private int[][] InitBuckets(int arrayLength)
        {
            int[][] buckets = new int[100][];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new int[arrayLength];

                for (int j = 0; j < buckets[i].Length; j++)
                {
                    buckets[i][j] = -1;
                }
            }

            return buckets;
        }

        private int[] DivideBucket(int[] array)
        {
            buckets = InitBuckets(array.Length);

            int maxVal = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxVal)
                    maxVal = array[i];
            }

            int divideVal = maxVal / buckets.Length;


            if (divideVal % 10 != 0)
                divideVal++;

            int divideValMult = 0; int bucketCount;

            var map = new Dictionary<int, int>();

            for (int i = 0; i < buckets.Length; i++)
                map.Add(i, 0);

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < buckets.Length; j++)
                {
                    if (divideValMult + divideVal > array[i] && divideValMult <= array[i])
                    {
                        if (j > buckets.Length - 1)
                            j = buckets.Length - 1;

                        map.Remove(j, out bucketCount);

                        buckets[j][bucketCount] = array[i];

                        map.Add(j, ++bucketCount);

                        divideValMult = 0;

                        break;
                    }
                    divideValMult += divideVal;
                }
            }

            for (int i = 0; buckets.Length > i; i++)
            {
                buckets[i] = SortBucket(buckets[i], divideVal);
                divideVal += divideVal;
            }
            return SortBuckets(buckets, array.Length);


        }

        private int[] SortBuckets(int[][] array, int length)
        {
            int[] finalArray = new int[length];

            int lastBucketVal = 0;

            for (int i = 0; i < buckets.Length; i++)
                for (int j = 0; j < buckets[i].Length; j++)
                    finalArray[lastBucketVal++] = buckets[i][j];

            return finalArray;
        }

        private int[] SortBucket(int[] array, int divideVal)
        {
            int rightArrayLength = 0; int count;

            var map = new Dictionary<int, int>();

            for (int i = 0; array.Length > i; i++)
            {
                if (array[i] == -1)
                    break;

                if (map.ContainsKey(array[i]))
                {
                    map.Remove(array[i], out count);

                    map.Add(array[i], ++count);
                }
                else
                {
                    map.Add(array[i], 1);
                }

                rightArrayLength++;
            }

            int[] newArray = new int[rightArrayLength];

            int amount; int lastValAmount = 0;

            for (int i = 0; divideVal > i; i++)
            {
                if (map.ContainsKey(i))
                {
                    map.Remove(i, out amount);

                    for (int j = lastValAmount; j < lastValAmount + amount; j++)
                    {
                        newArray[j] = i;
                    }

                    lastValAmount += amount;
                }
            }

            return newArray;


        }
    }
}
