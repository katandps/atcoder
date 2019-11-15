using System;
using System.Linq;

namespace ABC133D
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();
            long[] A = CIN.LongArray();

            long[] dis = new long[N];
            dis[0] = A[0] - A[N - 1];
            for (int i = 1; i < N; i++)
            {
                dis[i] = A[i] - A[i - 1];
            }

            long[] mounts = new long[N];
            mounts[0] = 0;
            for (int i = 2; i < N * 2; i += 2)
            {
                mounts[i % N] = mounts[(i + N - 2) % N] + 2 * dis[i % N];
            }

            long[] ans = new long[N];
            ans[0] = mounts[N - 1];
            for (int i = 1; i < N; i++)
            {
                ans[i] = mounts[i - 1];
            }

            long a = A[0] - (ans[0] / 2 + ans[1] / 2);

            for (int i = 0; i < N; i++)
            {
                Console.Write(ans[i] + a);
                if (i != N - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
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