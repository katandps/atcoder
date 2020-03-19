using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200320D.Input;

namespace Asakatsu20200320D
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

        public static void Cin<T1, T2>(long n, out List<T1> l1, out List<T2> l2)
        {
            l1 = new List<T1>();
            l2 = new List<T2>();
            foreach (List<string> l in String(n).Select(Convert<List<string>>()))
            {
                l1.Add(Convert<T1>(l[0]));
                l2.Add(Convert<T2>(l[1]));
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
        private long N;
        private List<int> u;
        private List<int> v;
        private List<long> w;

        public void Solve()
        {
            Cin(out N);
            Cin(N - 1, out u, out v, out w);

            HashSet<int>[] neighbor = new HashSet<int>[N + 1];
            var distance = new Dictionary<Pair, long>();
            for (int i = 0; i <= N; i++)
            {
                neighbor[i] = new HashSet<int>();
            }

            for (int i = 0; i < N - 1; i++)
            {
                neighbor[u[i]].Add(v[i]);
                neighbor[v[i]].Add(u[i]);
                distance.Add(new Pair(u[i], v[i]), w[i]);
                distance.Add(new Pair(v[i], u[i]), w[i]);
            }

            bool[] color = new bool[N + 1];
            HashSet<long> memo = new HashSet<long>();
            Queue<KeyValuePair<int, bool>> q = new Queue<KeyValuePair<int, bool>>();
            q.Enqueue(new KeyValuePair<int, bool>(1, true));
            color[1] = true;
            memo.Add(1);
            while (q.Count > 0)
            {
                var c = q.Dequeue();
                foreach (var l in neighbor[c.Key])
                {
                    if (memo.Contains(l)) continue;
                    memo.Add(l);
                    var d = distance[new Pair(l, c.Key)];
                    color[l] = c.Value ^ (d % 2 != 0);
                    q.Enqueue(new KeyValuePair<int, bool>(l, color[l]));
                }
            }

            for (int i = 1; i <= N; i++)
            {
                Console.Write("" + (color[i] ? 1 : 0) + " ");
            }

            Console.WriteLine();
        }
    }

    /// <summary>
    /// 値のペア ソート/出力用のindexも持つ
    /// </summary>
    class Pair
    {
        private int A;
        private int B;

        public Pair(int a, int b)
        {
            A = a;
            B = b;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pair))
            {
                return false;
            }

            var c = (Pair) obj;
            return A == c.A && B == c.B;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() ^ B.GetHashCode();
        }
    }
}