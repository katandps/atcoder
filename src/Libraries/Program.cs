using System;

namespace Libraries
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine((int) (Modular.Fac(i) / Modular.Fac(i / 2) / Modular.Fac(i - i / 2)));
            }
        }
    }
}