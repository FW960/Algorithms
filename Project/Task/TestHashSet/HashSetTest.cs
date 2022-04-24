using BenchmarkDotNet.Attributes;
using RndStringGenerator;
using System.Collections.Generic;

namespace TestHashSet
{
    public class HashSetTest
    {
        string toFind = Generate<string>.RndString();
        HashSet<string> hashSet = Generate<HashSet<string>>.RndStrings();
        [Benchmark]
        public void TestHashSet() => Contains(hashSet, toFind);
        public bool Contains(HashSet<string> hashSet, string toFind) => hashSet.Contains(toFind);
    }
}
