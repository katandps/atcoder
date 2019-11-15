using System;
using System.Linq;

namespace ABC129D
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] HW = CIN.LongArray();
            long H = HW[0];
            long W = HW[1];
            string[] grid = new string[H];
            for (int i = 0; i < H; i++)
            {
                grid[i] = CIN.String();
            }
            
            int[][] horizontal = new int[H][];

            for (int y = 0; y < H; y++)
            {
                horizontal[y] = new int[W];
                int count = 0;
                for (int x = 0; x < W; x++)
                {
                    if (grid[y][x] == '.')
                    {
                        count++;
                        continue;
                    }

                    if (grid[y][x] == '#')
                    {
                        for (int i = 0; i < count; i++)
                        {
                            horizontal[y][x - i - 1] = count;
                        }

                        count = 0;
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    horizontal[y][W - i - 1] = count;
                }
            }

            int score = 0;
            for (int xx = 0; xx < W; xx++)
            {
                int count = 0;
                for (int yy = 0; yy < H; yy++)
                {
                    if (grid[yy][xx] == '.')
                    {
                        count++;
                        continue;
                    }

                    if (grid[yy][xx] == '#')
                    {
                        for (int i = 0; i < count; i++)
                        {
                            score = Math.Max(score, horizontal[yy - i - 1][xx] + count - 1);
                        }

                        count = 0;
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    score = Math.Max(score, horizontal[H - i - 1][xx] + count - 1);
                }

            }
            Console.WriteLine(score);
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