using System;
using System.Linq;

namespace ABC109C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var longs = ConsoleInput.LongArray();
            var N = longs[0];
            var X = longs[1];
            var Xi = ConsoleInput.LongArray();

            var Defs = new long[N + 1];
            for (var i = 0; i < N; i++) Defs[i] = Xi[i] - X;

            Defs[N] = 0;

            Array.Sort(Defs);
            long gcd = 0;
            for (var i = 0; i < N; i++)
            {
                var diff = Defs[i + 1] - Defs[i];
                if (gcd == 0)
                {
                    gcd = diff;
                    continue;
                }

                gcd = Gcd(gcd, diff);
                if (gcd == 1) break;
            }

            Console.WriteLine(gcd);
        }

        public static long Gcd(long a, long b)
        {
            if (a < b)
                // 引数を入替えて自分を呼び出す
                return Gcd(b, a);
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
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