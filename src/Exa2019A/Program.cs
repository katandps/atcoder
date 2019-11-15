using System;
using System.Linq;

namespace Exa2019A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] abc = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            if (abc[0] != abc[1] | abc[0] != abc[2])
            {
                Console.WriteLine("No");
                return;
            }
            Console.WriteLine("Yes");
        }
    }
}