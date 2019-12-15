using System;
using System.Collections.Generic;
using System.Linq;

namespace PAST001B
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
            var solver = new Solver(a);
            solver.Solve();
        }
    }

    class Solver
    {
        private long[] A;

        public Solver(long[] a)
        {
            A = a;
        }

        public IConvertible Solve()
        {
            long before = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (before == A[i])
                {
                    Console.WriteLine("stay");
                }
                else if (before > A[i])
                {
                    Console.WriteLine("down " + (before - A[i]));
                }
                else
                {
                    Console.WriteLine("up " + (A[i] - before));
                }

                before = A[i];
            }

            return 0;
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