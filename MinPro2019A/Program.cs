using System;
using System.Linq;

namespace MinPro2019A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] NK = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            int N = NK[0];
            int K = NK[1];

            if (N % 2 == 1)
            {
                N += 1;
            }

            Console.WriteLine(N / 2 < K ? "NO" : "YES");
        }
    }
}