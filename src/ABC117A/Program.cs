using System;
using System.Linq;

namespace ABC117A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] TX = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            int T = TX[0];
            int X = TX[1];
            
            Console.WriteLine(Convert.ToDouble(T)/ Convert.ToDouble(X));
        }
    }
}