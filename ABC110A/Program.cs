using System;
using System.Linq;

namespace ABC110A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Input.IntArray();
            var A = ints[0];
            var B = ints[1];
            var C = ints[2];

            if (A >= B)
                if (A >= C)
                {
                    Console.WriteLine(10 * A + B + C);
                    return;
                }

            if (B >= A)
                if (B >= C)
                {
                    Console.WriteLine(10 * B + C + A);
                    return;
                }

            if (C >= A)
                if (C >= B)
                    Console.WriteLine(10 * C + A + B);
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