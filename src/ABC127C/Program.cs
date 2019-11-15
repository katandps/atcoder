using System;
using System.Linq;

namespace ABC127C
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NM = CIN.LongArray();
            long N = NM[0];
            long M = NM[1];
            long[] L = new long[M];
            long[] R = new long[M];
            for (int i = 0; i < M; i++)
            {
                long[] LR = CIN.LongArray();
                L[i] = LR[0];
                R[i] = LR[1];
            }

            long MostL = -1;
            long MostR = N;

            for (int i = 0; i < M; i++)
            {
                MostL = Math.Max(MostL, L[i]);
                MostR = Math.Min(MostR, R[i]);
            }

            if (MostL > MostR)
            {
                Console.WriteLine(0);
                return;
            }

            Console.WriteLine(MostR - MostL + 1);
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