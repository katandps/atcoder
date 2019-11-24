using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC146B
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver(Cin.Int(),Cin.String());

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        public int N;
        public string S;
        public Solver(int n, string s)
        {
            N = n;
            S = s;
        }

        public IConvertible Solve()
        {
            int[] ss = new int[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                ss[i] = S[i] + N;
                if (ss[i] > 90)
                {
                    ss[i] -= 26;
                }
            }

            return new String(ss.Select(i => (char)i).ToArray());
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