using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public static class Test
    { 
        public static void Run()
        {
            Sort sort = new Sort();

            int[] array = sort.BucketSort(RndArray.Get());

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i} {array[i]}");
            }
        }
    }
}
