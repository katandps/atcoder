using System;
using System.Linq;

namespace codeFlyerC
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var nd = Console.ReadLine().Split(' ');
            var n = long.Parse(nd[0]);
            var d = long.Parse(nd[1]);

            if (d == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var x = Console.ReadLine().Split(' ').Select(xi => long.Parse(xi)).ToArray();

            var right = new long[n];
            var left = new long[n];
            right[n - 1] = n - 1;
            left[0] = 0;

            long cur = 0;
            for (long i = 0; i < n; i++)
            {
                for (var j = cur; cur < n; cur++)
                    if (cur >= n - 1 || x[cur + 1] - x[i] > d)
                        break;

                right[i] = cur;
            }

            cur = n - 1;
            for (var i = n - 1; i >= 0; i--)
            {
                for (var j = cur; cur >= 0; cur--)
                    if (cur <= 0 || x[i] - x[cur - 1] > d)
                        break;

                left[i] = cur;
            }

            long ans = 0;
            cur = right[0] + 1;
            long sc = 0;
            for (long i = 0; i < n; i++)
            {
                for (var j = cur; cur < n; cur++)
                {
                    if (left[cur] > right[i])
                    {
                        Console.Write("break");
                        break;
                    }

                    sc += right[i] - left[cur];
                }

                ans += Math.Max(0, (cur - right[i]) * (right[i] + 1) - sc);
                Console.WriteLine("ans " + ans + " sc " + sc + " right " + right[i] + " cur " + cur + " i " + i);
                sc -= left[i];
            }

            Console.WriteLine(ans);
        }
    }
}