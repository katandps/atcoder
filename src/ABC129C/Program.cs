using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC129C
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NM = CIN.LongArray();
            long[] A = new long[NM[1]];
            for (int i = 0; i < NM[1]; i++)
            {
                A[i] = CIN.Long();
            }

            Dictionary<long, bool> AI = new Dictionary<long, bool>();
            foreach (long l in A)
            {
                if (AI.ContainsKey(l))
                {
                    continue;
                }
                AI.Add(l, true);
            }

            long[] dp = new long[NM[0] + 1];
            dp[0] = 1;
            for (int i = 1; i <= NM[0]; i++)
            {
                if (AI.ContainsKey(i))
                {
                    dp[i] = 0;
                    continue;
                }

                dp[i] = dp[i - 1];
                if (i > 1)
                {
                    dp[i] = (dp[i] + dp[i - 2]) % 1000000007;
                }
            }

            Console.WriteLine(dp[NM[0]]);
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