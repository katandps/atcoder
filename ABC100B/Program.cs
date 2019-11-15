using System;

namespace ABC100B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var d = ints[0];
            var n = ints[1];
            if (n == 100)
            {
                if (d == 0)
                {
                    Console.WriteLine(101);
                    return;
                }

                if (d == 1)
                {
                    Console.WriteLine(10100);
                    return;
                }

                if (d == 2)
                {
                    Console.WriteLine(1010000);
                    return;
                }
            }

            Console.WriteLine(n * 1 * Math.Pow(100, d));
        }
    }
}