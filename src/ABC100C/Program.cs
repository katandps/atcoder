using System;

namespace ABC100C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            long ans = 0;
            for (var i = 0; i < n; i++)
            {
                var k = a[i];
                while (k % 2 == 0)
                {
                    ans++;
                    k /= 2;
                }
            }

            Console.WriteLine(ans);
        }
    }
}