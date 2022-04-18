using System;

public static class Sorter
{
    public static int[] SortArrayValues(int[] array)
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
}
