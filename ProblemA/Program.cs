using System;
using System.Linq;

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = CIN.String();

            char initial = S[0];

            for (int i = 1; i < 4; i++)
            {
                if (initial == S[i])
                {
                    Console.WriteLine("Bad");
                    return;
                }

                initial = S[i];
            }
            Console.WriteLine("Good");
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