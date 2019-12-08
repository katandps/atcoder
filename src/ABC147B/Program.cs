using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC147B
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Cin.String();
            int ans = 0;
            for (int i = 0; i < s.Length/2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    ans++;
                }
            }
            
            Console.WriteLine(ans);
        }
    }

    class Solver
    {
        public Solver()
        {

        }

        public IConvertible Solve()
        {
            return 0;
        }
    }

    internal static class Cin
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(String());
        }

        public static int[] IArr()
        {
            return Split().Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(String());
        }

        public static long[] LArr()
        {
            return Split().Select(long.Parse).ToArray();
        }

        public static double Double()
        {
            return double.Parse(String());
        }

        public static double[] DArr()
        {
            return Split().Select(double.Parse).ToArray();
        }

        private static IEnumerable<String> Split()
        {
            return String().Split(' ');
        }
    }
}