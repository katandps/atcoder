using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC148F
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Nuv = Cin.IArr();
            int[] A = new int[Nuv[0]];
            int[] B = new int[Nuv[0]];
            for (int i = 0; i < Nuv[0] - 1; i++)
            {
                var AB = Cin.IArr();
                A[i] = AB[0];
                B[i] = AB[1];
            }

            var solver = new Solver(Nuv[0], Nuv[1], Nuv[2], A, B);

            Console.WriteLine(solver.Solve());
        }
    }

    class Solver
    {
        // 頂点数
        private int N;

        // 高橋初期位置
        private int U;

        // 青木初期位置
        private int V;

        // 木 <頂点、 隣接する頂点>
        private Dictionary<int, HashSet<int>> Tree;

        public Solver(int n, int u, int v, int[] a, int[] b)
        {
            N = n;
            U = u;
            V = v;
            Tree = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < N - 1; i++)
            {
                if (Tree.ContainsKey(a[i]))
                {
                    Tree[a[i]].Add(b[i]);
                }
                else
                {
                    Tree.Add(a[i], new HashSet<int> {b[i]});
                }

                if (Tree.ContainsKey(b[i]))
                {
                    Tree[b[i]].Add(a[i]);
                }
                else
                {
                    Tree.Add(b[i], new HashSet<int> {a[i]});
                }
            }
        }

        public IConvertible Solve()
        {
            // 高橋の初期値からの距離のマップ<頂点, 距離>
            Dictionary<int, int> udis = new Dictionary<int, int>();
            // 青木からの初期値からの距離のマップ<頂点, 距離>
            Dictionary<int, int> vdis = new Dictionary<int, int>();

            Queue<Q> queue = new Queue<Q>();
            queue.Enqueue(new Q(U, 0));
            HashSet<int> tmemo = new HashSet<int> {U};
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                udis.Add(current.Node, current.Distance);

                foreach (int node in Tree[current.Node])
                {
                    if (tmemo.Contains(node))
                    {
                        continue;
                    }

                    tmemo.Add(node);
                    queue.Enqueue(new Q(node, current.Distance + 1));
                }
            }

            queue.Enqueue(new Q(V, 0));
            HashSet<int> umemo = new HashSet<int> {V};
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                vdis.Add(current.Node, current.Distance);

                foreach (int node in Tree[current.Node])
                {
                    if (umemo.Contains(node))
                    {
                        continue;
                    }

                    umemo.Add(node);
                    queue.Enqueue(new Q(node, current.Distance + 1));
                }
            }

            for (int i = 1; i <= N; i++)
            {
                // 高橋は青木と同じ距離の点(を経由する点)に行くことはできない
                // 青木も追いかけるので、当然最終的に行くことはない
                if (vdis[i] <= udis[i])
                {
                    udis[i] = -1;
                    vdis[i] = -1;
                }
            }

            int goal = U;
            for (int i = 1; i <= N; i++)
            {
                if (vdis[i] > vdis[goal])
                {
                    goal = i;
                }
            }

            var dis = vdis[goal] - udis[goal];
            return udis[goal] + dis - 1;
        }
    }

    class Q
    {
        public int Node;
        public int Distance;

        public Q(int node, int distance)
        {
            Node = node;
            Distance = distance;
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