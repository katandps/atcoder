using System;

namespace ABC119B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                string[] XU = Console.ReadLine().Split(' ');
                string U = XU[1];
                if (U == "JPY")
                {
                    sum += int.Parse(XU[0]);
                }
                else
                {
                    sum += double.Parse(XU[0]) * 380000;
                }
            }
            Console.WriteLine(sum);
        }
    }
}