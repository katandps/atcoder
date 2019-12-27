using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC135D
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Cin.String();
            var solver = new Solver(s);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private string S;
        private long MOD = 1000000007;

        public Solver(string s)
        {
            S = s;
        }

        public IConvertible Solve()
        {
            Dictionary<int, long>[] dp = new Dictionary<int, long>[S.Length + 1];
            for (int i = 0; i <= S.Length; i++)
            {
                dp[i] = new Dictionary<int, long>();
                for (int j = 0; j < 13; j++)
                {
                    dp[i].Add(j, 0);
                }
            }

            dp[0][0] = 1;

            int m = 1;
            for (int i = 0; i < S.Length; i++)
            {
                var c = S[S.Length - 1 - i];
                if (c == '?')
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < 13; k++)
                        {
                            var key = (k + m * j % 13) % 13;
                            dp[i + 1][key] = (dp[i + 1][key] + dp[i][k]) % MOD;
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < 13; k++)
                    {
                        var key = (k + m * int.Parse(c.ToString())) % 13;
                        dp[i + 1][key] += dp[i][k];
                    }
                }

                m = m * 10 % 13;
            }

            return dp[S.Length][5];
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