using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC146D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Cin.Long();
            var a = new long[n];
            var b = new long[n];
            for (int i = 0; i < n-1; i++)
            {
                var ab = Cin.LArr();
                a[i] = ab[0];
                b[i] = ab[1];
            }
            var solver = new Solver(n, a, b);

            solver.Solve();
        }
    }

    class Solver
    {
        private long N;
        private long[] A;
        private long[] B;
        public Solver(long n, long[] a, long[] b)
        {
            N = n;
            A = a;
            B = b;
        }

        public void Solve()
        {
            // <頂点、＜頂点、色>>
            Dictionary<long, HashSet<long>> tree = new Dictionary<long, HashSet<long>>();
            for (int i = 0; i < N; i++)
            {
                tree.Add(i+1, new HashSet<long>());
            }
            
            for (int i = 0; i < N-1; i++)
            {
                tree[A[i]].Add(B[i]);
                tree[B[i]].Add(A[i]);
            }

            //もう塗った頂点
            Dictionary<long, HashSet<long>> done = new Dictionary<long, HashSet<long>>();
            for (int i = 0; i <= N; i++)
            {
                done.Add(i, new HashSet<long>());
            }
            
            Queue<NodeAndColor> q = new Queue<NodeAndColor>();
            q.Enqueue(new NodeAndColor(1, -1));

            var ans = new Dictionary<long, Dictionary<long, long>>();
            //すべての頂点を0で塗る
            for (int i = 0; i < N; i++)
            {
                ans.Add(i+1, new Dictionary<long, long>());
            }
            for (int i = 0; i < N-1; i++)
            {
                ans[A[i]].Add(B[i], 0);
                ans[B[i]].Add(A[i], 0);
            }

            long max = 0;
            while (q.Count > 0)
            {
                var nc = q.Dequeue();
                long color = 1;
                foreach (var l in tree[nc.N])
                {
                    if (done[nc.N].Contains(l) || done[l].Contains(nc.N))
                    {
                        continue;
                    }
                    done[nc.N].Add(l);
                    done[l].Add(nc.N);
                    if (color == nc.C) color++;
                    ans[nc.N][l] = color;
                    ans[l][nc.N] = color;
                    q.Enqueue(new NodeAndColor(l, color));
                    max = Math.Max(max, color);
                    color++;
                }
            }

            Console.WriteLine(max);
            for (int i = 0; i < N-1; i++)
            {
                Console.WriteLine(ans[A[i]][B[i]]);
            }
        }
    }

    class NodeAndColor
    {
        public long N;
        public long C;
        public NodeAndColor(long n, long c){
            N = n;
            C = c;
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