using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PAST001K
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Cin.Int();
            int[] p = new int[n];
            for (int i = 0; i < n; i++)
            {
                p[i] = Cin.Int();
            }

            var q = Cin.Int();
            int[] a = new int[q];
            int[] b = new int[q];
            for (int i = 0; i < q; i++)
            {
                var ab = Cin.IArr();
                a[i] = ab[0];
                b[i] = ab[1];
            }

            var solver = new Solver(n, p);
            solver.Solve(q, a, b);
        }
    }

    class Solver
    {
        private int N;
        private int[] P;

        public Solver(int n, int[] p)
        {
            N = n;
            P = p;

            Dictionary<int, HashSet<int>> tree = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < N; i++)
            {
                if (tree.ContainsKey(p[i]))
                {
                    tree[p[i]] = new HashSet<int>(i + 1);
                }
                else
                {
                    tree.Add(p[i], new HashSet<int>(i + 1));
                }
            }

            // ノード、深さ
            Stack<int[]> stack = new Stack<int[]>();
            stack.Push(new int[] {-1, 0});

            List<int> treeList = new List<int>();

            // <親ノード、インデックス>
            Dictionary<int, int> index = new Dictionary<int, int>();
            // <親インデックス、子インデックス終わり>
            Dictionary<int, int> childEnd = new Dictionary<int, int>();

            int count = 0;
            int beforeDepth = 0;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (beforeDepth > node[1])
                {
                    childEnd.Add(1, 1);
                }
                index.Add(node[0], count);
                treeList.Add(node[0]);

                foreach (int child in tree[node[0]])
                {
                    stack.Push(new int[] {child, node[1] + 1});
                }

                beforeDepth = node[1];
                count++;
            }
        }

        public void Solve(int q, int[] a, int[] b)
        {
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