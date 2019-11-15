using System;

namespace AGC22A
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split(' ');
            //int s = int.Parse(input[0]);
            var res = Gcd(29998, 59999);
            Console.WriteLine(res);
        }

        public static int Gcd(int a, int b)
        {
            if (a < b)
                // 引数を入替えて自分を呼び出す
                return Gcd(b, a);
            while (b != 0)
            {
                var remainder = a % b;
                if (remainder == 0) return a;
                a = b;
                b = remainder;
            }

            return a;
        }
    }
}