using System;
using System.Collections.Generic;
using System.Linq;

namespace PAST001G
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Cin.Int();
            Dictionary<Pair, long> d = new Dictionary<Pair, long>();
            for (int i = 1; i <= n - 1; i++)
            {
                var a = Cin.LArr();
                for (int j = 0; j < a.Length; j++)
                {
                    d.Add(new Pair(i, i + j + 1), a[j]);
                    d.Add(new Pair(i + j + 1, i), a[j]);
                }
            }

            var solver = new Solver(n, d);

            Console.WriteLine(solver.Solve());
        }
    }

    class Pair
    {
        private int A;
        private int B;

        public Pair(int a, int b)
        {
            A = a;
            B = b;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pair))
            {
                return false;
            }

            var c = (Pair) obj;
            return A == c.A && B == c.B;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() ^ B.GetHashCode();
        }
    }

    class Solver
    {
        private int N;
        private Dictionary<Pair, long> D;

        public Solver(int n, Dictionary<Pair, long> d)
        {
            N = n;
            D = d;
        }

        public IConvertible Solve()
        {
            int maxCase = (int) Math.Pow(3, N);

            long max = long.MinValue;
            for (int i = 0; i < maxCase; i++)
            {
                long point = 0;
                HashSet<int>[] groups = new HashSet<int>[3];
                for (int j = 0; j < 3; j++)
                {
                    groups[j] = new HashSet<int>();
                }

                int curC = i;
                for (int j = 1; j <= N; j++)
                {
                    var g = curC % 3;
                    groups[g].Add(j);
                    curC /= 3;
                }

                foreach (HashSet<int> group in groups)
                {
                    foreach (int m in group)
                    {
                        foreach (int  m2 in group)
                        {
                            if (m == m2)
                            {
                                continue;
                            }

                            point += D[new Pair(m, m2)];
                        }
                    }
                }

                point /= 2;
                max = Math.Max(max, point);
            }

            return max;
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