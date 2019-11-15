using System;
using System.Linq;

namespace AGC034A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NABCD = CIN.IntArray();
            string S = CIN.String();
            var N = NABCD[0];
            var A = NABCD[1];
            var B = NABCD[2];
            var C = NABCD[3];
            var D = NABCD[4];

            var BiggerGoal = Math.Max(C, D);
            bool Rock = false;
            int maxF = 0;
            int curF = 0;
            for (var i = A - 1; i < BiggerGoal; i++)
            {
                if (S[i] == '#')
                {
                    if (Rock)
                    {
                        Console.WriteLine("No");
                        return;
                    }

                    Rock = true;
                    curF = 0;
                    continue;
                }

                if (i >= B - 2 && i <= Math.Min(C, D))
                {
                    curF++;
                    maxF = Math.Max(maxF, curF);
                }

                Rock = false;
            }

            if (D < C)
            {
                if (maxF < 3)
                {
                    Console.WriteLine("No");
                    return;
                }
            }

            Console.WriteLine("Yes");
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