using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC146C
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver(Cin.LArr());

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long A;
        private long B;
        private long X;
        public Solver(long[]abx)
        {
            A = abx[0];
            B = abx[1];
            X = abx[2];
        }

        public IConvertible Solve()
        {
            long y = 10;
            long max = 0;
            for (int i = 1; i <= 9; i++)
            {
                var x = X - B * i;//桁補正抜きの所持金
                if (x <= 0)
                {
                    continue;
                }
                var a = x / A;//買える最大の整数
                if (a > y - 1)
                {
                    max = Math.Max(max, y - 1);
                }
                else
                {
                    max = Math.Max(max, a);
                }

                y *= 10;
            }

            if (X > A * 1000000000 + B * 10)
            {
                return 1000000000;
            }
            return max;
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