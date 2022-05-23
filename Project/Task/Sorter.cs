using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public static class Sort
    {
        private static int[][] buckets;

        public static void ExternalSort(string filePath)
        {
            var sr = new StreamReader(filePath);

            var fi = new FileInfo(filePath);

            string dir = Path.Combine(fi.DirectoryName, "ArrayParts");

            string sortedFilePath = Path.Combine(new FileInfo(filePath).DirectoryName, "Sorted.txt");

            var fs = new FileStream(sortedFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            fs.Close();

            Directory.CreateDirectory(dir);

            int count = 0;

            string newFilePath = string.Empty;

            do
            {
                newFilePath = Path.Combine(dir, $"{count}ArrayPart.txt");

                ReadFromFileAndWritePart(newFilePath, sr);

                count++;


            } while (!sr.EndOfStream);


            WriteToNewFile(filePath, dir, sortedFilePath);

            DeleteDir(dir);
        }
        private static void DeleteDir(string dir)
        {
            string[] files = Directory.GetFiles(dir);

            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
            Directory.Delete(dir);
        }
        private static void WriteToNewFile(string filePath, string dirPath, string sortedFilePath)
        {
            string[] allParts = Directory.EnumerateFileSystemEntries(dirPath).ToArray();

            Dictionary<string, (StreamReader, int)> dict = new Dictionary<string, (StreamReader, int)>();

            int allValues = 0;

            for (int i = 0; i < allParts.Length; i++)
            {
                string[] enumString = File.ReadAllLines(allParts[i]);

                allValues += enumString.Length;

                dict.Add(allParts[i], (new StreamReader(allParts[i]), 0));
            }

            string lastFileUsed = string.Empty;

            (StreamReader, int) value;

            int minVal = int.MaxValue;

            for (int e = 0; e < allValues; e++)
            {
                for (int i = 0; i < allParts.Length; i++)
                {
                    dict.Remove(allParts[i], out value);

                    int compareValue = Convert.ToInt32(value.Item1.ReadLine());

                    if (compareValue < minVal)
                    {
                        minVal = compareValue;

                        lastFileUsed = allParts[i];

                        value.Item1 = new StreamReader(lastFileUsed);

                        for (int j = 0; j < value.Item2; j++)
                            value.Item1.ReadLine();

                        dict.Add(lastFileUsed, (value.Item1, value.Item2));

                    }
                    else
                    {
                        value.Item1 = new StreamReader(allParts[i]);

                        for (int j = 0; j < value.Item2; j++)
                            value.Item1.ReadLine();

                        dict.Add(allParts[i], (value.Item1, value.Item2));
                    }


                }
                dict.Remove(lastFileUsed, out value);

                value.Item2++;

                value.Item1 = new StreamReader(lastFileUsed);

                for (int i = 0; i < value.Item2; i++)
                    value.Item1.ReadLine();

                dict.Add(lastFileUsed, (value.Item1, value.Item2));

                File.AppendAllText(sortedFilePath, $@"{minVal}
");
                minVal = int.MaxValue;

            }
            

        }

        private static void ReadFromFileAndWritePart(string filePath, StreamReader sr)
        {
            int[] part = new int[10000000];

            int lastNum = 0;

            try
            {
                for (int i = 0; i < part.Length; i++)
                {
                    part[i] = Convert.ToInt32(sr.ReadLine());
                    lastNum = i;
                }


            }
            catch
            {
                for (int i = lastNum; i < part.Length; i++)
                    part[i] = Convert.ToInt32(sr.ReadLine());

                int count = 0;

                for (int i = 0; i < part.Length; i++)
                {
                    if (part[i] == 0)
                        continue;

                    count++;
                }

                int[] vs = new int[count];

                count = 0;

                for (int i = 0; i < part.Length; i++)
                {
                    if (part[i] == 0)
                        break;

                    vs[i] = part[i];
                }

                part = vs;
            }

            QuickSort(part);

            string[] toAppend = new string[part.Length];

            for (int i = 0; i < part.Length; i++)
            {
                toAppend[i] = part[i].ToString();
            }

            var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            fs.Close();

            File.AppendAllLines(filePath, toAppend);

        }

        public static int[] BucketSort(int[] array)
        {
            (int maxVal, int divVal) maxAndDivValues = DivideBucket(array);

            return OptimizeSort(array, maxAndDivValues.maxVal, maxAndDivValues.divVal, maxAndDivValues.divVal);
        }

        private static int[][] InitBuckets(int arrayLength)
        {
            int[][] buckets = new int[20][];

            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new int[arrayLength];

            return buckets;
        }

        private static (int maxVal, int divVal) DivideBucket(int[] array)
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

            return (maxVal, divideVal);

        }
        private static int[] OptimizeSort(int[] array, int maxVal, int divideVal, int divideValMult)
        {
            for (int i = 0; buckets.Length > i; i++)
            {
                if (maxVal * 2 <= array.Length)
                {
                    buckets[i] = SortBucket(buckets[i], divideValMult, divideVal);

                    divideValMult += divideVal;
                }
                else
                {
                    buckets[i] = CorrectArray(buckets[i]);
                    buckets[i] = QuickSort(buckets[i]);
                }
            }

            return SortBuckets(array.Length);
        }

        private static int[] SortBuckets(int length)
        {
            int[] finalArray = new int[length];

            int lastBucketVal = 0;

            for (int i = 0; i < buckets.Length; i++)
                for (int j = 0; j < buckets[i].Length; j++)
                    finalArray[lastBucketVal++] = buckets[i][j];

            return finalArray;
        }
        private static int[] SortBucket(int[] array, int divideValMult, int divideVal)
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

        private static int[] CorrectArray(int[] array)
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


    }
}
