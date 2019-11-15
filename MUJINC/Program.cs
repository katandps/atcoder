using System;
using System.Linq;

namespace MUJINC
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arr = ConsoleInput.IntArray();
            var N = arr[0];
            var M = arr[1];

            var square = new string[N];
            for (var i = 0; i < N; i++) square[i] = ConsoleInput.String();

            var right = 0;
            var left = 0;
            var up = 0;
            var down = 0;
            for (var X = 0; X < M; X++)
            for (var Y = 0; Y < N; Y++)
            {
                if (square[Y][X] == '#') continue;

                for (var y = Y + 1; y < N; y++)
                {
                    if (square[y][X] == '#') break;
                    for (var x = X - 1; x >= 0; x--)
                    {
                        if (square[y][x] != '.') break;
                        down++;
                    }
                }

                for (var y = Y - 1; y >= 0; y--)
                {
                    if (square[y][X] == '#') break;
                    for (var x = X + 1; x < M; x++)
                    {
                        if (square[y][x] != '.') break;

                        up++;
                    }
                }

                for (var x = X - 1; x >= 0; x--)
                {
                    if (square[Y][x] == '#') break;
                    for (var y = Y - 1; y >= 0; y--)
                    {
                        if (square[y][x] != '.') break;

                        left++;
                    }
                }

                for (var x = X + 1; x < M; x++)
                {
                    if (square[Y][x] == '#') break;
                    for (var y = Y + 1; y < N; y++)
                    {
                        if (square[y][x] != '.') break;

                        right++;
                    }
                }
            }

            Console.WriteLine(up + down + left + right);
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