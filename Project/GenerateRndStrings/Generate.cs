using System;
using System.Collections.Generic;

namespace RndStringGenerator
{
    public static class Generate<T>
    {
        public static T RndStrings()
        {
            if (typeof(T).IsArray)
            {
                string[] array = new string[10000];

                for (int i = 0; i < array.Length; i++)
                    array[i] = RndString();

                return (T)Convert.ChangeType(array, typeof(T));
            }else if (typeof(T).IsGenericType)
            {
                HashSet<string> hashSet = new HashSet<string>();

                for (int i = 0; i < 10000; i++)
                    hashSet.Add(RndString());

                return (T)Convert.ChangeType(hashSet, typeof(T));
            }
            return default(T);
        }
        public static string RndString()
        {
            byte[] bytes = new byte[new Random().Next(100,1000)];

            for (int i = 0;i < bytes.Length;i++)
                bytes[i] = (byte)new Random().Next(0, 100);

            string word = Convert.ToBase64String(bytes);

            if(word.Contains('='))
                word =word.Split('=')[0];
            return word;
        }
    }
    
}
