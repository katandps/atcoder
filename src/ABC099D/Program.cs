using System;
using System.Linq;

namespace ABC099D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = ints[0];
            var c = ints[1];

            var ds = new int[c][];
            for (var i = 0; i < c; i++)
            {
                var dline = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                ds[i] = dline;
            }

            var cs = new int[n][];
            for (var i = 0; i < n; i++)
            {
                var cline = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                cs[i] = cline;
            }

            var scores = new int[3][];
            for (var i = 0; i < 3; i++) scores[i] = score(cs, ds, i, n, c);

            var patterns = new int[c * c * c];
            for (var i = 0; i < c; i++)
            for (var j = 0; j < c; j++)
            for (var k = 0; k < c; k++)
            {
                if (i == j || i == k || j == k)
                {
                    patterns[i + c * j + c * c * k] = int.MaxValue;
                    continue;
                }

                patterns[i + c * j + c * c * k] = scores[0][i] + scores[1][j] + scores[2][k];
            }

            Console.WriteLine(patterns.Min());
        }

        public static int[] score(int[][] cs, int[][] ds, int offset, int n, int c)
        {
            var space = n * n;

            var scores = new int[c];
            for (var colorIndex = 0; colorIndex < c; colorIndex++)
            for (var i = 0; i < space; i++)
            {
                var ndiv = i / n;
                var ndiva = i % n;
                if ((ndiv + ndiva) % 3 != offset) continue;

                var currentColorIndex = cs[ndiv][ndiva] - 1;
                var score = ds[currentColorIndex][colorIndex];
                scores[colorIndex] += score;
            }

            return scores;
        }
    }
}