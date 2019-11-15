using System;
using System.Linq;

namespace ABC127B
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RDX = CIN.IntArray();

            int r = RDX[0];
            int D = RDX[1];
            int X = RDX[2];

            int A = X;
            for (int i = 0; i < 10; i++)
            {
                A = r * A - D;
                Console.WriteLine(A);
            }
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