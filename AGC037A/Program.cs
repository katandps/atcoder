using System;
using System.Linq;

namespace AGC037A
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = CIN.String();

            long ans = 0;
            int beforeIndex = -1;
            char cur = '-';
            for (int i = 0; i < S.Length; i++)
            {
                if (i - 1 == beforeIndex && cur != S[i])
                {
                    beforeIndex = i;
                    cur = S[i];
                    ans++;
                    continue;
                }

                if (i - 2 == beforeIndex)
                {
                    beforeIndex = i;
                    cur = '-';
                    ans++;
                }
            }
            Console.WriteLine(ans);
        }
    }

    internal static class CIN
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int[] IntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(Console.ReadLine());
        }

        public static long[] LongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static double[] DoubleArray()
        {
            return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        }
    }
}