using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC109B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = ConsoleInput.Int();
            var W = new string[N];
            for (var i = 0; i < N; i++) W[i] = ConsoleInput.String();

            var WW = W[0];
            var WL = new Dictionary<string, bool>();
            WL.Add(WW, true);
            for (var i = 1; i < N; i++)
            {
                if ((W[i][0] != WW[WW.Length - 1]) | WL.ContainsKey(W[i]))
                {
                    Console.WriteLine("No");
                    return;
                }

                WL.Add(W[i], true);
                WW = W[i];
            }

            Console.WriteLine("Yes");
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