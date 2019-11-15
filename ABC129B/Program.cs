using System;
using System.Linq;

namespace ABC129B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = CIN.Int();
            var W = CIN.LongArray();

            var Sum = W.Sum();
            var ans = Sum;
            long temp = 0;
            for (int i = 0; i < N; i++)
            {
                temp += W[i];
                ans = Math.Min(ans, Math.Abs(Sum - 2 * temp));
            }
            Console.WriteLine(ans);
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