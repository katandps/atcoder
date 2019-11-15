using System;
using System.Linq;

namespace ABC127A
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] AB = CIN.IntArray();

            if (AB[0] > 12)
            {
                Console.WriteLine(AB[1]);
                return;
            }

            if (AB[0] > 5)
            {
                Console.WriteLine(AB[1]/2);
                return;
            }
            Console.WriteLine(0);
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