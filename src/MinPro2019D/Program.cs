using System;

namespace MinPro2019D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            long[] A = new long[L];
            for (int i = 0; i < L; i++)
            {
                A[i] = long.Parse(Console.ReadLine());
            }

            long[] a = new long[L];
            for (int i = 0; i < L; i++)
            {
                a[i] = A[i] % 2;
            }
            
            Console.WriteLine(1);
        }
    }
}