using System;
using System.Linq;

namespace ABC117C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] NM = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            int N = NM[0];
            int M = NM[1];
            long[] X = Console.ReadLine().Split(' ').Select(b => long.Parse(b)).ToArray();

            if (N >= M)
            {
                Console.WriteLine(0);
                return;
            }

            long Long = X.Max() - X.Min();
            Array.Sort(X);
            long[] Distance = new long[M - 1];
            for (int i = 1; i < M; i++)
            {
                Distance[i - 1] = X[i] - X[i - 1];
            }
            
            Array.Sort(Distance);
            Array.Reverse(Distance);
            for (int i = 0; i < N - 1; i++)
            {
                Long -= Distance[i];
            }
            Console.WriteLine(Long);
        }
    }
}