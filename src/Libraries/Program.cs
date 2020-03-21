using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Libraries.Input;

namespace Libraries
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

        static T Convert<T>(string s) => Convert<T>()(s);

        static string String() => Console.ReadLine();

        static List<string> String(long rowNumber) => new bool[rowNumber].Select(_ => String()).ToList();

        /// <summary>
        /// 1行の値の入力
        /// </summary>
        public static void Cin<T>(out T a) => a = Convert<List<T>>(String())[0];

        public static void Cin<T1, T2>(out T1 a1, out T2 a2)
        {
            var v = Convert<List<string>>(String());
            a1 = Convert<T1>(v[0]);
            a2 = Convert<T2>(v[1]);
        }

        public static void Cin<T1, T2, T3>(out T1 a1, out T2 a2, out T3 a3)
        {
            var v = Convert<List<string>>(String());
            a1 = Convert<T1>(v[0]);
            a2 = Convert<T2>(v[1]);
            a3 = Convert<T3>(v[2]);
        }

        public static void Cin<T1, T2, T3, T4>(out T1 a1, out T2 a2, out T3 a3, out T4 a4)
        {
            var v = Convert<List<string>>(String());
            a1 = Convert<T1>(v[0]);
            a2 = Convert<T2>(v[1]);
            a3 = Convert<T3>(v[2]);
            a4 = Convert<T4>(v[3]);
        }

        public static void Cin<T1, T2, T3, T4, T5>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5)
        {
            var v = Convert<List<string>>(String());
            a1 = Convert<T1>(v[0]);
            a2 = Convert<T2>(v[1]);
            a3 = Convert<T3>(v[2]);
            a4 = Convert<T4>(v[3]);
            a5 = Convert<T5>(v[4]);
        }

        public static void Cin<T1, T2, T3, T4, T5, T6>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5, out T6 a6)
        {
            var v = Convert<List<string>>(String());
            a1 = Convert<T1>(v[0]);
            a2 = Convert<T2>(v[1]);
            a3 = Convert<T3>(v[2]);
            a4 = Convert<T4>(v[3]);
            a5 = Convert<T5>(v[4]);
            a6 = Convert<T6>(v[5]);
        }

        /// <summary>
        /// 複数行の値の入力
        /// </summary>
        public static void Cin<T>(long n, out List<T> l) => l = String(n).Select(Convert<T>()).ToList();

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

        /// <summary>
        /// 1行に書かれた複数の値の入力
        /// </summary>
        public static void Cin<T>(out List<T> lArr) => lArr = Convert<List<T>>(String());

        /// <summary>
        /// h行の行列の入力
        /// </summary>
        public static void Cin<T>(long h, out List<List<T>> map) => map = String(h).Select(Convert<List<T>>()).ToList();
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
        }
    }
}