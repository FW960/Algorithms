using System;

namespace Sorters
{
    public static class Sort
    {
        public static int[] HalfShakeSort(int[] array)
        {
            int temp = int.MinValue;

            int index = 0;

            int lastNum = 0;

            for (int i = 0; i < array.Length - lastNum; i++) // O(n2)/2
            {
                if (lastNum == array.Length - 1)
                    break;
                if (array[i] > temp)
                {
                    temp = array[i];
                    index = i;
                }
                if (i == array.Length - 1 - lastNum)
                {
                    array[index] = array[i];

                    array[i] = temp; lastNum++; i = -1; temp = int.MinValue;

                }
            }

            return array;
        }
        public static int[] MyFirstSort(int[] array)
        {
            int temp;

            for (int i = 0; array.Length > i; i++)
                for (int j = 0; j < array.Length; j++)
                {

                    if (array[i] < array[j])
                    {
                        temp = array[i];

                        array[i] = array[j];

                        array[j] = temp;

                    }
                }
            return array;
        }
        public static int[] Bubble(int[] array)
        {
            int temp;

            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];

                        array[i] = array[i + 1];

                        array[i + 1] = temp;
                    }
                }
            }
            return array;
        }
        public static int[] Shake(int[] array)
        {
            throw new NotImplementedException();
        }
        public static int[] GenRndIntArray()
        {
            Random random = new Random();

            int[] array = new int[100000];

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(0, 100000);

            return array;
        }
    }
}
