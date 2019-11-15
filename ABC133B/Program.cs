using System;
using System.Linq;

namespace ABC133B
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ND = CIN.IntArray();
            int[][] X = new int[ND[0]][];
            for (int i = 0; i < ND[0]; i++)
            {
                X[i] = CIN.IntArray();
            }

            int ans = 0;
            for (int i = 0; i < ND[0]; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    float d2 = 0;
                    for (int k = 0; k < ND[1]; k++)
                    {
                        d2 += (X[i][k] - X[j][k]) * (X[i][k] - X[j][k]);
                    }

                    if (Math.Sqrt(d2) % 1 <= 0)
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