using System;
using System.Linq;

namespace ABC136A
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] ABC = CIN.LongArray();

            long A = ABC[0];
            long B = ABC[1];
            long C = ABC[2];

            if (A - B > C)
            {
                Console.WriteLine(0);
                return;
            }
            Console.WriteLine(C - A + B);
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