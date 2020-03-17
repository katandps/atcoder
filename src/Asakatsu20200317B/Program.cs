using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200317B.Input;
using static System.Math;

namespace Asakatsu20200317B
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
        private int N;
        private long[] x;
        private long[] y;

        public void Solve()
        {
            @in(out N);
            @in(N, out x, out y);

            var p = new Permutation<int>(Enumerable.Range(0, N).ToList());

            double sum = 0;
            for (int i = 0; i < p.permutation.Count; i++)
            {
                var c = p.permutation[i];
                double d = 0;
                for (int j = 1; j < c.Count; j++)
                {
                    d += Sqrt((x[c[j - 1]] - x[c[j]]) * (x[c[j - 1]] - x[c[j]]) +
                              (y[c[j - 1]] - y[c[j]]) * (y[c[j - 1]] - y[c[j]]));
                }

                sum += d;
            }

            Console.WriteLine(sum / p.permutation.Count);
        }
    }

    /// <summary>
    /// 順列を生成する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Permutation<T>
    {
        public Permutation(List<T> list)
        {
            Permutate(list);
        }

        public List<List<T>> permutation = new List<List<T>>();

        private void Permutate(List<T> rest, List<T> current = null)
        {
            if (current == null) current = new List<T>();

            foreach (var l in rest)
            {
                var next = new List<T>();
                foreach (T v in current)
                {
                    next.Add(v);
                }

                next.Add(l);

                if (rest.Count == 1)
                {
                    permutation.Add(next);
                    continue;
                }

                var nextRest = new List<T>();
                foreach (T r in rest)
                {
                    if (r.Equals(l)) continue;
                    nextRest.Add(r);
                }

                Permutate(nextRest, next);
            }
        }
    }
}