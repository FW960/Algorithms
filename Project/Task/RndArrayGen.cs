using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public static class RndArray
    {
        public static int[] Get()
        {
            Random random = new Random();

            int[] array = new int[random.Next(100000000, 100000000)];

            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(1, 10000000);

            return array;
        }
    }
}
