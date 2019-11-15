using System;

namespace CADDi2018D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var A = new long[N];

            var Has1 = false;
            for (var i = 0; i < N; i++)
            {
                A[i] = long.Parse(Console.ReadLine());
                if (A[i] == 1) Has1 = true;
            }

            if (Has1)
            {
                Console.WriteLine("first");
                return;
            }

            for (var i = 0; i < N; i++)
                if (A[i] % 2 == 1)
                {
                    Console.WriteLine("first");
                    return;
                }

            Console.WriteLine("second");
        }
    }
}