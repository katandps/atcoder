using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC136E
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NK = CIN.LongArray();
            long N = NK[0];
            long K = NK[1];
            long[] A = CIN.LongArray();

            long Sum = A.Sum();
            List<long> Factors = new List<long>();
            var root = Math.Sqrt(Sum);
            for (int i = 1; i <= root; i++)
            {
                if (Sum % i == 0)
                {
                    Factors.Add(i);
                }
            }

            int fs = Factors.Count;
            for (int i = 0; i < fs; i++)
            {
                Factors.Add(Sum / Factors[i]);
            }

            long ans = 1;
            foreach (long factor in Factors)
            {
                if (factor == 1)
                {
                    continue;
                }

                long[] AA = new long[N];
                for (int i = 0; i < N; i++)
                {
                    AA[i] = A[i] % factor;
                }
                Array.Sort(AA);

                long[] Upp = new long[N];
                long[] Low = new long[N];
                Upp[0] = AA[0];
                Low[N - 1] = factor - AA[N - 1];
                for (int i = 1; i < N; i++)
                {
                    Upp[i] = Upp[i - 1] + AA[i];
                }

                for (int i = (int)N - 2; i >= 0; i--)
                {
                    Low[i] = Low[i + 1] + (factor - AA[i]);
                }

                for (int i = 0; i < N - 1; i++)
                {
                    if (Upp[i] == Low[i + 1] && Upp[i] <= K)
                    {
                        ans = Math.Max(factor, ans);
                        break;
                    }

                    if (Low[i] == Upp[i + 1] && Upp[i] <= K)
                    {
                        ans = Math.Max(factor, ans);
                        break;
                    }
                }
            }
            
            Console.WriteLine(ans);
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