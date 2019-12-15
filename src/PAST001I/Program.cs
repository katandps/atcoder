﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PAST001I
{
    class Program
    {
        static void Main(string[] args)
        {
            var nm = Cin.IArr();
            string[] s = new string[nm[1]];
            long[] c = new long[nm[1]];
            for (int i = 0; i < nm[1]; i++)
            {
                var ss = Cin.String().Split(' ').ToArray();
                s[i] = ss[0];
                c[i] = int.Parse(ss[1]);
            }

            var solver = new Solver(nm[0], nm[1], s, c);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private int N;
        private int M;
        private string[] S;
        private long[] C;

        public Solver(int n, int m, string[] s, long[] c)
        {
            N = n;
            M = m;
            S = s;
            C = c;
        }

        public IConvertible Solve()
        {
            // <bit変換値、 最低価格>
            Dictionary<int, long> dp = new Dictionary<int, long>();
            dp.Add(0, 0);
            int maxCase = (int) Math.Pow(2, N);

            Dictionary<int, long> sets = new Dictionary<int, long>();

            // 存在チェック
            for (int i = 0; i < N; i++)
            {
                bool exist = false;

                for (int j = 0; j < M; j++)
                {
                    if (S[j][i] == 'Y')
                    {
                        exist = true;
                    }
                }

                if (!exist)
                {
                    return -1;
                }
            }

            //bit値に変換
            for (int i = 0; i < M; i++)
            {
                int cur = 1;
                int index = 0;
                for (int j = 0; j < N; j++)
                {
                    if (S[i][j] == 'Y')
                    {
                        index += cur;
                    }

                    cur *= 2;
                }

                if (sets.ContainsKey(index))
                {
                    sets[index] = Math.Min(sets[index], C[i]);
                    continue;
                }

                sets.Add(index, C[i]);
            }

            foreach (var s in sets)
            {
                Dictionary<int, long> add = new Dictionary<int, long>();
                foreach (var p in dp)
                {
                    var k = p.Key;

                    var target = s.Key | k;
                    if (!add.ContainsKey(target))
                    {
                        add.Add(target, p.Value + s.Value);
                        continue;
                    }

                    add[target] = Math.Min(add[target], p.Value + s.Value);
                }

                foreach (var k in add)
                {
                    var target = k.Key;
                    if (!dp.ContainsKey(target))
                    {
                        dp.Add(target, k.Value);
                        continue;
                    }

                    dp[target] = Math.Min(dp[target], k.Value);
                }
            }

            return dp[maxCase - 1];
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