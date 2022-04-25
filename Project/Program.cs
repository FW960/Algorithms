using System;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowFibNum.Result(FibNum.CalculcateUsingRecursy(1000, ArrayGenerator.GenerateIntArray()));

            ShowFibNum.Result(FibNum.CalculateUsingCycle(ArrayGenerator.GenerateIntArray().Length));
        }

    }
}
