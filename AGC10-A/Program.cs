using System;
using System.Linq;

namespace AGC10_A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            var a = Console.ReadLine().Split().Select(int.Parse);
            var oddCount = a.Count(x => x % 2 == 1);
            Console.WriteLine(oddCount % 2 == 0 ? "YES" : "NO");
        }
    }
}