using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC062C.Input;

namespace ABC062C
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
        private long H;
        private long W;

        public void Solve()
        {
            @in(out H, out W);

            long ans = H * W;
            long[] l = new long[3];
            l[0] = H / 3 * W;
            l[1] = (H + 1) / 3 * W;
            l[2] = (H + 2) / 3 * W;
            ans = Math.Min(ans, l.Max() - l.Min());
            l[0] = W / 3 * H;
            l[1] = (W + 1) / 3 * H;
            l[2] = (W + 2) / 3 * H;
            ans = Math.Min(ans, l.Max() - l.Min());

            for (int i = 0; i < H; i++)
            {
                long[] k = new long[3];
                k[0] = i * W;
                k[1] = (H - i) * ((W + 1) / 2);
                k[2] = (H - i) * (W / 2);
                ans = Math.Min(k.Max() - k.Min(), ans);
            }

            for (int i = 0; i < W; i++)
            {
                long[] k = new long[3];
                k[0] = i * H;
                k[1] = (W - i) * ((H + 1) / 2);
                k[2] = (W - i) * (H / 2);
                ans = Math.Min(k.Max() - k.Min(), ans);
            }

            Console.WriteLine(ans);
        }
    }
}