using System;

namespace a
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var a = long.Parse(input[0]);
            var b = long.Parse(input[1]);
            var c = long.Parse(input[2]);
            var k = long.Parse(input[3]);

            if (k % 2 == 0)
            {
                Console.WriteLine(a - b);
                return;
            }

            Console.WriteLine(b - a);
        }
    }
}