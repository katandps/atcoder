using System;
using System.Linq;

namespace ABC126B
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = CIN.String();
            int Y = int.Parse(S.Substring(0, 2));
            int M = int.Parse(S.Substring(2, 2));

            if (Y == 0 && M == 0)
            {
                Console.WriteLine("NA");
                return;
            }
            
            if (Y > 12 || Y == 0)
            {
                if (M > 12 || M == 0)
                {
                    Console.WriteLine("NA");
                    return;
                }
                Console.WriteLine("YYMM");
                return;
            }
  

            if (M > 12 || M == 0)
            {
                Console.WriteLine("MMYY");
                return;
            }
            
            Console.WriteLine("AMBIGUOUS");
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