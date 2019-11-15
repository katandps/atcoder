using System;
using System.Linq;

namespace AGC36A
{
    class Program
    {
        static void Main(string[] args)
        {
            long S = CIN.Long();

            long Sroot = (long) Math.Ceiling(Math.Sqrt(S));
            Console.WriteLine(Sroot);
            long X1 = Sroot;
            long Y2 = Sroot;

            long rest = Sroot * Sroot - S;

            long Y1 = 1;

            long A = 0;
            for (int i = 2; i < Sroot && i < rest; i++)
            {
                if (Sroot % i == rest % i)
                {
                    A = Sroot % i;
                    break;
                }
            }

            long X2 = A;
            long Y3 = (rest - A) / (Sroot - A);

            Console.WriteLine(Math.Abs(X1 * (Y2 - Y3) - X2 * (Y1 - Y3)));
            Console.WriteLine("0 " + Y3 + " " + X1 + " " + Y1 + " " + X2 + " " + Y2);
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