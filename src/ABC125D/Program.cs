using System;
using System.Linq;

namespace ABC125D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long N = ConsoleInput.Long();
            long[] A = ConsoleInput.LongArray();

            long ans = 0;
            long absmin = Int32.MaxValue;
            long minusCount = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] < 0)
                {
                    minusCount++;
                }
                ans += Math.Abs(A[i]);
                absmin = Math.Min(Math.Abs(A[i]), absmin);
            }

            if (minusCount % 2 == 1)
            {
                ans -= 2 * absmin;
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