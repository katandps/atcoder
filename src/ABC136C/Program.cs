using System;
using System.Linq;

namespace ABC136C
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();
            long[] H = CIN.LongArray();

            int down = 0;
            long before = H[0];
            for (int i = 1; i < N; i++)
            {
                if (before - H[i] > 1)
                {
                    Console.WriteLine("No");
                    return;
                }

                if (before - H[i] == 1)
                {
                    down++;

                    if (down > 1)
                    {
                        Console.WriteLine("No");
                        return;
                    }

                    before = H[i];
                    continue;
                }

                if (before - H[i] == 0)
                {
                    before = H[i];
                    continue;
                }

                down = 0;
                before = H[i];
            }
            Console.WriteLine("Yes");
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