using System;

namespace Exa2019B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());
            string s = Console.ReadLine();

            long red = 0;
            long blue = 0;
            for (int i = 0; i < N; i++)
            {
                if (s[i] == 'R')
                {
                    red++;
                }
                else
                {
                    blue++;
                }
            }
            Console.WriteLine(red > blue ? "Yes" : "No");
        }
    }
}