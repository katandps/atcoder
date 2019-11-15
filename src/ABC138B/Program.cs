using System;
using System.Linq;

namespace ABC138B
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = CIN.Int();

            double ans = 0;
            
            double[] a = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();;
            for (int i = 0; i < n; i++)
            {
                
                ans += 1 / a[i];
            }
            
            Console.WriteLine(1/ans);
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