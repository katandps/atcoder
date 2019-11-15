using System;
using System.Linq;

namespace ABC137A
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] AB = CIN.IntArray();
            Console.WriteLine(Math.Max(AB[0] + AB[1], Math.Max(AB[0] - AB[1], AB[0] * AB[1])));
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