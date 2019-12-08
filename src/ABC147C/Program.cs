using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC147C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Cin.Int();
            int[] A = new int[N];
            int[][] X = new int[N][];
            bool[][] Y = new bool[N][];

            for (int i = 0; i < N; i++)
            {
                A[i] = Cin.Int();
                X[i] = new int[A[i]];
                Y[i] = new bool[A[i]];
                for (int j = 0; j < A[i]; j++)
                {
                    int[] xy = Cin.IArr();
                    X[i][j] = xy[0];
                    Y[i][j] = xy[1] == 1 ? true: false;
                }
            }
            var solver = new Solver(N, A, X, Y);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private int N;
        private int[] A;
        private int[][] X;
        private bool[][] Y;
        public Solver(int n, int[] a, int[][] x, bool[][] y)
        {
            N = n;
            A = a;
            X = x;
            Y = y;
        }

        public IConvertible Solve()
        {
            int maxCase = (int)Math.Pow(2, N);
            int maxAns = 0;
            for (int i = 0; i < maxCase; i++)
            {
                bool dame = false;
                bool[] l = new bool[N];
                for (int j = 0; j < N; j++)
                {
                    l[j] = (i >> j) % 2 == 0;
                }

                // 証言者ごとに総当り
                for (int j = 0; j < N; j++)
                {
                    // 嘘つきと仮定している人の証言は聞かない
                    if (!l[j])
                    {
                        continue;
                    }
                    // 仮定と異なる証言をしていた場合は仮定を破棄する
                    for (int k = 0; k < A[j]; k++)
                    {
                        if (l[X[j][k] - 1] != Y[j][k])
                        {
                            dame = true;
                        }
                    }
                }

                if (!dame)
                {
                    int ans = 0;
                    for (int j = 0; j < l.Length; j++)
                    {
                        ans += l[j] ? 1 : 0;
                    }

                    maxAns = Math.Max(maxAns, ans);
                }
            }
            return maxAns;
        }
    }

    internal static class Cin
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(String());
        }

        public static int[] IArr()
        {
            return Split().Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(String());
        }

        public static long[] LArr()
        {
            return Split().Select(long.Parse).ToArray();
        }

        public static double Double()
        {
            return double.Parse(String());
        }

        public static double[] DArr()
        {
            return Split().Select(double.Parse).ToArray();
        }

        private static IEnumerable<String> Split()
        {
            return String().Split(' ');
        }
    }
}