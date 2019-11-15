using System;

namespace ARC098E
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var num = Console.ReadLine().Split();
            var n = int.Parse(num[0]);
            var k = int.Parse(num[1]);
            var q = int.Parse(num[2]);

            if (q == 1)
            {
                Console.WriteLine(0);
                return;
            }

            var a = Array.ConvertAll(Console.ReadLine().Split(), input => long.Parse(input));
        }
    }
}