using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Sorters;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program() + new Program();

            BenchmarkSwitcher.FromAssembly(typeof(Sort).Assembly).Run(args);
        }
        public static int[] GenRndIntArray()
        {
            Random random = new Random();

            int[] array = new int[100];

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(0, 100000);

            return array;
        }

        public static Program operator +(Program pr, Program pr1)
        {
            return pr + pr1;
        }
    }

    public class HalfShakeTest
    {
        int [] array = Program.GenRndIntArray();
        [Benchmark]
        public void TestHalfSHake()
        {
            Sort.HalfShakeSort(array);
        }
    }
    public class BubbleTest
    {
        int[] array = Program.GenRndIntArray();
        [Benchmark]
        public void TestBubble()
        {
            Sort.Bubble(array);
        }
    }
    public class MyFirstSortTest
    {
        int[] array = Program.GenRndIntArray();
        [Benchmark]
        public void TestMyFirstSort()
        {
            Sort.MyFirstSort(array);
        }
    }
}
