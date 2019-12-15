using System;
using System.Collections.Generic;
using System.Linq;

namespace PAST001H
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Cin.Long();
            long[] c = Cin.LArr();
            long q = Cin.Long();
            string[] s = new string[q];
            for (int i = 0; i < q; i++)
            {
                s[i] = Cin.String();
            }

            var solver = new Solver(n, c, q, s);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long N;
        private long[] C;
        private long Q;
        private string[] S;

        public Solver(long n, long[] c, long q, string[] s)
        {
            N = n;
            C = c;
            Q = q;
            S = s;
        }

        public IConvertible Solve()
        {
            long oddNum = N / 2 + N % 2;

            long oddHistory = 0;
            long allHistory = 0;

            long oddRest = long.MaxValue;
            long allRest = long.MaxValue;
            for (int i = 0; i < N; i++)
            {
                allRest = Math.Min(allRest, C[i]);
                if (i % 2 == 0)
                {
                    oddRest = Math.Min(oddRest, C[i]);
                }
            }

            long history = 0;
            long[] historyEveryCards = new long[N + 1];
            //クエリごとにやる
            for (int i = 0; i < Q; i++)
            {
                var q = S[i].Split(' ').Select(long.Parse).ToArray();
                if (q[0] == 1)
                {
                    var c = q[1];
                    var n = q[2];
                    var odd = c % 2 == 1 ? oddHistory : 0;
                    if (historyEveryCards[c] + odd + allHistory + n < C[c - 1])
                    {
                        historyEveryCards[c] += n;
                        history += n;
                        allRest = Math.Min(allRest, C[c - 1] - historyEveryCards[c] - odd - allHistory);
                        if (c % 2 == 1)
                        {
                            oddRest = Math.Min(oddRest,
                                C[c - 1] - historyEveryCards[c] - odd - allHistory);
                        }
                    }
                }
                else if (q[0] == 2)
                {
                    var n = q[1];
                    if (oddRest >= n)
                    {
                        oddRest -= n;
                        oddHistory += n;
                        history += oddNum * n;
                        allRest = Math.Min(allRest, oddRest);
                    }
                }
                else if (q[0] == 3)
                {
                    var n = q[1];
                    if (allRest >= n)
                    {
                        allRest -= n;
                        oddRest -= n;
                        allHistory += n;
                        history += N * n;
                    }
                }
            }

            return history;
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