using System;
using System.Collections.Generic;
using System.Linq;

namespace AGC025D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = input[0];
            var n = N * 2;
            var d1 = new Distance(input[1]);
            var d2 = new Distance(input[2]);
            var pairs = d1.P;
            pairs.AddRange(d2.P);

            var ps = new Point[n * n];
            for (long i = 0; i < n; i++)
            for (long j = 0; j < n; j++)
                ps[i * n + j] = new Point(i, j);

            for (long i = 0; i < n; i++)
            for (long j = 0; j < n; j++)
            {
                if (!ps[i * n + j].Can) continue;

                pairs.ForEach(pair =>
                {
                    long ii;
                    long jj;
                    ii = i + pair.A;
                    jj = j + pair.B;
                    if (ii < n && jj < n) ps[ii * n + jj].Can = false;

                    ii = i + pair.B;
                    jj = j + pair.A;
                    if (ii < n && jj < n) ps[ii * n + jj].Can = false;

                    ii = i + pair.A;
                    jj = j - pair.B;
                    if (ii < n && jj >= 0) ps[ii * n + jj].Can = false;

                    ii = i + pair.B;
                    jj = j - pair.A;
                    if (ii < n && jj >= 0) ps[ii * n + jj].Can = false;

                    ii = i - pair.A;
                    jj = j + pair.B;
                    if (ii >= 0 && jj < n) ps[ii * n + jj].Can = false;

                    ii = i - pair.B;
                    jj = j + pair.A;
                    if (ii >= 0 && jj < n) ps[ii * n + jj].Can = false;

                    ii = i - pair.A;
                    jj = j - pair.B;
                    if (ii >= 0 && jj >= 0) ps[ii * n + jj].Can = false;

                    ii = i - pair.B;
                    jj = j - pair.A;
                    if (ii >= 0 && jj >= 0) ps[ii * n + jj].Can = false;
                });
            }

            var ans = ps.Where(p => p.Can).ToArray();
            var nn = N * N;
            for (long i = 0; i < nn; i++) ans[i].Show();
        }
    }

    internal class Distance
    {
        public long D;
        public List<Pair> P;

        public Distance(long d)
        {
            D = d;
            P = new List<Pair>();
            Search();
        }

        private void Search()
        {
            var droot = Math.Sqrt(D);
            for (long i = 0; i <= droot; i++)
            for (var j = i; j <= droot; j++)
            {
                var l = i * i + j * j;
                if (l == D) P.Add(new Pair(i, j));

                if (l > D) break;
            }
        }
    }

    internal class Pair
    {
        public long A;
        public long B;

        public Pair(long a, long b)
        {
            A = a;
            B = b;
        }
    }

    internal class Point
    {
        public bool Can;
        public long X;
        public long Y;

        public Point(long i, long j)
        {
            Can = true;
            X = i;
            Y = j;
        }

        public void Show()
        {
            Console.WriteLine("" + X + " " + Y);
        }
    }
}