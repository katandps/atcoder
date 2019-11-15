using System;
using System.Linq;

namespace AGC029A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var S = Input.String();

            long ans = 0;
            var white = 0;
            for (var i = 0; i < S.Length; i++)
                if (S[i] == 'W')
                {
                    ans += i - white;
                    white++;
                }

            Console.WriteLine(ans);
        }
    }

    internal static class Input
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