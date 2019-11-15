using System;
using System.Collections.Generic;
using System.Linq;

namespace AGC35B
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] NM = CIN.LongArray();
            long N = NM[0];
            long M = NM[1];
            long[] A = new long[M];
            long[] B = new long[M];
            for (int i = 0; i < M; i++)
            {
                long[] AB = CIN.LongArray();
                A[i] = AB[0];
                B[i] = AB[1];
            }

            if (M % 2 == 1)
            {
                Console.WriteLine("-1");
                return;
            }

            Dictionary<long, HashSet<long>> dic = new Dictionary<long, HashSet<long>>();
            for (int i = 0; i < M; i++)
            {
                if (dic.ContainsKey(A[i]))
                {
                    dic[A[i]].Add(B[i]);
                }
                else
                {
                    dic.Add(A[i], new HashSet<long> {B[i]});
                }

                if (dic.ContainsKey(B[i]))
                {
                    dic[B[i]].Add(A[i]);
                }
                else
                {
                    dic.Add(B[i], new HashSet<long> {A[i]});
                }
            }


            Stack<Point> s = new Stack<Point>();
            Dictionary<long, HashSet<long>> memo = new Dictionary<long, HashSet<long>>();
            
            bool AisStart = true;
            bool now = true;

            s.Push(new Point(A[0]));
            List<Edge> ans = new List<Edge>();
            List<Edge> ans2 = new List<Edge>();
            while (s.Count > 0)
            {
                Point cur = s.Pop();
                foreach (long p in dic[cur.P])
                {
                    if (!memo.ContainsKey(p))
                    {
                        memo.Add(p, new HashSet<long>());
                    }

                    if (!memo.ContainsKey(cur.P))
                    {
                        memo.Add(cur.P, new HashSet<long>());
                    }
                    if (!memo[p].Contains(cur.P) && !memo[p].Contains(p))
                    {
                        memo[p].Add(cur.P);
                        memo[cur.P].Add(p);
                        s.Push(new Point(p));
                        ans.Add(new Edge(now ? p : cur.P, now ? cur.P : p));
                        ans2.Add(new Edge(now ? cur.P : p, now ? p : cur.P));
                    }
                }

                now = now ? false : true;
            }

            Dictionary<long, long> check = new Dictionary<long, long>();
            foreach (Edge edge in ans)
            {
                if (!check.ContainsKey(edge.A))
                {
                    check.Add(edge.A, 0);
                }

                check[edge.A]++;
            }

            bool ansok = true;
            foreach (KeyValuePair<long,long> VARIABLE in check)
            {
                if (VARIABLE.Value % 2 != 0)
                {
                    ansok = false;
                    break;
                }
            }

            if (ansok)
            {
                foreach (Edge edge in ans)
                {
                    Console.WriteLine("" + edge.A + " " + edge.B);
                }

                return;
            }
            
            check = new Dictionary<long, long>();
            foreach (Edge edge in ans2)
            {
                if (!check.ContainsKey(edge.A))
                {
                    check.Add(edge.A, 0);
                }

                check[edge.A]++;
            }

            ansok = true;
            foreach (KeyValuePair<long,long> VARIABLE in check)
            {
                if (VARIABLE.Value % 2 != 0)
                {
                    ansok = false;
                    break;
                }
            }

            if (ansok)
            {
                foreach (Edge edge in ans2)
                {
                    Console.WriteLine("" + edge.A + " " + edge.B);
                }

                return;
            }
            
            Console.WriteLine("-1");
        }
    }

    class Point
    {
        public long P;

        public Point(long p)
        {
            P = p;
        }
    }

    class Edge
    {
        public long A;
        public long B;

        public Edge(long a, long b)
        {
            A = a;
            B = b;
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