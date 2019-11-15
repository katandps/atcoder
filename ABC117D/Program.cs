using System;
using System.Linq;

namespace ABC117D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] NK = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            long N = NK[0];
            long K = NK[1];
            long[] A = Console.ReadLine().Split(' ').Select(b => long.Parse(b)).ToArray();

            int[] bits = new int[50];

            for (int i = 0; i < N; i++)
            {
                long Ai = A[i];
                for (int j = 0; j < 50; j++)
                {
                    if (Ai % 2 == 1)
                    {
                        bits[j]++;
                    }

                    Ai = Ai >> 1;
                    if (Ai == 0)
                    {
                        break;
                    }
                }
            }

            bool[] Kbit = new bool[50];
            long KK = K;
            long bit = 1;
            for (int i = 0; i < 49; i++)
            {
                if (KK % 2 == 1)
                {
                    Kbit[i] = true;
                }

                bit *= 2;
                KK = KK >> 1;
            }

            long ans = 0;
            bool any = false;
            for (int i = 49; i >= 0; i--)
            {
                if (any | Kbit[i])
                {
                    if (N - bits[i] < bits[i])
                    {
                        any = true;
                    }
                    ans += Math.Max(N - bits[i], bits[i]) * bit;
                }
                else
                {
                    ans += bits[i] * bit;
                }

                bit /= 2;
            }

            Console.WriteLine(ans);
        }
    }
}