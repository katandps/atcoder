using System;
using System.Linq;

namespace ARC102E
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = ConsoleInput.IntArray();
            var K = ints[0];
            var N = ints[1];
            var solve = new Solver();
            solve.Solve(K, N);
        }
    }

    internal class Solver
    {
        private const long p = 998244353;
        private int K;
        private int N;

        public void Solve(int k, int n)
        {
            K = k;
            N = n;
            var fact = new Factorial();
            for (var i = 2; i <= K * 2; i++)
            {
                var param = i;
                if (i > K + 1) param = 2 * K + 2 - i;
                var pair = (param - 1) / 2;
                var half = param % 2 == 0;
                if (!half)
                {
                    var ans = (fact.MultiCombination(K - pair, N) - fact.MultiCombination(K - pair * 2, N)) *
                              Convert.ToInt64(Math.Pow(2, pair)) % p;
                    if (K - pair * 2 > 0) ans += fact.MultiCombination(K - pair * 2, N) % p;

                    Console.WriteLine(ans % p);
                    continue;
                }

                Console.WriteLine(1);
            }
        }
    }

    internal class Factorial
    {
        private const long P = 998244353;
        private readonly long[] fact;

        public Factorial()
        {
            fact = new long[4000];
            fact[0] = 1;
            for (var i = 1; i < 4000; i++) fact[i] = fact[i - 1] * i % P;
        }

        public long Get(int n)
        {
            return fact[n];
        }

        public long MultiCombination(int n, int k)
        {
            return Get(n + k - 1) / (Get(n - 1) * Get(k)) % P;
        }
    }

    internal static class ConsoleInput
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