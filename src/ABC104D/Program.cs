using System;
using System.Linq;

namespace ABC104D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = ConsoleInput.String();

            long qCount = 0;
            for (var i = 0; i < s.Length; i++)
                if (s[i] == '?')
                    qCount++;

            var three = new long[qCount + 1];
            var big = Convert.ToInt64(Math.Pow(10, 9)) + 7;
            three[0] = 1;
            for (long i = 1; i <= qCount; i++) three[i] = three[i - 1] * 3 % big;

            var count = Count(s, 'A', 'B', 'C') * three[qCount] % big;
            if (qCount > 0)
            {
                count = (count + Count(s, '?', 'B', 'C') * three[qCount - 1] % big) % big;
                count = (count + Count(s, 'A', '?', 'C') * three[qCount - 1] % big) % big;
                count = (count + Count(s, 'A', 'B', '?') * three[qCount - 1] % big) % big;
            }

            if (qCount > 1)
            {
                count = (count + Count(s, 'A', '?', '?') * three[qCount - 2] % big) % big;
                count = (count + Count(s, '?', 'B', '?') * three[qCount - 2] % big) % big;
                count = (count + Count(s, '?', '?', 'C') * three[qCount - 2] % big) % big;
            }

            if (qCount > 2) count = (count + Count(s, '?', '?', '?') * three[qCount - 3] % big) % big;

            Console.WriteLine(count % big);
        }

        public static long Count(string s, char A, char B, char C)
        {
            var dp = new int[s.Length + 1][];
            for (var i = 0; i <= s.Length; i++) dp[i] = new int[4];

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == A)
                    dp[i + 1][1] = 1 + dp[i][1];
                else
                    dp[i + 1][1] = dp[i][1];

                if (s[i] == B)
                    dp[i + 1][2] = dp[i][1] + dp[i][2];
                else
                    dp[i + 1][2] = dp[i][2];

                if (s[i] == C)
                    dp[i + 1][3] = dp[i][2] + dp[i][3];
                else
                    dp[i + 1][3] = dp[i][3];
            }

            return dp[s.Length][3];
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