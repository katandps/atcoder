using System;

namespace AGC026A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var cur = -1;
            var ans = 0;
            for (var i = 0; i < n; i++)
            {
                if (a[i] == cur)
                {
                    cur = -1;
                    ans++;
                    continue;
                }

                cur = a[i];
            }

            Console.WriteLine(ans);
        }
    }
}