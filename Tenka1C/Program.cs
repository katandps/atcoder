using System;
using System.Linq;

namespace Tenka1C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long N = ConsoleInput.Long();
            string S = ConsoleInput.String();

            long[] dpW = new long[N + 1];
            long[] dpB = new long[N + 1];
            dpW[0] = 0;
            dpB[0] = 0;
            for (int i = 1; i <= N; i++)
            {
                if (S[i - 1] == '#')
                {
                    dpW[i] = dpW[i - 1];
                    dpB[i] = dpB[i - 1] + 1;
                    continue;
                }

                if (S[i - 1] == '.')
                {
                    dpB[i] = dpB[i - 1];
                    dpW[i] = dpW[i - 1] + 1;
                }
            }

            long ans = Math.Min(N - dpB[N], N - dpW[N]);
            long[] m = new long[N];
            for (int i = 0; i < N; i++)
            {
                m[i] = dpB[i] + dpW[N] - dpW[i];
            }
            
            Console.WriteLine(Math.Min(ans, m.Min()));
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