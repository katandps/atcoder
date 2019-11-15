using System;

namespace SoundHound2018C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inp = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var n = inp[0];
            var m = inp[1];
            var d = inp[2];

            double rate;
            if (d == 0 || d == n)
                rate = (double) 1 / n;
            else
                rate = (double) 2 * (n - d) / (n * n);
            Console.WriteLine(rate * (m - 1));
        }
    }
}