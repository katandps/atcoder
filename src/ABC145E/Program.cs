using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC145E
{
    class Program
    {
        static void Main(string[] args)
        {
            var nt = Cin.LArr();
            long[] a = new long[nt[0]];
            long[] b = new long[nt[0]];
            for (int i = 0; i < nt[0]; i++)
            {
                var ab = Cin.LArr();
                a[i] = ab[0];
                b[i] = ab[1];
            }
            var solver = new Solver(nt[0], nt[1], a, b);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long N;
        private long T;
        private long[] A;
        private long[] B;
        public Solver(long n, long t, long[] a, long[]b)
        {
            N = n;
            T = t;
            A = a;
            B = b;
        }

        public IConvertible Solve()
        {
            
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