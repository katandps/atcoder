using System;
using System.Linq;

namespace ABC104B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = ConsoleInput.String();
            if (s[0] != 'A')
            {
                Console.WriteLine("WA");
                return;
            }

            var cPos = 0;
            for (var i = 2; i < s.Length - 1; i++)
                if (s[i] == 'C')
                {
                    if (cPos != 0)
                    {
                        Console.WriteLine("WA");
                        return;
                    }

                    cPos = i;
                }

            if (cPos == 0)
            {
                Console.WriteLine("WA");
                return;
            }

            var chars = "abcdefghijklmnopqrstuvwxyz";
            for (var i = 1; i < s.Length; i++)
            {
                if (i == cPos) continue;

                if (!chars.Contains(s[i]))
                {
                    Console.WriteLine("WA");
                    return;
                }
            }

            Console.WriteLine("AC");
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