using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class ForTest
    {
        public static void main()
        {
            StreamReader sr = new StreamReader(@"C:\Users\ex.txt");

            string a = sr.ReadLine();

            string b = sr.ReadLine();

            sr.BaseStream.Position = sr.BaseStream.Position-1;

            string c = sr.ReadLine();

            sr = new StreamReader(@"C:\Users\ex.txt");

            for (int i = 0; i < 2; i++)
                sr.ReadLine();

            string f = sr.ReadLine();
        }
    }
}
