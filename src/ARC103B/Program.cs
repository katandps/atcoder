using System;
using System.Linq;

namespace ARC103B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = Input.Int();
            var X = new long[N];
            var Y = new long[N];
            for (var i = 0; i < N; i++)
            {
                var inp = Input.LongArray();
                X[i] = inp[0];
                Y[i] = inp[1];
            }

            var existCond = new long[N];
            for (var i = 0; i < N; i++) existCond[i] = Math.Abs(X[i]) + Math.Abs(Y[i]);

            for (var i = 1; i < N; i++)
                if ((existCond[i - 1] - existCond[i]) % 2 == 1)
                {
                    Console.WriteLine(-1);
                    return;
                }

            var D = new long[40];
            for (var i = 0; i < N; i++)
            {
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