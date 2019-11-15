using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC109D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = ConsoleInput.IntArray();
            var H = ints[0];
            var W = ints[1];
            var Map = new int[H][];
            for (var i = 0; i < H; i++) Map[i] = ConsoleInput.IntArray();

            var cmd = new List<string>();
            var Cmds = 0;
            for (var i = 0; i < H; i++)
            for (var j = 0; j < W - 1; j++)
                if (Map[i][j] % 2 != 0)
                {
                    cmd.Add("" + (i + 1) + " " + (j + 1) + " " + (i + 1) + " " + (j + 2) + "\n");
                    Cmds++;
                    Map[i][j]--;
                    Map[i][j + 1]++;
                }

            for (var i = 0; i < H - 1; i++)
                if (Map[i][W - 1] % 2 != 0)
                {
                    cmd.Add("" + (i + 1) + " " + W + " " + (i + 2) + " " + W + "\n");
                    Cmds++;
                    Map[i][W - 1]--;
                    Map[i + 1][W - 1]++;
                }

            var Ans = string.Join("", cmd.ToArray());
            Console.WriteLine("" + Cmds + "\n" + Ans);
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