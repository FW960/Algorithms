using System;

public static class Generate
{
    public static int[] IntArray()
    {
        Random random = new Random();

        int[] array = new int[50];

        for (int i = 0; i < array.Length; i++)
            array[i] = random.Next(10, 100);

        return array;

    }
}
