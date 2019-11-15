using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC110D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var longs = Input.LongArray();
            var N = longs[0];
            var M = longs[1];

            var MM = M;
            var factorization = new int[100000];
            for (var i = 2; i < 100000; i++)
            {
                while (MM % i == 0)
                {
                    factorization[i]++;
                    MM /= i;
                }

                if (MM == 1) break;
            }

            var list = new List<int>();
            for (var i = 2; i < 100000; i++)
            {
                if (factorization[i] == 0) continue;
                list.Add(factorization[i]);
            }

            var a = list.ToArray();
            var f = a.Sum();
            long BIG = 1000000007;
            long ans = 0;
            var patterns = N;
            long beforeFact = 0;
            var facto = new Factorial();
            for (var i = 1; i <= N; i++)
            {
                long fact = 1;
                for (var j = 0; j < a.Length; j++)
                {
                    var pow = Convert.ToInt64(Math.Pow(i, a[j])) % BIG;
                    fact = fact * pow % BIG - facto.Get(a[j]) % BIG;
                }

                ans += patterns * fact % BIG;
                patterns = patterns * (N - i) % BIG;
            }

            Console.WriteLine(ans);
        }
    }

    internal class Factorial
    {
        private const long P = 1000000007;
        private readonly long[] fact;

        public Factorial()
        {
            fact = new long[1000];
            fact[0] = 1;
            for (var i = 1; i < 1000; i++) fact[i] = fact[i - 1] * i % P;
        }

        public long Get(int n)
        {
            return fact[n];
        }
    }

    internal static class Input
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