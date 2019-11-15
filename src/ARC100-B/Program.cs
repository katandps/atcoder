using System;
using System.Linq;

namespace ARC100_B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var sums = new long[n];
            sums[0] = 0;
            for (var i = 1; i < n; i++) sums[i] = sums[i - 1] + a[i];

            var klm = new long[n][][];

            for (var k = 1; k < n; k++)
            {
                klm[k] = new long[n][];
                for (var l = 0; l < n; l++)
                {
                    klm[k][l] = new long[n];
                    for (var m = 0; m < n; m++)
                    {
                        long[] arr =
                        {
                            sums[k],
                            Math.Abs(sums[l] - sums[k]),
                            Math.Abs(sums[m] - sums[l]),
                            Math.Abs(sums[n - 1] - sums[m])
                        };
                        klm[k][l][m] = arr.Max() - arr.Min();
                    }
                }
            }

            Console.WriteLine("aaa");
        }
    }
}