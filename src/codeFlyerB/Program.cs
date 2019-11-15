using System;

namespace codeFlyerB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inp = Console.ReadLine().Split(' ');
            var a = int.Parse(inp[0]);
            var b = int.Parse(inp[1]);
            var n = int.Parse(inp[2]);
            var x = Console.ReadLine();

            for (var i = 0; i < n; i++)
            {
                var N = x[i];

                if (N == 'S') a = Math.Max(0, a - 1);

                if (N == 'C') b = Math.Max(0, b - 1);

                if (N == 'E')
                {
                    if (a >= b)
                    {
                        if (a != 0) a--;

                        continue;
                    }

                    if (b != 0) b--;
                }
            }

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}