using System;

namespace codeFlyerA
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine(a - a % b);
        }
    }
}