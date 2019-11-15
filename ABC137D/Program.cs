using System;
using System.Linq;

namespace ABC137D
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NM = CIN.LongArray();
            long N = NM[0];
            long M = NM[1];
            Work[] AB = new Work[N];
            for (int i = 0; i < N; i++)
            {
                long[] ab = CIN.LongArray();
                AB[i] = new Work(ab[0], ab[1]);
            }

            Array.Sort(AB);

            int rest = 1;
            long ans = 0;
            long[] free = { };
            long[] work = new long[N];
            int index = 0;
            int newindex = 0;
            for (int i = 0; i < M; i++)
            {
                for (int j = index; j < N; j++)
                {
                    if (AB[j].A > rest)
                    {
                        newindex = j;
                        break;
                    }

                    if (j == AB.Length - 1)
                    {
                        newindex = j;
                    }
                }

                int oldLength = free.Length - 1;
                for (int j = 1; j < free.Length; j++)
                {
                    work[j - 1] = free[j];
                }

                free = new long[free.Length + newindex - index];

                int ABi = index;
                int wi = 0;
                for (int j = 0; j < free.Length; j++)
                {
                    if (ABi > newindex || (work[wi] >= AB[ABi].B && wi < oldLength))
                    {
                        free[j] = work[wi];
                        wi++;
                        continue;
                    }

                    if (ABi < newindex)
                    {
                        free[j] = AB[ABi].B;
                        ABi++;
                    }
                }

                index = newindex;

                rest++;
                if (free.Length == 0)
                {
                    continue;
                }

                ans += free[0];
            }

            Console.WriteLine(ans);
        }

        class Work : IComparable
        {
            public long A;
            public long B;

            public Work(long a, long b)
            {
                A = a;
                B = b;
            }

            public int CompareTo(object obj)
            {
                Work work = (Work) obj;
                if (A > work.A)
                {
                    return 1;
                }

                if (A < work.A)
                {
                    return -1;
                }

                if (B > work.B)
                {
                    return -1;
                }

                if (B == work.B)
                {
                    return 0;
                }

                return 1;
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
}