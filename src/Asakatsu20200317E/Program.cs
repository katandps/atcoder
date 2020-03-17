using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200317E.Input;
using static System.Math;

namespace Asakatsu20200317E
{
    class Input
    {
        private static String String() => Console.ReadLine();

        private static IEnumerable<string> Split() => String().Split(' ');

        private static long[] Long() => Split().Select(long.Parse).ToArray();

        /// <summary>
        /// 1行の文字列の入力
        /// </summary>
        public static void @in(out string s) => s = String();

        /// <summary>
        /// 複数行の文字列の入力
        /// </summary>
        public static void @in(long rowNumber, out string[] s)
        {
            s = new String[rowNumber];
            for (long i = 0; i < rowNumber; i++) @in(out s[i]);
        }

        /// <summary>
        /// 1行に書かれた1つの整数の入力
        /// </summary>
        public static void @in(out int i)
        {
            i = int.Parse(String());
        }

        /// <summary>
        /// 1行に書かれた1つの整数の入力
        /// </summary>
        public static void @in(out long a) => a = Long()[0];

        /// <summary>
        /// 1行に書かれた2つの整数の入力
        /// </summary>
        public static void @in(out long a, out long b)
        {
            long[] lArr = Long();
            a = lArr[0];
            b = lArr[1];
        }

        /// <summary>
        /// 1行に書かれた3つの整数の入力
        /// </summary>
        public static void @in(out long a, out long b, out long c)
        {
            long[] lArr = Long();
            a = lArr[0];
            b = lArr[1];
            c = lArr[2];
        }

        /// <summary>
        /// 1行に書かれた4つの整数の入力
        /// </summary>
        public static void @in(out long a, out long b, out long c, out long d)
        {
            long[] lArr = Long();
            a = lArr[0];
            b = lArr[1];
            c = lArr[2];
            d = lArr[3];
        }

        /// <summary>
        /// 1行に書かれた5つの整数の入力
        /// </summary>
        public static void @in(out long a, out long b, out long c, out long d, out long e)
        {
            long[] lArr = Long();
            a = lArr[0];
            b = lArr[1];
            c = lArr[2];
            d = lArr[3];
            e = lArr[4];
        }

        /// <summary>
        /// 1行に書かれた複数の整数列の入力
        /// </summary>
        public static void @in(out long[] lArr) => lArr = Long();

        /// <summary>
        /// rowNumber行に書かれた1つの整数列の入力
        /// </summary>
        public static void @in(long rowNumber, out long[] lArr)
        {
            lArr = new long[rowNumber];
            for (long i = 0; i < rowNumber; i++) @in(out lArr[i]);
        }

        /// <summary>
        /// rowNumber行に書かれた2つの整数列の入力
        /// </summary>
        public static void @in(long rowNumber, out long[] a, out long[] b)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++) @in(out a[i], out b[i]);
        }

        /// <summary>
        /// rowNumber行に書かれた3つの整数列の入力
        /// </summary>
        public static void @in(long rowNumber, out long[] a, out long[] b, out long[] c)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            c = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++) @in(out a[i], out b[i], out c[i]);
        }

        /// <summary>
        /// rowNumber行に書かれた4つの整数列の入力
        /// </summary>
        public static void @in(long rowNumber, out long[] a, out long[] b, out long[] c, out long[] d)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            c = new long[rowNumber];
            d = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++) @in(out a[i], out b[i], out c[i], out d[i]);
        }

        /// <summary>
        /// h行w列の整数の行列の入力
        /// </summary>
        public static void @in(long h, long w, out long[][] a)
        {
            a = new long[h][];
            for (long i = 0; i < h; i++) @in(out a[i]);
        }

        /// <summary>
        /// 1行に書かれた1つの小数の入力
        /// </summary>
        public static void @in(out double d) => d = double.Parse(String());

        /// <summary>
        /// 1行に書かれた小数の配列の入力
        /// </summary>
        public static void @in(out double[] dArr) => dArr = Split().Select(double.Parse).ToArray();
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
        private long N;
        private long u;
        private long v;
        private long[] A;
        private long[] B;

        public void Solve()
        {
            @in(out N, out u, out v);
            @in(N - 1, out A, out B);

            HashSet<long>[] tree = new HashSet<long>[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                tree[i] = new HashSet<long>();
            }

            for (int i = 0; i < N - 1; i++)
            {
                tree[A[i]].Add(B[i]);
                tree[B[i]].Add(A[i]);
            }


            long[] t = new long[N + 1];
            long[] a = new long[N + 1];

            Queue<long> q = new Queue<long>();
            HashSet<long> memo = new HashSet<long>();
            t[u] = 0;
            memo.Add(u);
            q.Enqueue(u);

            while (q.Count > 0)
            {
                var c = q.Dequeue();
                foreach (long l in tree[c])
                {
                    if (memo.Contains(l))
                    {
                        continue;
                    }

                    memo.Add(l);
                    q.Enqueue(l);
                    t[l] = t[c] + 1;
                }
            }

            q = new Queue<long>();
            memo = new HashSet<long>();
            a[v] = 0;
            memo.Add(v);
            q.Enqueue(v);

            while (q.Count > 0)
            {
                var c = q.Dequeue();
                foreach (long l in tree[c])
                {
                    if (memo.Contains(l))
                    {
                        continue;
                    }

                    memo.Add(l);
                    q.Enqueue(l);
                    a[l] = a[c] + 1;
                }
            }

            long ans = 0;
            for (int i = 1; i <= N; i++)
            {
                if (a[i] > t[i])
                {
                    ans = Max(a[i], ans);
                }
            }

            Console.WriteLine(ans - 1);
        }
    }
}