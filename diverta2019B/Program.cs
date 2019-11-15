using System;
using System.Linq;

namespace diverta2019B
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RGBN = CIN.IntArray();
            int R = RGBN[0];
            int G = RGBN[1];
            int B = RGBN[2];
            int N = RGBN[3];

            long ans = 0;
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    if (N < R * i + G * j)
                    {
                        continue;
                    }
                    if ((N - R * i - G * j) % B == 0)
                    {
                        ans++;
                    }
                }
            }
            Console.WriteLine(ans);
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