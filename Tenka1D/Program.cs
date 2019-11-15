using System;
using System.Collections.Generic;
using System.Linq;

namespace Tenka1D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int N = ConsoleInput.Int();
            long[] A = new long[N];
            for (int i = 0; i < N; i++)
            {
                A[i] = ConsoleInput.Long();
            }

            Array.Sort(A);
            Array.Reverse(A);
            long Sum = A.Sum();
            long MaxMin = Sum / 3 + (Sum % 3 != 0 ? 1 : 0);
            long MaxMax = Sum / 2 - (Sum % 2 == 0 ? 1 : 0);

            long ans = 0;
            long MOD = 998244353;

            for (long i = MaxMin; i <= MaxMax; i++)
            {
                // 値、個数
                Dictionary<long, int>[] Max = new Dictionary<long, int>[N + 1];
                for (int j = 0; j < N + 1; j++)
                {
                    Max[i] = new Dictionary<long, int>();
                }

                Max[0].Add(0, 1);

                for (int j = 0; j < N; j++)
                {
                    foreach (KeyValuePair<long, int> keyValuePair in Max[j - 1])
                    {
                        Max[j+1].Add(keyValuePair.Key + A[i], keyValuePair.Value);
                    }

                    Max[j + 1] = Max[j];
                    if (Max[j].ContainsKey(A[i]))
                    {
                       // Max[j + 1];
                    }
                }

                //X(1~300)個使ってi(Max, ~15000個)を作る組み合わせを探す
                //残りから、Max以下の辺を作る組み合わせを探す
            }
            Console.WriteLine("hoge");
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