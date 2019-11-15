using System;
using System.Linq;

namespace ABC119D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] ABQ = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            long A = ABQ[0];
            long B = ABQ[1];
            long Q = ABQ[2];

            long[] S = new long[A];
            for (int i = 0; i < A; i++)
            {
                S[i] = long.Parse(Console.ReadLine());
            }

            long[] T = new long[B];
            for (int i = 0; i < B; i++)
            {
                T[i] = long.Parse(Console.ReadLine());
            }

            long[] X = new long[Q];
            for (int i = 0; i < Q; i++)
            {
                X[i] = long.Parse(Console.ReadLine());
            }

            Array.Sort(S);
            Array.Sort(T);
            for (int i = 0; i < Q; i++)
            {
                Console.WriteLine(solve(S, T, X[i]));
            }
        }

        private static long solve(long[] S, long[] T, long X)
        {
            int skey = binary_search(S, X);
            int tkey = binary_search(T, X);
            long sleft = skey == 0 ? long.MinValue/6 : S[skey - 1];
            long sright = skey == S.Length ? long.MaxValue/6 : S[skey];
            long tleft = tkey == 0 ? long.MinValue/6 : T[tkey - 1];
            long tright = tkey == T.Length ? long.MaxValue/6 : T[tkey];
            return calc(sleft, sright, tleft, tright, X);
        }

        private static int binary_search(long[] array, long key)
        {
            int ng = -1;
            int ok = array.Length;

            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;
                if (isOk(mid, key, array))
                {
                    ok = mid;
                }
                else ng = mid;
            }

            return ok;
        }

        private static Boolean isOk(int index, long key, long[] array)
        {
            return array[index] >= key;
        }

        private static long calc(long sleft, long sright, long tleft, long tright, long current)
        {
            long sl = Math.Abs(current - sleft);
            long sr = Math.Abs(sright - current);
            long tl = Math.Abs(current - tleft);
            long tr = Math.Abs(tright - current);

            long[] dis =
            {
                Math.Max(sr, tr),
                Math.Max(sl, tl),
                Math.Max(sr, tl) + Math.Min(sr, tl) * 2,
                Math.Max(sl, tr) + Math.Min(sl, tr) * 2
            };
            return dis.Min();
        }
    }
}