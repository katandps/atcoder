using System;
using System.Linq;

namespace ABC137C
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Int();
            string[] S = new string[N];
            for (int i = 0; i < N; i++)
            {
                char[] A =  CIN.String().ToCharArray();
                Array.Sort(A);
                S[i] = new string(A);
            }
            Array.Sort(S);

            string first = S[0];
            long ans = 0;
            long cur = 0;
            for (int i = 1; i < N; i++)
            {
                if (first.Equals(S[i]))
                {
                    cur++;
                    continue;
                }

                first = S[i];
                ans += (cur + 1) * cur / 2;
                cur = 0;
            }

            ans += (cur + 1) * cur / 2;
            
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