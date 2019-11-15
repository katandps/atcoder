using System;
using System.Linq;

namespace ABC139B
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] AB = CIN.IntArray();
            int A = AB[0];
            int B = AB[1];

            if (B == 1)
            {
                Console.WriteLine(0);
                return;
            }

            if (B <= A)
            {
                Console.WriteLine(1);
                return;
            }

            int cnt = 0;
            while (true)
            {
                if (1 + (A - 1) * cnt >= B)
                {
                    Console.WriteLine(cnt);
                    return;
                }

                cnt++;
            }
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