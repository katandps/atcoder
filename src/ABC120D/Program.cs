using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC120D.Input;

namespace ABC120D
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
        private long M;
        private List<long> A;
        private List<long> B;

        public void Solve()
        {
            @in(out N, out M);
            @in(M, out A, out B);

            UnionFind uf = new UnionFind(N + 2);
            long[] ans = new long[M + 1];
            ans[M] = N * (N - 1) / 2;
            for (int i = (int) M - 1; i >= 0; i--)
            {
                if (uf.Root(A[i]) == uf.Root(B[i]))
                {
                    ans[i] = ans[i + 1];
                    continue;
                }

                ans[i] = ans[i + 1] - uf.Size(A[i]) * uf.Size(B[i]);
                uf.Unite(A[i], B[i]);
            }

            for (int i = 1; i <= M; i++)
            {
                Console.WriteLine(ans[i]);
            }
        }
    }

    public class UnionFind
    {
        private readonly long[] par;
        private readonly long[] size;

        public UnionFind(long maxN)
        {
            par = new long[maxN + 1];
            size = new long[maxN + 1];
            Init(maxN);
        }

        private void Init(long n)
        {
            for (var i = 1; i <= n; i++)
            {
                par[i] = i;
                size[i] = 1;
            }
        }

        public long Root(long x)
        {
            if (par[x] == x) return x;
            return par[x] = Root(par[x]);
        }

        public long Size(long x)
        {
            return size[Root(x)];
        }

        public bool Same(long x, long y)
        {
            return Root(x) == Root(y);
        }

        public void Unite(long x, long y)
        {
            x = Root(x);
            y = Root(y);
            if (x == y) return;
            if (size[x] < size[y])
            {
                var tmp = x;
                x = y;
                y = tmp;
            }

            size[x] += size[y];
            par[y] = x;
        }
    }
}