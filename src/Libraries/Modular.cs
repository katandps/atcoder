using System;
using System.Collections.Generic;
using System.Linq;

namespace Libraries
{
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

        public override string ToString()
        {
            return V.ToString();
        }
    }
}