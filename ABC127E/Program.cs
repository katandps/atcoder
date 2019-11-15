using System;
using System.Linq;

namespace ABC127E
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NMK = CIN.LongArray();
            long N = NMK[0];
            long M = NMK[1];
            long K = NMK[2];

            long MOD = 1000000007;
            long point = N * M % MOD * (N - 1) % MOD * (M - 1) % MOD;
            
            Console.WriteLine(point);
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