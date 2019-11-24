using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC146A
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Cin.String();
            if (s == "SAT")
            {
                Console.WriteLine(1);
                return;
            } else if (s == "FRI")
            {
                Console.WriteLine(2);
                return;
            }
            else if (s == "THU")
            {
                Console.WriteLine(3);
                return;
            }
            else if (s == "WED")
            {
                Console.WriteLine(4);
            }
            else if (s == "TUE")
            {
                Console.WriteLine(5);
                
            }else if (s == "MON")
            {Console.WriteLine(6);}else {Console.WriteLine(7);}
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