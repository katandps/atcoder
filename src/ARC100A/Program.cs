using System;
using System.Linq;

namespace ARC100_A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var temp = a;
            for (var i = 0; i < n; i++) temp[i] -= i;

            Array.Sort(temp);
            temp = temp.Select(c => c - temp[0]).ToArray();

            var cur = temp[0];
            var asc = new long[n + 1];
            asc[0] = 0;
            for (var i = 1; i < n; i++)
            {
                if (temp[i] != cur)
                {
                    cur = temp[i];
                    asc[i] = Math.Abs(cur - temp[i - 1]) * i + asc[i - 1];
                    continue;
                }

                asc[i] = asc[i - 1];
            }

            asc[n] = asc[n - 1];

            cur = temp[n - 1];
            var desc = new long[n + 1];
            for (var i = n - 1; i > 0; i--)
            {
                if (temp[i] != cur)
                {
                    cur = temp[i];
                    desc[i] = Math.Abs(cur - temp[i + 1]) * (n - i - 1) + desc[i + 1];
                    continue;
                }

                desc[i] = desc[i + 1];
            }

            desc[0] = desc[1];

            var min = long.MaxValue;
            for (var i = 0; i <= n; i++) min = Math.Min(min, asc[i] + desc[i]);

            Console.WriteLine(min);
        }
    }
}