using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC145D
{
    class Program
    {
        static void Main(string[] args)
        {
            var xy = Cin.LArr();
            var solver = new Solver(xy[0], xy[1]);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        private long x;
        private long y;

        public Solver(long X, long Y)
        {
            x = X;
            y = Y;
        }

        public IConvertible Solve()
        {
            int a = 0;
            int b = 0;

            if ((x + y) % 3 != 0)
            {
                return 0;
            }

            while (x + y >= 3)
            {
                if (x >= y)
                {
                    x -= 2;
                    y -= 1;
                    a++;
                }
                else
                {
                    y -= 2;
                    x -= 1;
                    b++;
                }
            }

            if (x != 0 || y != 0)
            {
                return 0;
            }

            return (int) Modular.Ncr(a + b, a);
        }
    }

    class Modular
    {
        public static int M = 1000000007;
        private long V;

        public Modular(long v)
        {
            V = v;
        }

        public static implicit operator Modular(long a)
        {
            var m = a % M;
            return new Modular(m < 0 ? m + M : m);
        }

        public static Modular operator +(Modular a, Modular b)
        {
            return a.V + b.V;
        }

        public static Modular operator -(Modular a, Modular b)
        {
            return a.V - b.V;
        }

        public static Modular operator *(Modular a, Modular b)
        {
            return a.V * b.V;
        }

        public static Modular Pow(Modular a, int n)
        {
            switch (n)
            {
                case 0:
                    return 1;
                case 1:
                    return a;
                default:
                    var p = Pow(a, n / 2);
                    return p * p * Pow(a, n % 2);
            }
        }

        public static Modular operator /(Modular a, Modular b)
        {
            return a * Pow(b, M - 2);
        }

        private static readonly List<int> Facts = new List<int> {1};

        public static Modular Fac(int n)
        {
            for (int i = Facts.Count; i <= n; ++i)
            {
                Facts.Add((int) (Math.BigMul(Facts.Last(), i) % M));
            }

            return Facts[n];
        }

        public static Modular Ncr(int n, int r)
        {
            if (n < r)
            {
                return 0;
            }

            if (n == r)
            {
                return 1;
            }

            return Fac(n) / (Fac(r) * Fac(n - r));
        }

        public static explicit operator int(Modular a)
        {
            return (int) a.V;
        }
    }

    internal static class Cin
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(String());
        }

        public static int[] IArr()
        {
            return Split().Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(String());
        }

        public static long[] LArr()
        {
            return Split().Select(long.Parse).ToArray();
        }

        public static double Double()
        {
            return double.Parse(String());
        }

        public static double[] DArr()
        {
            return Split().Select(double.Parse).ToArray();
        }

        private static IEnumerable<String> Split()
        {
            return String().Split(' ');
        }
    }
}