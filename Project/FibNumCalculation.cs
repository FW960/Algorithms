using System;

public static class FibNum
{
    /// <summary>
    /// Method in input gets long number and return fibonacci number that corresponding to input number. 
    /// </summary>
    /// <param name="fibNum"></param>
    /// <returns></returns>
    public static long CalculateUsingCycle(long fibNum)
    {
        long[] fibNums = new long[fibNum];

        fibNums[0] = 0; fibNums[1] = 1;

        for (int i = 2; i < fibNum; i++)
            fibNums[i] = fibNums[i - 1] + fibNums[i - 2];


        return fibNums[fibNum - 1];
    }
    /// <summary>
    /// Method in input params gets random long number that longer array lenght. Returns calculated fibonacci number that corresponding to array lenght number.
    /// </summary>
    /// <param name="fibNum"></param>
    /// <param name="fibNums"></param>
    /// <returns></returns>
    public static long CalculcateUsingRecursy(long fibNum, long[] fibNums)
    {
        if (fibNum == fibNums.Length - fibNums.Length)
            return fibNums[0];

        --fibNum;

        fibNums[fibNums.Length - 1] = 0; fibNums[fibNums.Length - 2] = 1;

        if (fibNum <= fibNums.Length - 3)
            fibNums[fibNum] = fibNums[fibNum + 1] + fibNums[fibNum + 2];

        return fibNums[0] = CalculcateUsingRecursy(fibNum, fibNums);
    }
}
