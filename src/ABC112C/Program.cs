using System;
using System.Linq;

namespace ABC112C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = Input.Int();
            var x = new long[N];
            var y = new long[N];
            var h = new long[N];
            for (var i = 0; i < N; i++)
            {
                var longs = Input.LongArray();
                x[i] = longs[0];
                y[i] = longs[1];
                h[i] = longs[2];
            }

            for (var i = 1; i < N; i++)
            {
                var xdiff = x[i] - x[i - 1];
                var ydiff = x[i] - x[i - 1];
                var hdiff = x[i] - x[i - 1];
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