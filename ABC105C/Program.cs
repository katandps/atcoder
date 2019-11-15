using System;
using System.Linq;

namespace ABC105C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = ConsoleInput.Long();

            if (N == 0)
            {
                Console.WriteLine("0");
                return;
            }

            Console.WriteLine(Minus2(N));
        }

        private static string Minus2(long N)
        {
            if (N < 0) return "";
            if (N == 0) return "0";

            var Pow = new long[40];
            Pow[0] = 1;
            for (var i = 1; i < 40; i++) Pow[i] = -2 * Pow[i - 1];

            long[] oddsum =
            {
                2, 10, 42,
                170, 682, 2730,
                10922, 43690, 174762,
                699050, 2796202, 11184810,
                44739242, 178956970, 715827882,
                2863311530
            };
            long[] evensum =
            {
                1, 5, 21,
                85, 341, 1365,
                5461, 21845, 87381,
                349525, 1398101, 5592405,
                22369621, 89478485, 357913941,
                1431655765
            };

            int u;
            long j;
            for (u = 0;; u++)
                if (evensum[u] > N)
                {
                    j = 1 << (2 * u);
                    break;
                }

            var sum = j;
            var k = 0;
            do
            {
                if (sum < N)
                {
                    u = 0;
                    while (N < evensum[u] + sum) u++;
                    j = j + (1 << (2 * u));
                }
                else if (sum > N)
                {
                    u = 0;
                    while (N < sum - oddsum[u]) u++;
                    j = j + (1 << (2 * u + 1));
                }

                sum = 0;
                for (var i = 1; i <= j; i <<= 1)
                {
                    if ((j & i) != 0)
                        sum += Pow[k];
                    k++;
                }
            } while (sum != N);

            var ans = "";

            for (var i = 1; i <= j; i <<= 1) ans = ans + ((j & i) != 0 ? '1' : '0');

            return ans;
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