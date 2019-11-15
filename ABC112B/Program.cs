using System;
using System.Linq;

namespace ABC112B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Input.IntArray();
            var N = ints[0];
            var T = ints[1];

            var costs = new int[N];
            for (var i = 0; i < N; i++)
            {
                var inputs = Input.IntArray();
                if (inputs[1] <= T)
                {
                    costs[i] = inputs[0];
                    continue;
                }

                costs[i] = int.MaxValue;
            }

            if (costs.Min() == int.MaxValue)
            {
                Console.WriteLine("TLE");
                return;
            }

            Console.WriteLine(costs.Min());
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