using System;
using System.Collections.Generic;
using System.Linq;

namespace MUJIND
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arr = ConsoleInput.IntArray();
            var N = arr[0];
            var M = arr[1];

            var loops = new List<Pair>();
            for (var i = 1; i <= 999; i++)
            for (var j = 1; j <= 999; j++)
            {
                var p = new Pair(i, j);
                var np = p.take();
                if (p.Sum() == np.Sum()) loops.Add(np);
            }

            Console.Write(loops.Count);

            var count = 0;
            for (var i = 1; i <= N; i++)
            for (var j = 1; j <= M; j++)
            {
                var p = new Pair(i, j);
                for (var k = 0; k < 1000; k++)
                {
                    p = p.take();
                    foreach (var pp in loops)
                        if (pp.Equals(p))
                        {
                            count++;
                            k = 10;
                            break;
                        }
                }
            }

            Console.WriteLine(count);
        }
    }

    public class Pair
    {
        public int A;
        public int B;

        public Pair(int a, int b)
        {
            A = a;
            B = b;
        }

        public int Sum()
        {
            return A + B;
        }

        public bool Equals(Pair obj)
        {
            return A == obj.A && B == obj.B;
        }

        public Pair take()
        {
            if ((A == 0) | (B == 0)) return this;
            var a = A;
            var b = B;
            if (a < b)
                a = rev(a);
            else
                b = rev(b);

            if (a < b)
                b -= a;
            else
                a -= b;

            return new Pair(a, b);
        }

        private int rev(int a)
        {
            var str = a.ToString();
            var res = 0;
            for (var i = 0; i < str.Length; i++) res += (str[i] - '0') * Convert.ToInt32(Math.Pow(10, i));
            return res;
        }
    }

    internal static class ConsoleInput
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int[] IntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(Console.ReadLine());
        }

        public static long[] LongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static double[] DoubleArray()
        {
            return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        }
    }
}