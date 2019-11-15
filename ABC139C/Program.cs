using System;
using System.Linq;

namespace ABC139C
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();
            long[] H = CIN.LongArray();

            int ans = 0;
            int cur = 0;

            for (int i = 1; i < N; i++)
            {
                if (H[i] <= H[i - 1])
                {
                    cur++;
                    ans = Math.Max(cur, ans);
                }
                else
                {
                    cur = 0;
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