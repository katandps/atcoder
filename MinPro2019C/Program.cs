using System;
using System.Linq;

namespace MinPro2019C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] KAB = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            long K = KAB[0];
            long A = KAB[1];
            long B = KAB[2];

            if (B - A < 2)
            {
                Console.WriteLine(1 + K);
                return;
            }

            long ans = 0;
            long lest = K;
            if (lest >= A + 1)
            {
                ans += B;
                lest -= A + 1;
            }
            else
            {
                Console.WriteLine(K + 1);
                return;
            }

            ans += lest / 2 * (B - A) + lest % 2;
            Console.WriteLine(ans);
        }
    }
}