using System;
using System.Linq;

namespace ABC123D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] XYZK = ConsoleInput.LongArray();
            long[] A = ConsoleInput.LongArray();
            long[] B = ConsoleInput.LongArray();
            long[] C = ConsoleInput.LongArray();

            Array.Sort(A);
            Array.Reverse(A);
            Array.Sort(B);
            Array.Reverse(B);
            Array.Sort(C);
            Array.Reverse(C);

            int AIndex = 0;
            int BIndex = 0;
            int CIndex = 0;
            long last = Int64.MaxValue;

            while (true)
            {
                if ((AIndex + 1) * (BIndex + 1) * (CIndex + 1) >= XYZK[3])
                {
                    break;
                }

                if (A[AIndex] >= B[BIndex] && A[AIndex] >= C[CIndex])
                {
                    AIndex++;
                    continue;
                }

                if (B[BIndex] >= C[CIndex])
                {
                    BIndex++;
                    continue;
                }

                CIndex++;
            }

            long[] ans = new long[(AIndex + 1) * (BIndex + 1) * (CIndex + 1)];
            AIndex++;
            BIndex++;
            CIndex++;

            for (int i = 0; i < AIndex; i++)
            {
                for (int j = 0; j < BIndex; j++)
                {
                    for (int k = 0; k < CIndex; k++)
                    {
                        Console.WriteLine("" + AIndex + " " + BIndex + " " + CIndex);
                        ans[i * BIndex * CIndex + j * CIndex + k] = A[i] + B[j] + C[k];
                    }
                }
            }

            Array.Sort(ans);
            Array.Reverse(ans);

            for (int i = 0; i < XYZK[3]; i++)
            {
                Console.WriteLine(ans[i]);
            }
        }
    }


    internal static class ConsoleInput
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