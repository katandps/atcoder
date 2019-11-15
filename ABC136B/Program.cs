using System;
using System.Linq;

namespace ABC136B
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();

            long ans = 0;
            for (int i = 1; i <= N; i++)
            {
                if (i.ToString().Length % 2 == 1)
                {
                    ans++;
                }
            }
            Console.WriteLine(ans);
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