using System;
using System.Linq;

namespace CADDi2018C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inp = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            var N = inp[0];
            var P = inp[1];

            if (N == 1)
            {
                Console.WriteLine(P);
                return;
            }

            var Max = Convert.ToInt64(Math.Pow(P, 1.0 / N));
            long ans = 1;
            for (var i = 2; i <= Max; i++)
                if (P % i == 0)
                    if (P % Convert.ToInt64(Math.Pow(i, N)) == 0)
                        ans = i;
            Console.WriteLine(ans);
        }
    }
}