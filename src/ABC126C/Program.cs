using System;
using System.Linq;

namespace ABC126C
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NK = CIN.LongArray();
            long N = NK[0];
            long K = NK[1];

            double ans = 0.0;

            int pow = 1;
            double rate = 1;
            for (long i = N; i > 0; i--)
            {
                while (true)
                {
                    if (i * pow >= K)
                    {
                        double a = rate;
                        ans += a;
                        break;
                    }

                    pow *= 2;
                    rate /= 2;
                }
            }
            Console.WriteLine(ans/N);
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