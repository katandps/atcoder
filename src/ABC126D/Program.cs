using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC126D
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();
            Dictionary<long, List<Point>> pool = new Dictionary<long, List<Point>>();
            for (int i = 0; i < N - 1; i++)
            {
                long[] UVR = CIN.LongArray();
                if (pool.ContainsKey(UVR[0]-1))
                {
                    pool[UVR[0] - 1].Add(new Point(UVR[1] - 1, UVR[2]));
                }

                if (pool.ContainsKey(UVR[1]-1))
                {
                    pool[UVR[1] - 1].Add(new Point(UVR[0] - 1, UVR[2]));
                }

                if (!pool.ContainsKey(UVR[0]-1))
                {
                    pool.Add(UVR[0] - 1, new List<Point>() {new Point(UVR[1] - 1, UVR[2])});
                }

                if (!pool.ContainsKey(UVR[1]-1))
                {
                    pool.Add(UVR[1] - 1, new List<Point>() {new Point(UVR[0] - 1, UVR[2])});
                }
            }

            Queue<Point> queue = new Queue<Point>();
            bool[] ans = new bool[N];
            bool[] memo = new bool[N];
            for (int i = 0; i < N; i++)
            {
                ans[i] = false;
                memo[i] = false;
            }

            queue.Enqueue(new Point(0, 0));
            memo[0] = true;
            while (queue.Count > 0)
            {
                var pop = queue.Dequeue();

                foreach (var a in pool[pop.P])
                {
                    if (memo[a.P])
                    {
                        continue;
                    }
                    queue.Enqueue(a);
                    ans[a.P] = ans[pop.P] ^ (a.W % 2 == 1);
                    memo[a.P] = true;
                }
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(ans[i] ? 1 : 0);
            }
        }
    }

    class Point
    {
        public long P;
        public long W;

        public Point(long p, long w)
        {
            P = p;
            W = w;
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