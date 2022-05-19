using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public static class Field
    {
        private static int[,] field = new int[5, 5]; 

        public static int[,] CalculateAllPathes()
        {

            int block = new Random().Next(0, field.GetLength(0)-1); int block2 = new Random().Next(0, field.GetLength(1)-1);

            if (block + block2 != 0 && block + block2 != field.GetLength(0)-1+field.GetLength(1)-1)
            {
                field[block, block2] = -1; field[block2, block] = -1;
            }

            CalculateAllPathes(0, 0);

            return field;
        }
        private static void CalculateAllPathes(int y, int x)
        {
            if(x != 0 || y != 0)
                field[y,x]++;

            if (x != field.GetLength(1)-1 && field[y,x+1] != -1)
                CalculateAllPathes(y, x + 1);

            if (y != field.GetLength(0)-1 && field[y+1,x] != -1)
                CalculateAllPathes(y+1, x);
        }
    }
}
