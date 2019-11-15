using System;
using System.Linq;

namespace ABC112D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var longs = Input.LongArray();
            var N = longs[0];
            var M = longs[1];

            var ave = M / N;
            var mod = M % N;

            if (mod == 0)
            {
                Console.WriteLine(ave);
                return;
            }

            Console.WriteLine(Math.Max(Gcd(ave, mod), Gcd(ave - 1, mod + N)));
        }

        public static long Gcd(long a, long b)
        {
            return b > 0 ? Gcd(b, a % b) : a;
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