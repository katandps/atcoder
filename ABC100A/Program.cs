using System;

namespace ABC100A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var a = ints[0];
            var b = ints[1];

            if (Math.Max(a, b) <= 8)
            {
                Console.WriteLine("Yay!");
                return;
            }

            Console.WriteLine(":(");
        }
    }
}