using System;
using System.Linq;

namespace MSolutionC
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NABC = CIN.IntArray();
            int N = NABC[0];
            int A = NABC[1];
            int B = NABC[2];
            int C = NABC[3];
            long MOD = 1000000007;

            if (C == 0)
            {
                if (A == 0 || B == 0)
                {
                    Console.WriteLine(N);
                    return;
                }
                
                
                //
            }
            
            if (A == 0 || B == 0)
            {
                Console.WriteLine(N * modinv(C, MOD) % MOD);
                return;
            }
            
            //
            Console.WriteLine("Hello World!");
        }
        
        
// mod. m での a の逆元 a^{-1} を計算する
        static long modinv(long a, long m) {
            long b = m, u = 1, v = 0;
            while (b > 0) { 
                long t = a / b;
                a -= t * b;
                long x = b;
                b = a;
                a = x;
                
                u -= t * v;
                x = v;
                v = u;
                u = x;
            }
            u %= m;
            if (u < 0) u += m;
            return u;
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