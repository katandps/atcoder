using System;
using System.Linq;

namespace AGC028A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var lengths = Input.LongArray();
            var N = lengths[0];
            var M = lengths[1];

            var S = Input.String();
            var T = Input.String();

            var gcd = Gcd(N, M);
            var lcm = N * M / gcd;

            var ln = lcm / N;
            var lm = lcm / M;

            var ans = new char[N];
            for (var i = 0; i < N; i++) ans[i] = S[i];

            for (var i = 0; i < M; i++)
                if (i * lm % ln == 0)
                    if (ans[i * lm / ln] != T[i])
                    {
                        Console.WriteLine(-1);
                        return;
                    }

            Console.WriteLine(lcm);
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