using System;
using System.Collections.Generic;
using System.Linq;

namespace PAST001F
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Cin.String();
            var solver = new Solver(s);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private string S;
        public Solver(string s)
        {
            S = s;
        }

        public IConvertible Solve()
        {
            List<string> l = new List<string>();

            var first = -1;
            for (int i = 0; i < S.Length; i++)
            {
                if (first == -1)
                {
                    first = i;
                    continue;
                }

                if (S[i] >= 'A' && S[i] <= 'Z')
                {
                    l.Add(S.Substring(first, i - first + 1));
                    first = -1;
                }
            }

            var la = l.ToArray();
            Array.Sort(la);
            foreach (string  s in la)
            {
                Console.Write(s);
            }
            return "";
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