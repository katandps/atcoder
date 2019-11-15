using System;

namespace ABC099B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inputs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var a = inputs[0];
            var b = inputs[1];

            var temp = b - a;
            var sum = temp * (temp + 1) / 2;
            Console.WriteLine(sum - b);
        }
    }
}