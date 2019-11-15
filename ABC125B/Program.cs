using System;
using System.Linq;

namespace ABC125B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int N = ConsoleInput.Int();
            int[] V = ConsoleInput.IntArray();
            int[] C = ConsoleInput.IntArray();

            int ans = 0;
            for (int i = 0; i < N; i++)
            {
                ans += Math.Max(0, V[i] - C[i]);
            }
            Console.WriteLine(ans);
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