using System;

namespace SoundHound2018B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var w = int.Parse(Console.ReadLine());

            var count = s.Length / w + (s.Length % w == 0 ? 0 : 1);
            for (var i = 0; i < count; i++) Console.Write(s[i * w]);
            Console.WriteLine();
        }
    }
}