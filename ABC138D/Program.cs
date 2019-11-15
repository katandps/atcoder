using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC138D
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NQ = CIN.LongArray();
            long N = NQ[0];
            long Q = NQ[1];

            long[] A = new long[N];
            long[] B = new long[N];

            long[] p = new long[Q];
            long[] x = new long[Q];

            for (int i = 0; i < N - 1; i++)
            {
                long[] AB = CIN.LongArray();
                A[i] = AB[0];
                B[i] = AB[1];
            }

            for (int i = 0; i < Q; i++)
            {
                long[] PX = CIN.LongArray();
                p[i] = PX[0];
                x[i] = PX[1];
            }

            Dictionary<long, List<long>> tree = new Dictionary<long, List<long>>();
            for (int i = 0; i < N; i++)
            {
                if (tree.ContainsKey(A[i]))
                {
                    tree[A[i]].Add(B[i]);
                }
                else
                {
                    tree.Add(A[i], new List<long>{B[i]});
                }

                if (tree.ContainsKey(B[i]))
                {
                    tree[B[i]].Add(A[i]);
                }
                else
                {
                    tree.Add(B[i], new List<long>{A[i]});
                }
            }

            long[] tasks = new long[N + 1];
            for (int i = 0; i < Q; i++)
            {
                tasks[p[i]] += x[i];
            }
            
            long[] ans = new long[N + 1];

            //solve
            Stack<S> stack = new Stack<S>();
            HashSet<long> memo = new HashSet<long>();
            
            memo.Add(1);
            stack.Push(new S(1, 0));
            
            while (stack.Count > 0)
            {
                var cur = stack.Pop();
               // Console.WriteLine(cur);
                ans[cur.Node] = ans[cur.Root] + tasks[cur.Node];
                foreach (long node in tree[cur.Node])
                {
                    if (memo.Contains(node))
                    {
                        continue;
                    }
                    stack.Push(new S(node, cur.Node));
                    memo.Add(node);
                }
            }

            for (int i = 1; i < N + 1; i++)
            {
                Console.Write(ans[i] + " ");
            }
            Console.WriteLine("");
        }
    }

    class S
    {
        public long Node;
        public long Root;
        public S(long node, long root)
        {
            Node = node;
            Root = root;
        }

        public override string ToString()
        {
            return "Node:" + Node + " Root:" + Root;
        }
    }

    
    internal static class CIN
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int[] IntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(Console.ReadLine());
        }

        public static long[] LongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static double[] DoubleArray()
        {
            return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        }
    }
}