using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC127D
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NM = CIN.LongArray();
            long N = NM[0];
            long M = NM[1];
            long[] A = CIN.LongArray();
            long[] B = new long[M];
            long[] C = new long[M];

            for (int i = 0; i < M; i++)
            {
                long[] BC = CIN.LongArray();
                B[i] = BC[0];
                C[i] = BC[1];
            }
            
            Array.Sort(A);
            Array.Reverse(A);

            var make = new SortedDictionary<long, long>(new SortRule());
            for (int i = 0; i < M; i++)
            {
                if (make.ContainsKey(C[i]))
                {
                    make[C[i]] += B[i];
                    continue;
                }

                make.Add(C[i], B[i]);
            }

            long Count = 0;
            long Score = 0;
            long Index = 0;
            foreach (var VARIABLE in make)
            {
                if (Index > N - 1 || Count >= N)
                {
                    break;
                }
                while(VARIABLE.Key <= A[Index])
                {
                    Score += A[Index];
                    Index++;
                    Count++;
                    if (Index > N - 1 || Count >= N)
                    {
                        break;
                    }
                }
                if (Index > N - 1 || Count >= N)
                {
                    break;
                }
                long rest = Math.Min(N - Index, N - Count);
                Count += Math.Min(VARIABLE.Value, rest);
                Score += VARIABLE.Key * Math.Min(VARIABLE.Value, rest);
            }
            long res = Math.Min(N - Index, N - Count);
            for (int i = 0; i < res; i++)
            {
                Score += A[Index];
                Index++;
                Count++;
                if (Index > N - 1 || Count >= N)
                {
                    break;
                }
            }
            
            Console.WriteLine(Score);
        }
    }

    public sealed class SortRule : IComparer<long>
    {
        public int Compare(long x, long y)
        {
            return (int)y - (int)x;
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