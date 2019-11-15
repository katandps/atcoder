using System;

namespace MUJINB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();

            if (a == 0)
            {
                Console.WriteLine("Yes");
                return;
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '+') a++;

                if (s[i] == '-') a--;

                if (a == 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }

            Console.WriteLine("No");
        }
    }
}