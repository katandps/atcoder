using System;
using System.Linq;

namespace ABC133C
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] LR = CIN.LongArray();

            for (long i = LR[0]; i <= LR[1]; i++)
            {
                if (i % 2019 == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
            }

            long min = 2018;
            for (long i = LR[0]; i < LR[1]; i++)
            {
                for (long j = i + 1; j <= LR[1]; j++)
                {
                    min = Math.Min(min, i % 2019 * (j % 2019) % 2019);
                }
            }
            
            Console.WriteLine(min);
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