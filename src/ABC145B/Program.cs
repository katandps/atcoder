using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC145B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Cin.Int();
            var S = Cin.String();
            var solver = new Solver(N, S);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private int N;
        private string S;
        public Solver(int n, String s)
        {
            N = n;
            S = s;
        }

        public IConvertible Solve()
        {
            if (N % 2 == 1)
            {
                return "No";
            }

            for (int i = 0; i < N / 2; i++)
            {
                if (S[i] != S[i + N / 2])
                {
                    return "No";
                }
            }
            return "Yes";
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