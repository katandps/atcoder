using System;

namespace ABC099A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (n < 1000)
            {
                Console.WriteLine("ABC");
                return;
            }

            Console.WriteLine("ABD");
        }
    }
}