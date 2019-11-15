using System;

namespace ARC098C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();

            var dpe = new int[n];
            var dpw = new int[n];

            var w = 0;
            for (var i = 0; i < n; i++)
            {
                if (s[i] == 'W') w++;

                dpw[i] = w;
            }

            var e = 0;
            for (var i = n - 1; i >= 0; i--)
            {
                if (s[i] == 'E') e++;

                dpe[i] = e;
            }

            var ans = 10000000;
            for (var i = 0; i < n; i++)
            {
//                Console.Write(i);
//                Console.Write(' ');
//                Console.Write(dpe[i]);
//                Console.Write(' ');
//                Console.WriteLine(dpw[i]);
                int score;

                if (i == 0)
                    score = dpe[i];
                else if (i == n - 1)
                    score = dpw[i];
                else
                    score = dpw[i] + dpe[i] - 1;

                if (ans > score) ans = score;
            }

            Console.WriteLine(ans);
        }
    }
}