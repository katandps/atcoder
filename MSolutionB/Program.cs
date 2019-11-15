using System;
using System.Linq;

namespace MSolutionB
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = CIN.String();
            int Count = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'o')
                {
                    Count++;
                }
            }

            Count += 15 - S.Length;
            Console.WriteLine(Count >= 8 ? "YES" : "NO");
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