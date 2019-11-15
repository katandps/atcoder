using System;
using System.Linq;

namespace ABC112A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var Num = Input.Int();
            if (Num == 1)
            {
                Console.WriteLine("Hello World");
                return;
            }

            var A = Input.Int();
            var B = Input.Int();
            Console.WriteLine(A + B);
        }
    }

    internal static class Input
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