﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Keyence2020B
{
    class Input
    {
        /// <summary>
        /// 1行の入力を取得する
        /// </summary>
        /// <returns>文字列</returns>
        public void String(out string s)
        {
            s = Console.ReadLine();
        }

        /// <summary>
        /// 複数行の入力を取得
        /// </summary>
        /// <returns>文字列の配列</returns>
        public void String(long rowNumber, out string[] s)
        {
            s = new String[rowNumber];
            for (long i = 0; i < rowNumber; i++)
            {
                String(out s[i]);
            }
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>int型の値</returns>
        public void Int(out int i)
        {
            string s;
            String(out s);
            i = int.Parse(s);
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <param name="a"></param>
        public void Long(out long a)
        {
            string s;
            String(out s);
            a = long.Parse(s);
        }

        /// <summary>
        /// 2つの整数が1行に書かれている入力を、2つのlongで受け取る
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Long(out long a, out long b)
        {
            long[] lArr;
            Long(out lArr);
            a = lArr[0];
            b = lArr[1];
        }

        /// <summary>
        /// 3つの整数が1行に書かれている入力を、3つのlongで受け取る
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Long(out long a, out long b, out long c)
        {
            long[] lArr;
            Long(out lArr);
            a = lArr[0];
            b = lArr[1];
            c = lArr[2];
        }

        /// <summary>
        /// 4つの整数が1行に書かれている入力を、4つのlongで受け取る
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void Long(out long a, out long b, out long c, out long d)
        {
            long[] lArr;
            Long(out lArr);
            a = lArr[0];
            b = lArr[1];
            c = lArr[2];
            d = lArr[3];
        }

        public void Long(out long[] lArr)
        {
            lArr = Split().Select(long.Parse).ToArray();
        }

        public void Long(long rowNumber, out long[] lArr)
        {
            lArr = new long[rowNumber];
            for (long i = 0; i < rowNumber; i++)
            {
                Long(out lArr[i]);
            }
        }

        /// <summary>
        /// 2つの整数が複数行に書かれている入力を、2つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Long(long rowNumber, out long[] a, out long[] b)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                Long(out a[i], out b[i]);
            }
        }

        /// <summary>
        /// 3つの整数が複数行に書かれている入力を、3つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Long(long rowNumber, out long[] a, out long[] b, out long[] c)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            c = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                Long(out a[i], out b[i], out c[i]);
            }
        }

        /// <summary>
        /// 4つの整数が複数行に書かれている入力を、4つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void Long(long rowNumber, out long[] a, out long[] b, out long[] c, out long[] d)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            c = new long[rowNumber];
            d = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                Long(out a[i], out b[i], out c[i], out d[i]);
            }
        }


        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の値</returns>
        public void Double(out double d)
        {
            string s;
            String(out s);
            d = double.Parse(s);
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の配列</returns>
        public void Double(out double[] dArr)
        {
            dArr = Split().Select(double.Parse).ToArray();
        }

        private IEnumerable<string> Split()
        {
            string s;
            String(out s);
            return s.Split(' ');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver();
            solver.Solve();
        }
    }

    class Solver
    {
        public Solver()
        {
            Input input = new Input();
            input.Long(out N);
            input.Long(N, out X, out L);
        }

        private long N;
        private long[] X;
        private long[] L;

        public void Solve()
        {
            Pair[] P = new Pair[N];
            for (long i = 0; i < N; i++)
            {
                P[i] = new Pair(X[i] - L[i], X[i] + L[i], i);
            }

            Array.Sort(P, new PairComperator());

            long ans = 0;
            long cur = -Int32.MaxValue;
            for (long i = 0; i < N; i++)
            {
                if (cur <= P[i].A)
                {
                    ans++;
                    cur = P[i].B;
                }
            }

            Console.WriteLine(ans);
        }
    }

    class Pair
    {
        public long A;
        public long B;
        public long I;

        public Pair(long a, long b, long i)
        {
            A = a;
            B = b;
            I = i;
        }

        public override string ToString()
        {
            return "i: " + I + "  A: " + A + "  B: " + B;
        }
    }

    class PairComperator : IComparer<Pair>
    {
        int IComparer<Pair>.Compare(Pair a, Pair b)
        {
            return (int) a.B - (int) b.B;
        }
    }
}