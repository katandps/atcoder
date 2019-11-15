using System;
using System.Linq;

namespace ABC144A
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = CIN.LongArray();
            var A = AB[0];
            var B = AB[1];

            if (A > 9 || B > 9)
            {
                Console.WriteLine(-1);
                return;
            }
            
            Console.WriteLine(A * B);
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