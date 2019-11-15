using System;

namespace ABC099C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var res = n;
            for (var i = 0; i <= n; i++)
            {
                var count = 0;
                var t = i;
                while (t > 0)
                {
                    count += t % 6;
                    t /= 6;
                }

                t = n - i;
                while (t > 0)
                {
                    count += t % 9;
                    t /= 9;
                }

                if (res > count) res = count;
            }

            Console.Write(res);
        }
    }
}