using System;
using System.Linq;

namespace ABC123B
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

            int ans = 0;
            int[] order = new int[] {a, b, c, d, e};

            int min = 10;
            for (int i = 0; i < 5; i++)
            {
                if (order[i] % 10 == 0)
                {
                    continue;
                }

                min = Math.Min(min, order[i] % 10);
                order[i] = order[i] + 10 - order[i] % 10;
            }

            if (min == 10)
            {
                Console.WriteLine(order.Sum());
                return;
            }

            Console.WriteLine(order.Sum() - 10 + min);
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