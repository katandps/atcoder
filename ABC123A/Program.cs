using System;
using System.Linq;

namespace ABC123A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a = ConsoleInput.Int();
            int b = ConsoleInput.Int();
            int c = ConsoleInput.Int();
            int d = ConsoleInput.Int();
            int e = ConsoleInput.Int();
            int k = ConsoleInput.Int();

            if (e - a > k)
            {
                Console.WriteLine(":(");
                return;
            }
            Console.WriteLine("Yay!");
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