using System;
using System.Linq;

namespace ABC125C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long N = ConsoleInput.Long();
            long[] A = ConsoleInput.LongArray();

            long[] gcdRight = new long[N];
            long[] gcdLeft = new long[N];
            gcdLeft[0] = A[0];
            gcdRight[N - 1] = A[N - 1];
            for (int i = 0; i < N-1; i++)
            {
                gcdLeft[i + 1] = Gcd(gcdLeft[i], A[i + 1]);
                gcdRight[N - i - 2] = Gcd(gcdRight[N - i - 1], A[N - i - 2]);
            }

            long ans = gcdRight[1];
            for (int i = 0; i < N - 2; i++)
            {
                ans = Math.Max(ans, Gcd(gcdLeft[i], gcdRight[i + 2]));
            }

            ans = Math.Max(ans, gcdLeft[N - 2]);
            Console.WriteLine(ans);
        }
        
        
        public static long Gcd(long a, long b)
        {
            return b > 0 ? Gcd(b, a % b) : a;
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