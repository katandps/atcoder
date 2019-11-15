using System;
using System.Linq;

namespace ABC117B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] L = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();

            int sum = L.Sum();
            for (int i = 0; i < N; i++)
            {
                if (sum <= L[i] * 2)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
    }
}