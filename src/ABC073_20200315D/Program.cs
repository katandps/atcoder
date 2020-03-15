using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC073_20200315D.Input;

namespace ABC073_20200315D
{
    class Input
    {
        /// <summary>
        /// 1行の文字列の入力
        /// </summary>
        public static void @in(out string s)
        {
            s = String();
        }

        private static String String()
        {
            return Console.ReadLine();
        }

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
        public static void @in(out long a)
        {
            a = Long()[0];
        }

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

        private static long[] Long()
        {
            return Split().Select(long.Parse).ToArray();
        }

        /// <summary>
        /// 1行に書かれた複数の整数列の入力
        /// </summary>
        public static void @in(out long[] lArr)
        {
            lArr = Long();
        }

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
        public static void @in(out double d)
        {
            d = double.Parse(String());
        }

        /// <summary>
        /// 1行に書かれた小数の配列の入力
        /// </summary>
        public static void @in(out double[] dArr)
        {
            dArr = Split().Select(double.Parse).ToArray();
        }

        private static IEnumerable<string> Split()
        {
            return String().Split(' ');
        }
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
        private long M;
        private long R;
        private long[] r;
        private long[] A;
        private long[] B;
        private long[] C;

        public void Solve()
        {
            @in(out N, out M, out R);
            @in(out r);
            @in(M, out A, out B, out C);


            long[][] distance = new long[N + 1][];
            for (int i = 0; i < N + 1; i++)
            {
                distance[i] = new long[N + 1];
            }

            for (int i = 0; i < N + 1; i++)
            {
                distance[i] = Enumerable.Repeat<long>(Int32.MaxValue, (int) N + 1).ToArray();
                distance[i][i] = 0;
            }

            for (int i = 0; i < M; i++)
            {
                distance[A[i]][B[i]] = C[i];
                distance[B[i]][A[i]] = C[i];
            }

            // 街の間の最短距離を求める
            for (int k = 1; k < N + 1; k++)
            {
                for (int i = 1; i < N + 1; i++)
                {
                    for (int j = 1; j < N + 1; j++)
                    {
                        distance[i][j] = Math.Min(distance[i][j], distance[i][k] + distance[k][j]);
                    }
                }
            }

            HashSet<long> rest = new HashSet<long>();
            foreach (long l in r)
            {
                rest.Add(l);
            }

            //街を訪れる順番について、全探索
            Permutation(rest, new long[0]);

            long ans = Int32.MaxValue;
            foreach (long[] p in per)
            {
                long a = 0;
                for (int i = 1; i < R; i++)
                {
                    a += distance[p[i]][p[i - 1]];
                }

                ans = Math.Min(ans, a);
            }

            Console.WriteLine(ans);
        }

        List<long[]> per = new List<long[]>();

        void Permutation(HashSet<long> rest, long[] current)
        {
            if (rest.Count == 0)
            {
                per.Add(current);
                return;
            }

            foreach (long l in rest)
            {
                var next = new long[current.Length + 1];
                Array.Copy(current, next, current.Length);
                next[current.Length] = l;
                var nextRest = new HashSet<long>();
                foreach (long l1 in rest)
                {
                    nextRest.Add(l1);
                }

                nextRest.Remove(l);
                Permutation(nextRest, next);
            }
        }
    }
}