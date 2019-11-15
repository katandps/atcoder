using System;
using System.Linq;

namespace AGC027A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var nx = Input.LongArray();
            var N = nx[0];
            var X = nx[1];

            var A = Input.LongArray();

            Array.Sort(A);
            var rest = X;
            var count = 0;
            for (var i = 0; i < N - 1; i++)
            {
                if (A[i] > rest) break;

                count++;
                rest -= A[i];
            }

            if (A[N - 1] == rest) count++;
            Console.WriteLine(count);
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