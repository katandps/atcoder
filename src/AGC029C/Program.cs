using System;
using System.Linq;

namespace AGC029C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = Input.Long();
            var A = Input.LongArray();

            long currentNum = 1;
            var len = new long[N];
            long beforeLen = 0;
            for (var i = 0; i < N; i++)
            {
                if (A[i] > beforeLen) continue;
                for (var j = 0; j < A[i]; j++)
                {
                }
            }
        }
    }

    internal static class Input
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