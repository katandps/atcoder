using System;
using System.Linq;

namespace ABC123C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long n = ConsoleInput.Long();
            long a = ConsoleInput.Long();
            long b = ConsoleInput.Long();
            long c = ConsoleInput.Long();
            long d = ConsoleInput.Long();
            long e = ConsoleInput.Long();

            long aEnd = n / a + 1 + (n % a == 0 ? 1 : 0);
            long bEnd = Math.Max(aEnd + 1, n / b + 2 + (n % b == 0 ? 1 : 0));
            long cEnd = Math.Max(bEnd + 1, n / c + 3 + (n % c == 0 ? 1 : 0));
            long dEnd = Math.Max(cEnd + 1, n / d + 4 + (n % d == 0 ? 1 : 0));
            long eEnd = Math.Max(dEnd + 1, n / e + 5 + (n % e == 0 ? 1 : 0));
            Console.WriteLine(eEnd);
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