using System;
using System.Linq;

namespace b
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var p = new int[n];
            for (var i = 0; i < n; i++) p[i] = int.Parse(Console.ReadLine());

            var memo = new int[n + 1];
            for (var i = 0; i < n; i++)
            {
                if (memo[p[i] - 1] == 0)
                {
                    memo[p[i]] = 1;
                    continue;
                }

                memo[p[i]] = memo[p[i] - 1] + 1;
            }

            Console.WriteLine(n - memo.Max());
        }
    }
}