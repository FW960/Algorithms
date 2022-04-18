using System;

public static class Searcher
{
    public static int? BinarySearch(int[] array, int value)
    {
        int min = 0;                                       //O(1)

        int max = array.Length;                            //O(1) + O(1)

        while (min != max)                                 //O(log_n) + O(1) + O(1)
        {
            int mid = (min + max) / 2;

            if (array[mid] == value)
                return mid;

            if (array[mid] < value)
                min = mid + 1;
            else
                max = mid - 1;                             //4*O(log_n) + O(1) + O(1)
        }                                                  //Если принебречь константами, то O(log_n)
        return null;
    }
}
