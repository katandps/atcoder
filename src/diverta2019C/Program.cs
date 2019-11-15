using System;
using System.Linq;

namespace diverta2019C
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = CIN.Int();
            string[] S = new string[N];
            for (int i = 0; i < N; i++)
            {
                S[i] = CIN.String();
            }

            int tailA = 0;
            int startB = 0;
            int containAB = 0;
            for (int i = 0; i < N; i++)
            {
                
                bool A = false;
                for (int j = 0; j < S[i].Length; j++)
                {
                    if (S[i][j] == 'A')
                    {
                        A = true;
                        continue;
                    }
                    if (A && S[i][j] == 'B')
                    {
                        containAB++;
                    }
                    A = false;
                }
                if (S[i][0] == 'B')
                {
                    startB++;
                    continue;
                }

                if (S[i][S[i].Length - 1] == 'A')
                {
                    tailA++;
                }
            }
            
            Console.WriteLine(containAB + Math.Min(N - 1, Math.Min(tailA, startB)));
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