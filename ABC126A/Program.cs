using System;
using System.Linq;

namespace ABC126A
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NK = CIN.IntArray();
            string S = CIN.String();

            for (int i = 0; i < NK[0]; i++)
            {
                if (i == NK[1]-1)
                {
                    Console.Write((char)(S[i] - ('A' - 'a')));
                    continue;
                }
                Console.Write(S[i]);
            }

            Console.WriteLine();
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