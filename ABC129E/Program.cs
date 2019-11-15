using System;
using System.Linq;

namespace ABC129E
{
    class Program
    {
        static void Main(string[] args)
        {
            string L = CIN.String();
            var Solver = new Solver();
            Solver.solve(L);
        }
    }

    class Solver
    {
        long MOD = 1000000007;

        public void solve(string L)
        {
            Console.WriteLine(s(L, 2));
        }

        long s(string L, long stack)
        {
            if (L == "0")
            {
                return 1;
            }

            long free = 1;
            for (int i = 1; i < L.Length; i++)
            {
                free = free * 3 % MOD;
            }

            int one = L.Substring(1, L.Length - 1).IndexOf('1');
            if (one < 0)
            {
                return (free + stack) % MOD;
            }

            return free + s(L.Substring(one + 1, L.Length - 1 - one), stack * 2 % MOD);
        }
    }


    internal static class CIN
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int[] IntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(Console.ReadLine());
        }

        public static long[] LongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static double[] DoubleArray()
        {
            return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        }
    }
}