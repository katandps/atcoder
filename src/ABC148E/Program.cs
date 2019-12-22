using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC148E
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Cin.Long();
            var solver = new Solver(n);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long N;

        public Solver(long n)
        {
            N = n;
        }

        public IConvertible Solve()
        {
            if (N % 2 == 1)
            {
                return 0;
            }

            long ans = 0;
            long five = 5;
            for (int i = 1; i <= 25; i++)
            {
                ans += N / five / 2;
                five *= 5;
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