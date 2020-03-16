using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC084D.Input;
using static System.Math;

namespace ABC084D
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
        private long Q;
        private long[] l;
        private long[] r;

        public void Solve()
        {
            @in(out Q);
            @in(Q, out l, out r);

            long max = r.Max();
            var p = Primes(max);
            long[] count = new long[max + 1];
            for (int i = 1; i <= max; i++)
            {
                count[i] = count[i - 1];
                if (i % 2 == 0)
                {
                    continue;
                }

                if (p.Contains(i) && p.Contains((i + 1) / 2))
                {
                    count[i]++;
                }
            }

            for (int i = 0; i < Q; i++)
            {
                Console.WriteLine(count[r[i]] - count[l[i] - 1]);
            }
        }

        /// m以下の素数を列挙する
        HashSet<long> Primes(long m)
        {
            HashSet<long> l = new HashSet<long>();
            bool[] b = new bool[m + 1];
            b[0] = true;
            b[1] = true;
            for (int i = 2; i < m; i++)
            {
                for (int j = 2; i * j <= m; j++)
                {
                    b[i * j] = true;
                }
            }

            for (int i = 2; i <= m; i++)
            {
                if (!b[i])
                {
                    l.Add(i);
                }
            }

            return l;
        }
    }
}