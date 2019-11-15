using System;

namespace AGC025A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var ans = 0;
            for (var i = 0; i < str.Length; i++) ans += int.Parse(str[i].ToString());

            if (ans == 1)
            {
                Console.WriteLine(10);
                return;
            }

            Console.WriteLine(ans);
        }
    }
}