﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200327F.Input;

namespace Asakatsu20200327F
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
        private int N;
        private int[] A;

        private int MOD = 1000000007;

        public void Solve()
        {
            Cin(out N);
            Cin(out A);


            var diff = new List<Modular>();
            int before = 0;
            int mcount = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] == -1)
                {
                    mcount++;
                    continue;
                }

                if (mcount > 0)
                {
                    int k = A[i] - before;
                    if (k > 0)
                    {
                        diff.Add(combination(k + mcount, mcount));
                    }

                    mcount = 0;
                }

                before = A[i];
            }

            Modular ans = 1;
            foreach (Modular t in diff)
            {
                ans = ans * t;
            }

            Console.WriteLine((int) ans);
        }

        Modular combination(Modular n, Modular r)
        {
            Modular a = 1;
            Modular b = 1;
            for (int i = 1; i <= (int) r; i++)
            {
                a = (n - i + 1) * a;
                b = b * i;
            }

            return a * Modular.Pow(b, MOD - 2);
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