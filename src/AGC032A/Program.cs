using System;
using System.Collections.Generic;
using System.Linq;

namespace AGC032A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] NN = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            long N = NN[0];
            long[] B = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();

            long[] Rev = new long[N];
            List<long> BB = B.ToList();

            for (int i = 0; i < N; i++)
            {
                int stat = -1;
                for (int j = 0; j < BB.Count; j++)
                {
                    if (j + 1 == BB[j])
                    {
                        stat = Math.Max(stat, j);
                    }
                }

                if (stat == -1)
                {
                    Console.WriteLine(-1);
                    return;
                }

                Rev[i] = stat;
                BB.RemoveAt(stat);
            }

            Array.Reverse(Rev);
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(Rev[i] + 1);
            }
        }
    }
}