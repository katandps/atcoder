using System;

namespace SoundHound2018A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var a = inp[0];
            var b = inp[1];
            if (a * b == 15)
            {
                Console.WriteLine("*");
                return;
            }

            if (a + b == 15)
            {
                Console.WriteLine("+");
                return;
            }

            Console.WriteLine("x");
        }
    }
}