﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200318E.Input;

namespace Asakatsu20200318E
{
    static class Input
    {
        /// <summary>
        /// 1行の入力をTに応じてリストに変換する関数を返す
        /// </summary>
        static Func<string, List<T>> Cast<T>() => _ => _.Split(' ').Select(Convert<T>()).ToList();

        /// <summary>
        /// 1行の入力をTに応じて変換する関数を返す
        /// </summary>
        static Func<string, T> Convert<T>()
        {
            Type t = typeof(T);
            if (t == typeof(string)) return _ => (T) (object) _;
            if (t == typeof(int)) return _ => (T) (object) int.Parse(_);
            if (t == typeof(long)) return _ => (T) (object) long.Parse(_);
            if (t == typeof(double)) return _ => (T) (object) double.Parse(_);
            if (t == typeof(List<string>)) return _ => (T) (object) Cast<string>()(_);
            if (t == typeof(List<int>)) return _ => (T) (object) Cast<int>()(_);
            if (t == typeof(List<long>)) return _ => (T) (object) Cast<long>()(_);
            if (t == typeof(List<double>)) return _ => (T) (object) Cast<double>()(_);

            throw new NotSupportedException(t + "is not supported.");
        }

        static string String() => Console.ReadLine();

        static List<string> String(long rowNumber) => new bool[rowNumber].Select(_ => String()).ToList();

        /// <summary>
        /// 1行の値の入力
        /// </summary>
        public static void @in<T>(out T a) => a = Convert<List<T>>()(String())[0];

        public static void @in<T>(out T a1, out T a2)
        {
            var v = Convert<List<T>>()(String());
            a1 = v[0];
            a2 = v[1];
        }

        public static void @in<T>(out T a1, out T a2, out T a3)
        {
            var v = Convert<List<T>>()(String());
            a1 = v[0];
            a2 = v[1];
            a3 = v[2];
        }

        public static void @in<T>(out T a1, out T a2, out T a3, out T a4)
        {
            var v = Convert<List<T>>()(String());
            a1 = v[0];
            a2 = v[1];
            a3 = v[2];
            a4 = v[3];
        }

        public static void @in<T>(out T a1, out T a2, out T a3, out T a4, out T a5)
        {
            var v = Convert<List<T>>()(String());
            a1 = v[0];
            a2 = v[1];
            a3 = v[2];
            a4 = v[3];
            a5 = v[4];
        }

        public static void @in<T>(out T a1, out T a2, out T a3, out T a4, out T a5, out T a6)
        {
            var v = Convert<List<T>>()(String());
            a1 = v[0];
            a2 = v[1];
            a3 = v[2];
            a4 = v[3];
            a5 = v[4];
            a6 = v[5];
        }

        /// <summary>
        /// 複数行の値の入力
        /// </summary>
        public static void @in<T>(long rowNumber, out List<T> l) => l = String(rowNumber).Select(Convert<T>()).ToList();

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2)
        {
            l1 = new List<T>();
            l2 = new List<T>();
            foreach (List<T> l in String(rowNumber).Select(Convert<List<T>>()))
            {
                l1.Add(l[0]);
                l2.Add(l[1]);
            }
        }

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2, out List<T> l3)
        {
            l1 = new List<T>();
            l2 = new List<T>();
            l3 = new List<T>();
            foreach (List<T> l in String(rowNumber).Select(Convert<List<T>>()))
            {
                l1.Add(l[0]);
                l2.Add(l[1]);
                l3.Add(l[2]);
            }
        }

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2, out List<T> l3, out List<T> l4)
        {
            l1 = new List<T>();
            l2 = new List<T>();
            l3 = new List<T>();
            l4 = new List<T>();
            foreach (List<T> l in String(rowNumber).Select(Convert<List<T>>()))
            {
                l1.Add(l[0]);
                l2.Add(l[1]);
                l3.Add(l[2]);
                l4.Add(l[3]);
            }
        }

        /// <summary>
        /// 1行に書かれた複数の値の入力
        /// </summary>
        public static void @in<T>(out List<T> lArr) => lArr = Convert<List<T>>()(String());

        /// <summary>
        /// h行の行列の入力
        /// </summary>
        public static void @in<T>(long h, out List<List<T>> map) => map = String(h).Select(Convert<List<T>>()).ToList();
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
        private int N;
        private int M;
        private List<int> P;
        private List<int> X;
        private List<int> Y;

        public void Solve()
        {
            @in(out N, out M);
            @in(out P);
            @in(M, out X, out Y);

            long ans = 0;
            UnionFind uf = new UnionFind(N);
            for (int i = 0; i < M; i++)
            {
                uf.Unite(X[i], Y[i]);
            }

            for (int i = 0; i < N; i++)
            {
                if (uf.Root(P[i]) == uf.Root(i + 1)) ans++;
            }

            Console.WriteLine(ans);
        }
    }


    public class UnionFind
    {
        private readonly int[] par;
        private readonly int[] rank;

        public UnionFind(int maxN)
        {
            par = new int[maxN + 1];
            rank = new int[maxN + 1];
            Init(maxN);
        }

        private void Init(int n)
        {
            for (var i = 1; i <= n; i++)
            {
                par[i] = i;
                rank[i] = 0;
            }
        }

        public int Root(int x)
        {
            if (par[x] == x) return x;
            return par[x] = Root(par[x]);
        }

        public int Rank(int x)
        {
            return rank[x];
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
            if (rank[x] < rank[y])
            {
                var tmp = x;
                x = y;
                y = tmp;
            }

            if (rank[x] == rank[y]) ++rank[x];
            par[x] = y;
        }
    }
}