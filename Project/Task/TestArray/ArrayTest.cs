using BenchmarkDotNet.Attributes;
using RndStringGenerator;

namespace TestArray
{
    public class ArrayTest
    {
        public string [] array = Generate<string[]>.RndStrings();

        public string toFind = Generate<string>.RndString();

        [Benchmark]
        public void TestArray()
        {
            Contains(array, toFind);
        }
        public bool Contains(string[] array, string toFind)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == toFind)
                    return true;
            return false;
        }
    }
}
