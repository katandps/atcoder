using System;
using System.Linq;

namespace ABC104A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var r = ConsoleInput.Int();
            if (r < 1200)
            {
                Console.WriteLine("ABC");
                return;
            }

            if (r < 2800)
            {
                Console.WriteLine("ARC");
                return;
            }

            Console.WriteLine("AGC");
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