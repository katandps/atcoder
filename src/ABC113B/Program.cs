using System;
using System.Linq;

namespace ABC113B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = Input.Int();
            var ints = Input.IntArray();
            var T = ints[0];
            var A = ints[1];
            var H = Input.IntArray();

            double diff = int.MaxValue;
            var ans = -1;
            for (var i = 0; i < H.Length; i++)
                if (diff > Math.Abs(A - T + H[i] * 0.006))
                {
                    diff = Math.Abs(A - T + H[i] * 0.006);
                    ans = i;
                }

            Console.WriteLine(ans + 1);
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