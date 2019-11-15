using System;
using System.Linq;

namespace ARC102C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = ConsoleInput.LongArray();
            var N = ints[0];
            var K = ints[1];

            var zero = N / K;
            long half = 0;
            if (K % 2 == 0) half = (N + K / 2) / K;

            var ans = zero * zero * zero + half * half * half;
            Console.WriteLine(ans);
        }
    }

    internal static class ConsoleInput
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