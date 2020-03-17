using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC116D.Input;

namespace ABC116D
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
        private long N;
        private long K;
        private List<long> t;
        private List<long> d;

        public void Solve()
        {
            @in(out N, out K);
            @in(N, out t, out d);
            List<Pair> first = new List<Pair>();
            List<Pair> second = new List<Pair>();
            HashSet<long> seen = new HashSet<long>();
            for (int i = 0; i < N; i++)
            {
                if (seen.Contains(t[i]))
                {
                    second.Add(new Pair(t[i], d[i], i));
                }
                else
                {
                    first.Add(new Pair(t[i], d[i], i));
                    seen.Add(t[i]);
                }
            }

            first.Sort(new PairComperator());
            second.Sort(new PairComperator());

            long sum = 0;
            for (int i = 0; i < K; i++)
            {
                if (i < first.Count) sum += first[i].B;
                else sum += second[i - first.Count].B;
            }

            long ans = sum + Math.Min(first.Count, K) * Math.Min(first.Count, K);

            int fIndex = (int) Math.Min(first.Count, K) - 1;
            int sIndex = 0;
            //K種類から1種類の寿司を食べる
            for (long i = K; i >= 0; i--)
            {
                //寿司がたりない
                if (first.Count < i)
                {
                    continue;
                }

                sum = sum - first[fIndex].B + second[sIndex].B;
                ans = Math.Max(ans, sum + (i - 1) * (i - 1));
                sIndex++;
                fIndex--;
                if (sIndex >= second.Count || fIndex < 0)
                {
                    break;
                }
            }

            Console.WriteLine(ans);
        }
    }

    /// <summary>
    /// 値のペア ソート/出力用のindexも持つ
    /// </summary>
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
            return (int) b.B - (int) a.B;
        }
    }
}