using System;
using System.Linq;

namespace AGC027B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var NX = Input.LongArray();
            var N = NX[0];
            var X = NX[1];
            var Xi = Input.LongArray();


            Array.Reverse(Xi);

            var Carry = Xi[0];

            var Carrying = 0;
            for (var i = 1; i < N; i++)
            {
                Carrying++;
                Carry += CarryingCost(Carrying) * (Xi[i - 1] - Xi[i]);
                if (Xi[i] * CarryingCost(Carrying + 1) >= Xi[i] * CarryingCost(Carrying) + Xi[i] * CarryingCost(0) + X)
                {
                    Carry += Xi[i] * CarryingCost(Carrying) + Xi[i] * CarryingCost(0) + X;
                    Carrying = 0;
                }
            }

            Carrying++;
            Carry += Math.Min(Xi[N - 1] * CarryingCost(Carrying),
                Xi[N - 1] * (CarryingCost(0) + CarryingCost(1)) + X);
            Console.WriteLine(X * (N + 1) + Carry);
        }

        private static int CarryingCost(int carrying)
        {
            return (carrying + 1) * (carrying + 1);
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