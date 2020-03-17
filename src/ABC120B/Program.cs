using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC120B.Input;

namespace ABC120B
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

        static void Set<T>(List<T> s, out T o1) => o1 = s[0];

        static void Set<T>(List<T> s, out T o1, out T o2)
        {
            o1 = s[0];
            o2 = s[1];
        }

        static void Set<T>(List<T> s, out T o1, out T o2, out T o3)
        {
            o1 = s[0];
            o2 = s[1];
            o3 = s[2];
        }

        static void Set<T>(List<T> s, out T o1, out T o2, out T o3, out T o4)
        {
            o1 = s[0];
            o2 = s[1];
            o3 = s[2];
            o4 = s[3];
        }

        static void Set<T>(List<T> s, out T o1, out T o2, out T o3, out T o4, out T o5)
        {
            o1 = s[0];
            o2 = s[1];
            o3 = s[2];
            o4 = s[3];
            o5 = s[4];
        }

        static void Set<T>(List<T> s, out T o1, out T o2, out T o3, out T o4, out T o5, out T o6)
        {
            o1 = s[0];
            o2 = s[1];
            o3 = s[2];
            o4 = s[3];
            o5 = s[4];
            o6 = s[5];
        }

        /// <summary>
        /// 1行の値の入力
        /// </summary>
        public static void @in<T>(out T a) =>
            Set(Convert<List<T>>()(String()), out a);

        public static void @in<T>(out T a1, out T a2) =>
            Set(Convert<List<T>>()(String()), out a1, out a2);

        public static void @in<T>(out T a1, out T a2, out T a3) =>
            Set(Convert<List<T>>()(String()), out a1, out a2, out a3);

        public static void @in<T>(out T a1, out T a2, out T a3, out T a4) =>
            Set(Convert<List<T>>()(String()), out a1, out a2, out a3, out a4);

        public static void @in<T>(out T a1, out T a2, out T a3, out T a4, out T a5) =>
            Set(Convert<List<T>>()(String()), out a1, out a2, out a3, out a4, out a5);

        public static void @in<T>(out T a1, out T a2, out T a3, out T a4, out T a5, out T a6) =>
            Set(Convert<List<T>>()(String()), out a1, out a2, out a3, out a4, out a5, out a6);


        /// <summary>
        /// 複数行の値の入力
        /// </summary>
        public static void @in<T>(long rowNumber, out List<T> l) => l = String(rowNumber).Select(Convert<T>()).ToList();

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2) =>
            Set(String(rowNumber).Select(Convert<List<T>>()).ToList(), out l1, out l2);

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2, out List<T> l3) =>
            Set(String(rowNumber).Select(Convert<List<T>>()).ToList(), out l1, out l2, out l3);

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2, out List<T> l3, out List<T> l4) =>
            Set(String(rowNumber).Select(Convert<List<T>>()).ToList(), out l1, out l2, out l3, out l4);

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
        private int A;
        private int B;
        private int K;

        public void Solve()
        {
            @in(out A, out B, out K);

            int cnt = 0;
            for (int i = Math.Min(A, B); i > 0; i--)
            {
                if (A % i == 0 && B % i == 0) cnt++;

                if (cnt == K)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}