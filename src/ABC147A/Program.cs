﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC147A
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Cin.IArr();
            Console.WriteLine(a.Sum() > 21 ? "bust" : "win");
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