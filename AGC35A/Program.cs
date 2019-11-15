using System;
using System.Linq;

namespace AGC35A
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();
            long[] A = CIN.LongArray();

            if (N % 3 != 0)
            {
                for (int i = 0; i < N; i++)
                {
                    if (A[i] != 0)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }

                Console.WriteLine("Yes");
                return;
            }

            long[] bits = new long[33];
            for (int i = 0; i < N; i++)
            {
                long p = 1;
                for (int j = 0; j < 33; j++)
                {
                    bits[j] += (A[i] / p) % 2;
                    p *= 2;
                }
            }

            for (int i = 0; i < 33; i++)
            {
                if (bits[i] != N / 3 * 2 && bits[i] != 0)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
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