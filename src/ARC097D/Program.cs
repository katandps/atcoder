using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC097D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = input[0];
            var m = input[1];

            var p = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var x = new int[m];
            var y = new int[m];
            for (var i = 0; i < m; i++)
            {
                var line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                x[i] = line[0];
                y[i] = line[1];
            }

            var union = new UnionFind(n);
            for (var i = 0; i < m; i++) union.Unite(x[i], y[i]);

            var points = new Point[n + 1];
            for (var i = 0; i <= n; i++) points[i] = new Point(i);

            for (var i = 1; i <= n; i++) points[union.Root(i)].Add(i);

            var score = 0;
            foreach (var point in points) score += point.Score(p);

            Console.WriteLine(score);
        }

        private class Point
        {
            private bool _on;
            public readonly int M;
            private readonly List<int> X;

            public Point(int m)
            {
                M = m;
                X = new List<int>();
            }

            public void Add(int x)
            {
                X.Add(x);
                _on = true;
            }

            private List<int> all()
            {
                var list = new List<int>();
                foreach (var i in X) list.Add(i);

                list.Add(M);
                return list.Distinct().ToList();
            }

            public int Score(int[] p)
            {
                if (!_on) return 0;

                if (M == 0) return 0;

                var indexes = all().ToArray();
                var values = new Dictionary<int, bool>();
                for (var i = 0; i < indexes.Length; i++) values[p[indexes[i] - 1]] = true;

                var score = 0;
                for (var i = 0; i < indexes.Length; i++)
                    if (values.ContainsKey(indexes[i]))
                        score++;

                return score;
            }
        }
    }

    public class UnionFind
    {
        private readonly int[] par;

        public UnionFind(int maxN)
        {
            par = new int[maxN + 1];
            Init(maxN);
        }

        private void Init(int n)
        {
            for (var i = 1; i <= n; i++) par[i] = i;
        }

        public int Root(int x)
        {
            if (par[x] == x) return x;

            return par[x] = Root(par[x]);
        }

        public bool Same(int x, int y)
        {
            return Root(x) == Root(y);
        }

        public void Unite(int x, int y)
        {
            x = Root(x);
            y = Root(y);
            if (x == y) return;

            par[x] = y;
        }
    }
}