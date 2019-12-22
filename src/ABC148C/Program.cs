using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC148C
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = Cin.LArr();
            var solver = new Solver(ab[0], ab[1]);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long A;
        private long B;
        public Solver(long a, long b)
        {
            A = a;
            B = b;
        }

        public IConvertible Solve()
        {
            return A * B / Gcd(A,B);
        }
        
        public static long Gcd(long a, long b)
        {
            if (a < b)
                // 引数を入替えて自分を呼び出す
                return Gcd(b, a);
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
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