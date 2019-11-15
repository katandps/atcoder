using System;
using System.Linq;

namespace MinPro2019B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] one = Console.ReadLine().Split(' ').Select(a1 => int.Parse(a1)).ToArray();
            int[] two = Console.ReadLine().Split(' ').Select(a1 => int.Parse(a1)).ToArray();
            int[] three = Console.ReadLine().Split(' ').Select(a1 => int.Parse(a1)).ToArray();

            int[] flags = new int[5];

            flags[one[0]]++;
            flags[one[1]]++;
            flags[two[0]]++;
            flags[two[1]]++;
            flags[three[0]]++;
            flags[three[1]]++;

            if (flags.Max() > 2)
            {
                Console.WriteLine("NO");
                return;
            }
            Console.WriteLine("YES");
        }
    }
}