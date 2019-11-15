using System;

namespace ARC090D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = ints[0];
            var m = ints[1];
            var union = new UnionFind(n);

            for (var i = 0; i < m; i++)
            {
                var line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var l = line[0];
                var r = line[1];
                var d = line[2];
                --l;
                --r;
                if (union.Same(l, r))
                {
                    var diff = union.Diff(l, r);
                    if (diff != d)
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }

                union.Unite(l, r, d);
            }

            Console.WriteLine("Yes");
        }
    }

    public class UnionFind
    {
        private readonly int[] par;
        private readonly int[] rank;
        private readonly int[] weight;

        public UnionFind(int maxN)
        {
            par = new int[maxN + 1];
            rank = new int[maxN + 1];
            weight = new int[maxN + 1];
            Init(maxN);
        }

        private void Init(int n)
        {
            for (var i = 1; i <= n; i++)
            {
                par[i] = i;
                rank[i] = 0;
                weight[i] = 0;
            }
        }

        public int Root(int x)
        {
            if (par[x] == x) return x;

            var r = Root(par[x]);
            weight[x] += weight[par[x]];
            return par[x] = r;
        }

        public int Weight(int x)
        {
            Root(x);
            return weight[x];
        }

        public int Diff(int x, int y)
        {
            return weight[y] - weight[x];
        }

        public bool Same(int x, int y)
        {
            return Root(x) == Root(y);
        }

        public bool Unite(int x, int y, int d)
        {
            d += weight[x];
            d -= weight[y];

            x = Root(x);
            y = Root(y);

            if (x == y) return false;

            if (rank[x] < rank[y])
            {
                var temp = x;
                x = y;
                y = temp;
                d = -d;
            }

            if (rank[x] == rank[y]) ++rank[x];

            par[y] = x;
            weight[y] = d;
            return true;
        }
    }
}