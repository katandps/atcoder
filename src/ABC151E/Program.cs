using System;
using System.Collections.Generic;
using System.Linq;

// namespaceの値をコンテスト名にして運用
namespace ABC151E
{
    class Input
    {
        /// <summary>
        /// 1行の入力を取得する
        /// </summary>
        /// <returns>文字列</returns>
        public string String()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// 複数行の入力を取得
        /// </summary>
        /// <returns>文字列の配列</returns>
        public string[] ArrayString(int rowNumber)
        {
            string[] s = new string[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                s[i] = String();
            }

            return s;
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>int型の値</returns>
        public int Int()
        {
            return int.Parse(String());
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>int型の配列</returns>
        public int[] ArrayInt()
        {
            return Split().Select(int.Parse).ToArray();
        }

        /// <summary>
        /// 複数行の入力を取得
        /// </summary>
        /// <param name="rowNumber">行数</param>
        /// <returns>int型の配列</returns>
        public int[] ArrayInt(int rowNumber)
        {
            int[] ints = new int[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                ints[i] = Int();
            }

            return ints;
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>long型の値</returns>
        public long Long()
        {
            return long.Parse(String());
        }

        /// <summary>
        /// 2つの整数が1行に書かれている入力を、2つのlongで受け取る
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void Longs(ref long A, ref long B)
        {
            var longs = ArrayLong();
            A = longs[0];
            B = longs[1];
        }

        /// <summary>
        /// 3つの整数が1行に書かれている入力を、3つのlongで受け取る
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void Longs(ref long A, ref long B, ref long C)
        {
            var longs = ArrayLong();
            A = longs[0];
            B = longs[1];
            C = longs[2];
        }

        /// <summary>
        /// 4つの整数が1行に書かれている入力を、4つのlongで受け取る
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        public void Longs(ref long A, ref long B, ref long C, ref long D)
        {
            var longs = ArrayLong();
            A = longs[0];
            B = longs[1];
            C = longs[2];
            D = longs[3];
        }

        /// <summary>
        /// 2つの整数が複数行に書かれている入力を、2つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void LongsArray(long rowNumber, ref long[] A, ref long[] B)
        {
            A = new long[rowNumber];
            B = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                var l = ArrayLong();
                A[i] = l[0];
                B[i] = l[1];
            }
        }

        /// <summary>
        /// 3つの整数が複数行に書かれている入力を、2つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void LongsArray(long rowNumber, ref long[] A, ref long[] B, ref long[] C)
        {
            A = new long[rowNumber];
            B = new long[rowNumber];
            C = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                var l = ArrayLong();
                A[i] = l[0];
                B[i] = l[1];
                C[i] = l[2];
            }
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>long型の配列</returns>
        public long[] ArrayLong()
        {
            return Split().Select(long.Parse).ToArray();
        }

        public long[] ArrayLong(int rowNumber)
        {
            long[] longs = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                longs[i] = Long();
            }

            return longs;
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の値</returns>
        public double Double()
        {
            return double.Parse(String());
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の配列</returns>
        public double[] ArrayDouble()
        {
            return Split().Select(double.Parse).ToArray();
        }

        private IEnumerable<string> Split()
        {
            return String().Split(' ');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver();
            solver.Solve();
        }
    }

    class Solver
    {
        public Solver()
        {
            Input input = new Input();
            input.Longs(ref N, ref K);
            A = input.ArrayLong();
        }

        private long N;
        private long K;
        private long[] A;

        public void Solve()
        {
            Array.Sort(A);

            Modular ans = new Modular(0);
            var Ncr = Modular.Ncr((int) N, (int) K);
            // 隣り合う２つの数のうち、右側をiとする
            for (int i = 1; i < N; i++)
            {
                long width = A[i] - A[i - 1];
                
                // 全体から左側のみ、右側のみを引く
                var Left = Modular.Ncr(i, (int)K);
                var Right = Modular.Ncr((int) N - i, (int) K);
                var p = Ncr - Left - Right;
                ans = ans + p * width;
            }

            Console.WriteLine((int)ans);
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