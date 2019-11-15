using System;
using System.Linq;

namespace Exa2019C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] nq = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            string s = Console.ReadLine();
            char[][] qs = new char[nq[1]][];
            for (int i = 0; i < nq[1]; i++)
            {
                qs[i] = Console.ReadLine().Split(' ').Select(a => char.Parse(a)).ToArray();
            }

            Array.Reverse(qs);

            int[][] dp = new int[nq[1] + 1][];
            dp[0] = new[] {0, nq[0] - 1};

            for (int i = 1; i <= nq[1]; i++)
            {
                char[] query = qs[i - 1];
                dp[i] = new int[2];
                dp[i][0] = dp[i - 1][0];
                dp[i][1] = dp[i - 1][1];

                if (dp[i][0] > dp[i][1])
                {
                    continue;
                }

                if (query[1] == 'R')
                {
                    if (s[dp[i][1]] == query[0])
                    {
                        dp[i][1]--;
                        dp[i][0] = Math.Max(dp[i][0] - 1, 0);
                    }
                }

                if (query[1] == 'L')
                {
                    if (s[dp[i][0]] == query[0])
                    {
                        dp[i][0]++;
                        dp[i][1] = Math.Min(dp[i][0] + 1, nq[1] - 1);
                    }
                }
            }

            long ans = nq[0];
            long leftMax = 0;
            long rightMin = nq[0];
            for (int i = 0; i <= nq[1]; i++)
            {
                leftMax = Math.Max(leftMax, dp[i][0]);
                rightMin = Math.Min(rightMin, dp[i][1]);
            }

            ans -= leftMax;
            ans -= nq[0] - rightMin - 1;

            Console.WriteLine(leftMax);
            Console.WriteLine(rightMin);
            Console.WriteLine(ans);
        }
    }
}