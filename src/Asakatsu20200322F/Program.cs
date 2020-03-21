using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200322F.Input;

namespace Asakatsu20200322F
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
            for (int i = 0; i < n; i++)
            {
                var l = String().Split(' ').ToList();
                l1[i] = Convert<T1>(l[0]);
                l2[i] = Convert<T2>(l[1]);
            }
        }

        public static void Cin<T1, T2, T3>(long n, out List<T1> l1, out List<T2> l2, out List<T3> l3)
        {
            l1 = new List<T1>();
            l2 = new List<T2>();
            l3 = new List<T3>();
            foreach (List<string> l in String(n).Select(Convert<List<string>>()))
            {
                l1.Add(Convert<T1>(l[0]));
                l2.Add(Convert<T2>(l[1]));
                l3.Add(Convert<T3>(l[2]));
            }
        }

        public static void Cin<T1, T2, T3, T4>(long n, out List<T1> l1, out List<T2> l2, out List<T3> l3,
            out List<T4> l4)
        {
            l1 = new List<T1>();
            l2 = new List<T2>();
            l3 = new List<T3>();
            l4 = new List<T4>();
            foreach (List<string> l in String(n).Select(Convert<List<string>>()))
            {
                l1.Add(Convert<T1>(l[0]));
                l2.Add(Convert<T2>(l[1]));
                l3.Add(Convert<T3>(l[2]));
                l4.Add(Convert<T4>(l[3]));
            }
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
        private int N;
        int[] A;
        int[] B;

        public void Solve()
        {
            Cin(out N);
            Cin(N - 1, out A, out B);

            Dictionary<int, List<int>> neighbor = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> neighbor2 = new Dictionary<int, List<int>>();
            for (int i = 0; i < N + 1; i++)
            {
                neighbor.Add(i, new List<int>());
                neighbor2.Add(i, new List<int>());
            }

            for (int i = 0; i < N - 1; i++)
            {
                neighbor[A[i]].Add(B[i]);
                neighbor2[A[i]].Add(B[i]);
                neighbor[B[i]].Add(A[i]);
                neighbor2[B[i]].Add(A[i]);
            }


            HashSet<int> memo = new HashSet<int>();
            int[] dist1 = new int[N + 1];
            memo.Add(1);
            Func<int, int, int, int> dfs = null;
            dfs = (v, prev, dist) =>
            {
                dist1[v] = dist;
                foreach (var i in neighbor[v])
                {
                    if (i == prev) continue;
                    dfs(i, v, dist + 1);
                }

                return 0;
            };
            dfs(1, -1, 0);

            int maxIndex = 0;
            for (int i = 1; i <= N; i++)
            {
                if (dist1[i] > dist1[maxIndex]) maxIndex = i;
            }

            // Console.WriteLine(1);

            int[] dist2 = new int[N + 1];

            dfs = (v, prev, dist) =>
            {
                dist2[v] = dist;
                foreach (var i in neighbor[v])
                {
                    if (i == prev) continue;
                    dfs(i, v, dist + 1);
                }

                return 0;
            };
            dfs(maxIndex, -1, 0);
            Console.WriteLine((dist2.Max() + 1) % 3 == 2 ? "Second" : "First");
        }
    }
}