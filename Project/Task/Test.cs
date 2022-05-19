using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace Task
{
    public static class Test
    {
        public static void Run()
        {
           int [,] field = Field.CalculateAllPathes();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write($" {field[i, j]} ");
                }
                Console.WriteLine();
            }
                
        }
    }
}
