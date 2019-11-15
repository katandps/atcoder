using System;

namespace ABC119A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string S = Console.ReadLine();
            DateTime dateTime  = DateTime.Parse(S);
            DateTime threshold  = DateTime.Parse("2019/04/30");
            if (dateTime.CompareTo(threshold) > 0)
            {
                Console.WriteLine("TBD");
                return;
            }
            Console.WriteLine("Heisei");
        }
    }
}