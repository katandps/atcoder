using System;
using System.Linq;

namespace ABC110B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Input.IntArray();
            var Xi = Input.IntArray();
            var Yi = Input.IntArray();
            var N = ints[0];
            var M = ints[1];
            var X = ints[2];
            var Y = ints[3];

            var XX = Math.Max(Xi.Max(), X);
            var YY = Math.Min(Yi.Min(), Y);
            if (XX >= YY)
            {
                Console.WriteLine("War");
                return;
            }

            Console.WriteLine("No War");
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