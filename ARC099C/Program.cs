using System;

namespace ARC099C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = input[0];
            var k = input[1];

            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var count = 1;
            var rest = n - k;

            while (rest > 0)
            {
                rest -= k - 1;
                count++;
            }

            Console.WriteLine(count);
        }
    }
}