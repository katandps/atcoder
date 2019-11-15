using System;
using System.Linq;

namespace ABC104C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dg = ConsoleInput.IntArray();
            var D = dg[0];
            var G = dg[1];
            var pc = new int[D][];
            for (var i = 0; i < D; i++) pc[i] = ConsoleInput.IntArray();

            var ap = Convert.ToInt32(Math.Pow(2, D));
            var pat = new int[ap];
            var patc = new int[ap];
            for (var i = 0; i < ap; i++)
            {
                pat[i] = 0;
                for (var j = 0; j < D; j++)
                {
                    if ((1 & (i >> j)) == 0) continue;

                    pat[i] += pc[j][0] * (j + 1) * 100 + pc[j][1];
                    patc[i] += pc[j][0];
                }
            }

            var min = patc.Max();
            for (var i = 0; i < ap; i++)
            for (var j = D - 1; j >= 0; j--)
                if ((1 & (i >> j)) == 0)
                {
                    var max = pc[j][0] * (j + 1) * 100 + pat[i];

                    if (G < pat[i])
                    {
                        min = Math.Min(patc[i], min);
                        break;
                    }

                    if (max < G) break;

                    var value = patc[i] + (G - pat[i]) / (j + 1) / 100 +
                                ((G - pat[i]) % ((j + 1) * 100) > 0 ? 1 : 0);
                    min = Math.Min(value, min);
                    break;
                }

            Console.WriteLine(min);
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