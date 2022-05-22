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
            int[][] buckets = new int[20][];

            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new int[arrayLength];

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
                        map.Remove(j, out bucketCount);

                        buckets[j][bucketCount] = array[i];

                        map.Add(j, ++bucketCount);

                        divideValMult = 0;

                        break;
                    }
                    divideValMult += divideVal;
                }
            }

            divideValMult = divideVal;


            for (int i = 0; buckets.Length > i; i++)
            {
                /*if (maxVal*2 <= array.Length)
                {
                    buckets[i] = SortBucket(buckets[i], divideValMult, divideVal);

                    divideValMult += divideVal;
                }
                else
                {*/
                    buckets[i] = CorrectArray(buckets[i]);
                    buckets[i] = QuickSort(buckets[i]);
                /*}*/
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

        private int[] CorrectArray(int[] array)
        {
            int correctArrayLength = 0;

            for (int i = 0; array.Length > i; i++)
            {
                if (array[i] == 0)
                    break;

                correctArrayLength++;
            }

            int[] finalArray = new int[correctArrayLength];

            for (int i = 0; i < correctArrayLength; i++)
                finalArray[i] = array[i];

            return finalArray;
        }
        public static int[] QuickSort(int[] array)
        {
            if (array.Length == 0)
                return array;

            return QuickSort(array, 0, array.Length - 1);
        }
        private static int[] QuickSort(int[] array, int start, int end)
        {
            int mid = array[(start + end) / 2];

            int i = start, j = end;

            do
            {
                while (array[i] < mid)
                   i++;

                while (array[j] > mid)
                    j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i]; array[i] = array[j]; array[j] = temp;
                    }
                    i++;
                    j--;
                }

            } while (i <= j);


            if (i < end)
                QuickSort(array, i, end);

            if (start < j)
                QuickSort(array, start, j);

            return array;
        }

        private int[] SortBucket(int[] array, int divideValMult, int divideVal)
        {
            int correctArrayLength = 0; int count;

            var map = new Dictionary<int, int>();

            for (int i = 0; array.Length > i; i++)
            {
                if (array[i] == 0)
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

                correctArrayLength++;
            }

            int[] newArray = new int[correctArrayLength];

            int amount; int lastValAmount = 0;

            for (int i = divideValMult - divideVal; i < divideValMult; i++)
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
