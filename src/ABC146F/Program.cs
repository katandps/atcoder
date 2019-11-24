using System;
using System.Collections.Generic;
using System.Linq;

//[WIP]
namespace ABC146F
{
    class Program
    {
        static void Main(string[] args)
        {
            var nm = Cin.LArr();
            var solver = new Solver(nm[0], nm[1], Cin.String());
            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long N;
        private long M;
        private string S;

        public Solver(long n, long m, string s)
        {
            N = n;
            M = m;
            S = s;
        }

        public IConvertible Solve()
        {
            var rev = S.Reverse().ToArray();

            List<long> ans = new List<long>();
            long walk = 1;
            long rest = N - 1;

            
            
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