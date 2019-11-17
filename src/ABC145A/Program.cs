using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC145A
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = Cin.Long();
            var solver = new Solver(v);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long R;
        public Solver(long r)
        {
            R = r;
        }

        public IConvertible Solve()
        {
            return R * R;
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