using System;
using System.Linq;

namespace ABC126E
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NM = CIN.LongArray();
            long N = NM[0];
            long M = NM[1];
            long[] X = new long[M];
            long[] Y = new long[M];
            long[] Z = new long[M];
            
            bool[] info = new bool[N];

            int count = 0;
            for (int i = 0; i < M; i++)
            {
                long[] XYZ = CIN.LongArray();
                X[i] = XYZ[0]-1;
                Y[i] = XYZ[1]-1;
                Z[i] = XYZ[2]-1;

                if (info[X[i]] && info[Y[i]])
                {
                    continue;
                }

                count++;
                info[X[i]] = true;
                info[Y[i]] = true;
            }
            
            Console.WriteLine(N - count);
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