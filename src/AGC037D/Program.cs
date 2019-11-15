using System;
using System.Collections.Generic;
using System.Linq;

namespace AGC037D
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NM = CIN.IntArray();
            int N = NM[0];
            int M = NM[1];
            int[][] A = new int[N][];
            for (int i = 0; i < N; i++)
            {
                A[i] = CIN.IntArray();
            }

            // B[i][j] = k; (i,j)にある、k行目にあるべき数字
            int[][] B = new int[N][];
            for (int i = 0; i < N; i++)
            {
                B[i] = new int[M];
                for (int j = 0; j < M; j++)
                {
                    B[i][j] = (A[i][j] - 1 - (A[i][j] - 1) % M) / M;
                }
            }

            // C[i][j] = k; 1回目の操作のあと(i,j)にいるk行目にあたる文字
            int[][] C = new int[N][];
            // count[i][j] = i行目に入るべき数字がj行目にある個数 
            int[][] count = new int[N][];
            for (int i = 0; i < N; i++)
            {
                C[i] = new int[M];
                count[i] = new int[N];
                
                for (int j = 0; j < M; j++)
                {
                    C[i][j] = -1;
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    count[B[i][j]][i] = count[B[i][j]][i] + 1;
                }
            }

            // 列に対して、列に入れたい数字ごとに埋めていく
            for (int j = 0; j < M; j++)
            {
                var used = new HashSet<int>();
                //C[i][j]を決める
                for (int i = 0; i < N; i++)
                {
                    int max = 0;
                    int maxIndex = -1;
                    // k行目に入れたい数字を選ぶ
                    for (int k = 0; k < N; k++)
                    {
                        if (used.Contains(k)) continue;
                        if (count[k][i] > max) //より残っている文字を優先する
                        {
                            max = count[k][i];
                            maxIndex = k;
                        }
                    }
                    C[i][j] = maxIndex;
                    used.Add(maxIndex);
                    count[maxIndex][i]--;
                }
            }
            
            Console.WriteLine("Hello World!");
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
}