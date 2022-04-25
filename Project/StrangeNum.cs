using System;

public static class Calculate
{
    /// <summary>
    /// Int parameter is int array. Returns calculated strange number.
    /// </summary>
    /// <param name="inputArray"></param>
    /// <returns></returns>
    public static int StrangeSum(int[] inputArray)
    {
        int sum = 0;                                           // O(1)
        for (int i = 0; i < inputArray.Length; i++)            // O(n) + O(1)
        {                                                      //
            for (int j = 0; j < inputArray.Length; j++)        // O(n) * O(n) + O(1)
            {                                                  //
                for (int k = 0; k < inputArray.Length; k++)    // O(n) * O(n) * O(n) + O(1)
                {                                              //
                    int y = 0;                                 // 
                    if (j != 0)                                // 
                    {                                          //
                        y = k / j;                             //
                    }                                          //
                    sum += inputArray[i] + i + k + j + y;      // ((O(n) * O(n) * O(n)) * O(4)) + O(1)
                }                                              //
            }                                                  //
        }                                                      //
        return sum;                                            // ((O(n) * O(n) * O(n)) * O(4)) + O(1) + O(1) или 4O(n)³ + O(1)
    }                                                          // Если принебречь константами, то получится O(n)³
}
