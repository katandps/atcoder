using System;

namespace AGC020A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var a = int.Parse(input[1]);
            var b = int.Parse(input[2]);

            Console.WriteLine((b - a) % 2 != 0 ? "Borys" : "Alice");
        }
    }
}