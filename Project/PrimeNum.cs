using System;

public static class PrimeNum
{
    /// <summary>
    /// Method checks if input int parameter is prime number. Returns bool value type.
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static bool IsPrimeNum(int n)
    {
        int d = 0; int i = 2;

        if (i < n)
        {
            if (n % i == 0)
                d++;
            else
                i++;
        }
        if (d == 0)
            return true;
        else
            return false;
    }
}
