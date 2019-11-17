using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC145C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Cin.Int();
            int[] X = new int[N];
            int[] Y = new int[N];
            for (int i = 0; i < N; i++)
            {
                var xy = Cin.IArr();
                X[i] = xy[0];
                Y[i] = xy[1];
            }

            var solver = new Solver(N, X, Y);
            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        public int N;
        public int[] X;
        public int[] Y;

        public Solver(int n, int[] x, int[] y)
        {
            N = n;
            X = x;
            Y = y;
        }

        public IConvertible Solve()
        {
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sum += Math.Sqrt((X[j] - X[i]) * (X[j] - X[i]) + (Y[j] - Y[i]) * (Y[j] - Y[i])) / N;
                }
            }

            return sum;
        }
    }

    internal static class Cin
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(String());
        }

        public static int[] IArr()
        {
            return Split().Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(String());
        }

        public static long[] LArr()
        {
            return Split().Select(long.Parse).ToArray();
        }

        public static double Double()
        {
            return double.Parse(String());
        }

        public static double[] DArr()
        {
            return Split().Select(double.Parse).ToArray();
        }

        private static IEnumerable<String> Split()
        {
            return String().Split(' ');
        }
    }
}