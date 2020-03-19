using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200319B.Input;

namespace Asakatsu20200319B
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

        public static void @in<T1, T2>(long rowNumber, out List<T1> l1, out List<T2> l2)
        {
            l1 = new List<T1>();
            l2 = new List<T2>();
            foreach (List<string> l in String(rowNumber).Select(Convert<List<string>>()))
            {
                l1.Add(Convert<T1>()(l[0]));
                l2.Add(Convert<T2>()(l[1]));
            }
        }

        public static void @in<T1, T2, T3>(long rowNumber, out List<T1> l1, out List<T2> l2, out List<T3> l3)
        {
            l1 = new List<T1>();
            l2 = new List<T2>();
            l3 = new List<T3>();
            foreach (List<string> l in String(rowNumber).Select(Convert<List<string>>()))
            {
                l1.Add(Convert<T1>()(l[0]));
                l2.Add(Convert<T2>()(l[1]));
                l3.Add(Convert<T3>()(l[2]));
            }
        }

        public static void @in<T1, T2, T3, T4>(long rowNumber, out List<T1> l1, out List<T2> l2, out List<T3> l3,
            out List<T4> l4)
        {
            l1 = new List<T1>();
            l2 = new List<T2>();
            l3 = new List<T3>();
            l4 = new List<T4>();
            foreach (List<string> l in String(rowNumber).Select(Convert<List<string>>()))
            {
                l1.Add(Convert<T1>()(l[0]));
                l2.Add(Convert<T2>()(l[1]));
                l3.Add(Convert<T3>()(l[2]));
                l4.Add(Convert<T4>()(l[3]));
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
        private string N;

        public void Solve()
        {
            @in(out N);

            List<string> l = new List<string>();
            l.Add(N);
            var p = new string(Enumerable.Repeat('9', N.Length - 1).ToArray());
            char b = N[0];
            b--;
            l.Add(b + p);
            for (int i = 0; i < N.Length; i++)
            {
                string s = "";
                for (int j = 0; j < N.Length; j++)
                {
                    if (i == j) s += '8';
                    else s += '9';
                }

                l.Add(s);
            }

            int ans = 0;
            var n = long.Parse(N);
            foreach (string s in l)
            {
                if (long.Parse(s) > n) continue;

                int a = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    a += int.Parse(new string(new[] {s[i]}));
                }

                ans = Math.Max(a, ans);
            }

            Console.WriteLine(ans);
        }
    }
}