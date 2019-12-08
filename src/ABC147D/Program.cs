using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC147D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Cin.Long();
            var A = Cin.LArr();
            var solver = new Solver(N, A);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long N;
        private long[] A;
        public Solver(long n, long[] a)
        {
            N = n;
            A = a;
        }

        public IConvertible Solve()
        {
            long MOD = 1000000007;

            long ans = 0;
            long n = 1;
            for (int i = 0; i < 61; i++)
            {
                long cx = 0;
                long cy = 0;
                for (int j = 0; j < N; j++)
                {
                    cx += (A[j] >> i) % 2;
                    cy += ((A[j] >> i) % 2) == 0 ? 1 : 0;
                }
                ans = (ans + (cx * cy % MOD) * n) % MOD;
                n *= 2;
                n %= MOD;
            }
            return ans;
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