using System;
using System.Linq;

namespace ABC109A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = ConsoleInput.IntArray();
            var A = ints[0];
            var B = ints[1];
            if ((A % 2 == 0) | (B % 2 == 0))
            {
                Console.WriteLine("No");
                return;
            }

            Console.WriteLine("Yes");
        }
    }


    internal static class ConsoleInput
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