using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC086D.Input;

namespace ABC086D
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
            if (t == typeof(char)) return _ => (T) (object) _[0];
            if (t == typeof(List<string>)) return _ => (T) (object) Cast<string>()(_);
            if (t == typeof(List<int>)) return _ => (T) (object) Cast<int>()(_);
            if (t == typeof(List<long>)) return _ => (T) (object) Cast<long>()(_);
            if (t == typeof(List<double>)) return _ => (T) (object) Cast<double>()(_);
            if (t == typeof(List<char>)) return _ => (T) (object) Cast<char>()(_);

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

        public static void @in<T, U>(long rowNumber, out List<T> l1, out List<U> l2)
        {
            l1 = new List<T>();
            l2 = new List<U>();
            foreach (List<string> l in String(rowNumber).Select(_ => _.Split(' ').ToList()))
            {
                l1.Add(Convert<T>()(l[0]));
                l2.Add(Convert<U>()(l[1]));
            }
        }

        public static void @in<T, U, V>(long rowNumber, out List<T> l1, out List<U> l2, out List<V> l3)
        {
            l1 = new List<T>();
            l2 = new List<U>();
            l3 = new List<V>();
            foreach (List<string> l in String(rowNumber).Select(_ => _.Split(' ').ToList()))
            {
                l1.Add(Convert<T>()(l[0]));
                l2.Add(Convert<U>()(l[1]));
                l3.Add(Convert<V>()(l[2]));
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
        private List<long> x;
        private List<long> y;
        private List<char> c;

        public void Solve()
        {
            @in(out N, out K);
            @in(N, out x, out y, out c);

            // 2K * 2Kの正方形のどこに黒が来れば何点取れるか、を表す配列に座圧する
            // 400万通りしかないので、累積和が取れるはず

            long sq = K * 2;
            int[][] black = new int[sq][];
            for (int i = 0; i < sq; i++)
            {
                black[i] = new int[sq];
            }

            for (int i = 0; i < N; i++)
            {
                if (c[i] == 'B')
                {
                    black[x[i] % sq][y[i] % sq]++;
                    black[(x[i] + K) % sq][(y[i] + K) % sq]++;
                }
                else
                {
                    black[(x[i]) % sq][(y[i] + K) % sq]++;
                    black[(x[i] + K) % sq][(y[i]) % sq]++;
                }
            }

            int[][] sum = new int[sq][];
            for (int i = 0; i < sq; i++)
            {
                sum[i] = new int[sq];
            }

            for (int i = 1; i <= K; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    sum[0][0] += black[(i + K) % sq][(j + K) % sq];
                }
            }


            for (int i = 1; i < sq; i++)
            {
                sum[0][i] = sum[0][i - 1];
                sum[i][0] = sum[i - 1][0];
                for (int j = 0; j < K; j++)
                {
                    sum[0][i] += black[(j + K + 1) % sq][i];
                    sum[0][i] -= black[(j + K + 1) % sq][(i + K) % sq];
                    sum[i][0] += black[i][(j + K + 1) % sq];
                    sum[i][0] -= black[(i + K) % sq][(j + K + 1) % sq];
                }
            }

            for (int i = 1; i < sq; i++)
            {
                for (int j = 1; j < sq; j++)
                {
                    sum[i][j] = sum[i - 1][j]
                                + sum[i][j - 1]
                                - sum[i - 1][j - 1]
                                - black[(i + K) % sq][j]
                                - black[i][(j + K) % sq]
                                + black[(i + K) % sq][(j + K) % sq]
                                + black[i][j];
                }
            }

            long ans = 0;
            for (int i = 0; i < sq; i++)
            {
                for (int j = 0; j < sq; j++)
                {
                    ans = Math.Max(ans, sum[i][j]);
                }
            }

            Console.WriteLine(ans);
        }
    }
}