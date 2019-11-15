using System;
using System.Linq;

namespace ABC105B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = ConsoleInput.Int();

            for (var i = 0; i < 100; i++)
            for (var j = 0; j < 100; j++)
                if (4 * i + 7 * j == N)
                {
                    Console.WriteLine("Yes");
                    return;
                }

            Console.WriteLine("No");
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