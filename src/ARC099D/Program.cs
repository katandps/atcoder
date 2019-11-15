using System;
using System.Collections.Generic;

namespace ARC099D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var k = int.Parse(Console.ReadLine());

            var max = (long) Math.Pow(10, 15);
            var rates = new Dictionary<long, double>();
            for (long i = 1; i < max;)
            {
                rates.Add(i, Rate(i));
                i += Math.Max((long) Math.Pow(10, Digit(i + 1) - 4), 1);
            }

            var keyList = new List<long>(rates.Keys);
            keyList.Reverse();
            double min = max;

            var ans = new List<long>();
            foreach (var index in keyList)
                if (min >= rates[index])
                {
                    ans.Add(index);
                    min = rates[index];
                }

            ans.Reverse();
            for (var i = 0; i < k; i++) Console.WriteLine(ans[i]);
        }

        public static int Digit(long n)
        {
            return n == 0 ? 1 : (int) Math.Log10(n) + 1;
        }

        public static double Rate(long n)
        {
            var temp = n;
            long sn = 0;
            while (temp > 0)
            {
                sn += temp % 10;
                temp /= 10;
            }

            return (double) n / sn;
        }
    }
}