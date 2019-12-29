using System;
using System.Collections.Generic;
using System.Linq;

namespace PAST001D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Cin.Long();
            long[] a = new long[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = Cin.Long();
            }
            var solver = new Solver(n, a);

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
            Array.Sort(A);
            long before = 0;
            long lost = -1;
            long gain = -1;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == before + 2)
                {
                    lost = before + 1;
                }

                if (A[i] == before)
                {
                    gain = before;
                }

                before = A[i];
            }

            if (A[N - 1] != N)
            {
                lost = N;
            }

            if (lost > 0)
            {
                return "" + gain + " " + lost;
            }
            return "Correct";
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