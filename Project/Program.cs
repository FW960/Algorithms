using System;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new();

            int[] array = Generate.IntArray();

            Display.ArrayValues(Sorter.SortArrayValues(array)); Display.Contains(rand.Next(0, array.Length));

        }
        
    }
}
