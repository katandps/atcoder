using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Yorukatsu20200409D.Input;

namespace Yorukatsu20200409D
{
    static class Input
    {
        private static Func<string, T[]> Cast<T>() => _ => _.Split(' ').Select(Convert<T>()).ToArray();

        private static Func<string, T> Convert<T>()
        {
            Type t = typeof(T);
            if (t == typeof(string)) return _ => (T) (object) _;
            if (t == typeof(int)) return _ => (T) (object) int.Parse(_);
            if (t == typeof(long)) return _ => (T) (object) long.Parse(_);
            if (t == typeof(double)) return _ => (T) (object) double.Parse(_);
            if (t == typeof(string[])) return _ => (T) (object) _.Split(' ');
            if (t == typeof(int[])) return _ => (T) (object) Cast<int>()(_);
            if (t == typeof(long[])) return _ => (T) (object) Cast<long>()(_);
            if (t == typeof(double[])) return _ => (T) (object) Cast<double>()(_);

            throw new NotSupportedException(t + "is not supported.");
        }

        private static T Convert<T>(string s) => Convert<T>()(s);

        private static string String() => Console.ReadLine();

        private static string[] String(long rowNumber) => new bool[rowNumber].Select(_ => String()).ToArray();

        public static void Cin<T>(out T a) => a = Convert<T>(String());

        public static void Cin<T1, T2>(out T1 a1, out T2 a2)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
        }

        public static void Cin<T1, T2, T3>(out T1 a1, out T2 a2, out T3 a3)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
        }

        public static void Cin<T1, T2, T3, T4>(out T1 a1, out T2 a2, out T3 a3, out T4 a4)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
        }

        public static void Cin<T1, T2, T3, T4, T5>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
        }

        public static void Cin<T1, T2, T3, T4, T5, T6>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5, out T6 a6)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
            set(v[5], out a6);
        }

        private static void set<T1>(string s, out T1 o1) => o1 = Convert<T1>(s);

        public static void Cin<T>(long n, out T[] l) => l = String(n).Select(Convert<T>()).ToArray();

        public static void Cin<T1, T2>(long n, out T1[] l1, out T2[] l2)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i]);
        }

        public static void Cin<T1, T2, T3>(long n, out T1[] l1, out T2[] l2, out T3[] l3)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i]);
        }

        public static void Cin<T1, T2, T3, T4>(long n, out T1[] l1, out T2[] l2, out T3[] l3, out T4[] l4)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            l4 = new T4[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i], out l4[i]);
        }

        public static void Cin<T>(out T[] a) => a = Convert<T[]>(String());

        public static void Cin<T>(long h, out T[][] map) => map = String(h).Select(Convert<T[]>()).ToArray();
    }

    class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            Console.SetOut(streamWriter);
            new Solver().Solve();
            Console.Out.Flush();
        }

        public static void Debug()
        {
            new Solver().Solve();
        }
    }

    class Solver
    {
        public void Solve()
        {
            int h, w;
            int[][] c;
            int[][] a;
            Cin(out h, out w);
            c = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                Cin(out c[i]);
            }

            a = new int[h][];
            for (int i = 0; i < h; i++)
            {
                Cin(out a[i]);
            }

            List<long> start = new List<long>();
            List<long> end = new List<long>();
            List<long> cost = new List<long>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    start.Add(i);
                    end.Add(j);
                    cost.Add(c[i][j]);
                }
            }

            var wf = new WarshallFloyd(10, 100, start, end, cost);

            long ans = 0;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (a[i][j] != -1)
                    {
                        ans += wf.ArriveCost[a[i][j]][1];
                    }
                }
            }

            Console.WriteLine(ans);
        }
    }

    public class WarshallFloyd
    {
        public static long INF = Int32.MaxValue;
        public long[][] ArriveCost;

        /// <summary>
        /// ワーシャルフロイド法で頂点間最短経路を求める
        /// </summary>
        /// <param name="V">頂点の数</param>
        /// <param name="K">辺の数</param>
        /// <param name="A">経路の始点</param>
        /// <param name="B">経路の終点</param>
        /// <param name="C">経路のコスト</param>
        public WarshallFloyd(long V, long K, List<long> A, List<long> B, List<long> C)
        {
            ArriveCost = Enumerable.Repeat(0, (int) V).Select(_ => Enumerable.Repeat(INF, (int) V).ToArray())
                .ToArray();
            for (int i = 0; i < V; i++)
            {
                ArriveCost[i][i] = 0;
            }

            for (int i = 0; i < K; i++)
            {
                ArriveCost[A[i]][B[i]] = Math.Min(ArriveCost[A[i]][B[i]], C[i]);
            }

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    for (int k = 0; k < V; k++)
                    {
                        ArriveCost[j][k] = Math.Min(ArriveCost[j][k], ArriveCost[j][i] + ArriveCost[i][k]);
                    }
                }
            }
        }
    }
}