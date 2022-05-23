using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public static class Test
    { 
        public static void Run()
        {
            string filePath = (@"C:\Users\unsortedArray.txt");

            Sort.ExternalSort(filePath);

            int [] array = Sort.BucketSort(RndArray.Get());
        }
    }
}
