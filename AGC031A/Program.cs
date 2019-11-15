using System;
using System.Linq;

namespace AGC031A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] longs = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            long N = longs[0];
            string S = Console.ReadLine();

            int[] chars = new int[26];
            for (int i = 0; i < N; i++)
            {
                chars[S[i] - 'a']++;
            }

            long ans = 1;
            long BIG = 1000000007;

            for (int i = 0; i < 26; i++)
            {
                ans = ans * (chars[i] + 1) % BIG;
            }

            Console.WriteLine(ans - 1);
        }
    }
}