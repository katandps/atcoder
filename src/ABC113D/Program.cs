﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC113D.Input;

namespace ABC113D
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
        private long H;
        private long W;
        private long K;

        public void Solve()
        {
            @in(out H, out W, out K);

            int fall = 0;
            int p = (int) Math.Pow(2, W - 1);
            // 全探索
            for (int i = 0; i < p; i++)
            {
                bool invalidate = false;
                var n = i;
                bool before = false;
                for (int j = 0; j < W - 1; j++)
                {
                    int bit = n % 2;
                    n = n >> 1;
                    if (bit != 0 && before)
                    {
                        invalidate = true;
                        break;
                    }

                    before = bit != 0;
                }

                if (invalidate) continue;

                fall++;
            }

            Modular[][] dp = new Modular[H + 1][];
            dp[0] = new Modular[W];
            dp[0][0] = 1;
            for (int i = 1; i < W; i++)
            {
                dp[0][i] = 0;
            }

            for (int i = 1; i <= H; i++)
            {
                dp[i] = new Modular[W];
                for (int j = 0; j < W; j++)
                {
                    dp[i][j] = 0;
                }

                for (int j = 0; j < W; j++)
                {
                    dp[i][j] = dp[i - 1][j];
                    if (j > 0)
                    {
                        dp[i][j] = dp[i][j] + dp[i - 1][j - 1];
                    }

                    if (j < W - 1)
                    {
                        dp[i][j] = dp[i][j] + dp[i - 1][j + 1];
                    }
                }
            }

            Console.WriteLine((int)dp[H][K-1]);
        }
    }

    class Modular
    {
        public static int M = 1000000007;
        private long V;

        public Modular(long v)
        {
            V = v;
        }

        public static implicit operator Modular(long a)
        {
            var m = a % M;
            return new Modular(m < 0 ? m + M : m);
        }

        public static Modular operator +(Modular a, Modular b)
        {
            return a.V + b.V;
        }

        public static Modular operator -(Modular a, Modular b)
        {
            return a.V - b.V;
        }

        public static Modular operator *(Modular a, Modular b)
        {
            return a.V * b.V;
        }

        public static Modular Pow(Modular a, int n)
        {
            switch (n)
            {
                case 0:
                    return 1;
                case 1:
                    return a;
                default:
                    var p = Pow(a, n / 2);
                    return p * p * Pow(a, n % 2);
            }
        }

        public static Modular operator /(Modular a, Modular b)
        {
            return a * Pow(b, M - 2);
        }

        private static readonly List<int> Facts = new List<int> {1};

        public static Modular Fac(int n)
        {
            for (int i = Facts.Count; i <= n; ++i)
            {
                Facts.Add((int) (Math.BigMul(Facts.Last(), i) % M));
            }

            return Facts[n];
        }

        public static Modular Ncr(int n, int r)
        {
            if (n < r)
            {
                return 0;
            }

            if (n == r)
            {
                return 1;
            }

            return Fac(n) / (Fac(r) * Fac(n - r));
        }

        public static explicit operator int(Modular a)
        {
            return (int) a.V;
        }
    }
}