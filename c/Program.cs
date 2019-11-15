using System;

namespace c
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var a = new long[n];
            for (long i = 0; i < n; i++) a[i] = long.Parse(Console.ReadLine());

            //可能判定
            for (long i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    if (a[0] != 0)
                    {
                        Console.WriteLine(-1);
                        return;
                    }

                    continue;
                }

                if (a[i] - a[i - 1] > 1)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            long count = 0;
            for (long i = 1; i < n; i++)
                if (a[i] - a[i - 1] == 1)
                    ++count;
                else
                    count += a[i];
            Console.WriteLine(count);
        }
    }
}