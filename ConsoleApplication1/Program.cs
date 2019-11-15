using System;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(long.Parse);
            long count = 0;
            for (long start = 0; start < n; start++)
            {
                long sum = 0;
                for (var goal = start; goal < n; goal++) sum += 1; // not implemented
            }
        }
    }
}