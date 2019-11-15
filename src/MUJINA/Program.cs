using System;

namespace MUJINA
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var mujin = "MUJIN";
            if (s.Length < 5)
            {
                Console.WriteLine("No");
                return;
            }

            for (var i = 0; i < 5; i++)
                if (s[i] != mujin[i])
                {
                    Console.WriteLine("No");
                    return;
                }

            Console.WriteLine("Yes");
        }
    }
}