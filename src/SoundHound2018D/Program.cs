using System;
using System.Collections.Generic;
using System.Linq;

namespace SoundHound2018D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var inp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = inp[0];
            var m = inp[1];
            var s = inp[2] - 1;
            var t = inp[3] - 1;

            var u = new int[m];
            var v = new int[m];
            var a = new int[m];
            var b = new int[m];
            for (var i = 0; i < m; i++)
            {
                var train = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                u[i] = train[0] - 1;
                v[i] = train[1] - 1;
                a[i] = train[2];
                b[i] = train[3];
            }

            var yen = new long[n];
            var snuke = new long[n];
            for (var i = 0; i < n; i++)
            {
                yen[i] = long.MaxValue;
                snuke[i] = long.MaxValue;
            }

            yen[s] = 0;
            snuke[t] = 0;

            var tree = new Dictionary<long, List<long[]>>();
            for (var i = 0; i < m; i++)
            {
                if (!tree.ContainsKey(u[i])) tree.Add(u[i], new List<long[]>());

                if (!tree.ContainsKey(v[i])) tree.Add(v[i], new List<long[]>());

                tree[u[i]].Add(new long[] {v[i], a[i], b[i]});
                tree[v[i]].Add(new long[] {u[i], a[i], b[i]});
            }

            var tree1 = new Dictionary<long, List<long[]>>(tree);
            var tree2 = new Dictionary<long, List<long[]>>(tree);
            var queue = new List<long>();
            queue.Add(s);
            while (queue.Count > 0)
            {
                var current = queue.First();
                queue.Remove(current);

                if (tree1.ContainsKey(current))
                {
                    foreach (var temp in tree1[current])
                    {
                        queue.Add(temp[0]);
                        yen[temp[0]] = Math.Min(yen[temp[0]], yen[current] + temp[1]);
                    }

                    tree1.Remove(current);
                }
            }

            queue.Add(t);

            while (queue.Count > 0)
            {
                var current = queue.First();

                if (tree2.ContainsKey(current))
                {
                    foreach (var temp in tree2[current])
                    {
                        queue.Add(temp[0]);
                        snuke[temp[0]] = Math.Min(snuke[temp[0]], snuke[current] + temp[2]);
                    }

                    tree2.Remove(current);
                }
            }

            var res = new long[n];
            var here = (long) Math.Pow(10, 15);
            for (var i = 0; i < n; i++) res[i] = here - yen[i] - snuke[i];

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(res.Max());
                res[i] = 0;
            }
        }
    }
}