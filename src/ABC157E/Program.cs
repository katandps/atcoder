using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC157E
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
            input = new Input();
            N = input.Int();
            S = input.String().ToCharArray();
            Q = input.Int();
        }

        private Input input;
        private int N;
        private char[] S;
        private int Q;

        public void Solve()
        {
            Dictionary<char, BinaryIndexedTree> sumByAlphabet = new Dictionary<char, BinaryIndexedTree>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                sumByAlphabet.Add(c, new BinaryIndexedTree(N));
            }

            for (int i = 0; i < N; i++)
            {
                sumByAlphabet[S[i]].Add(i + 1, 1);
            }

            for (int i = 0; i < Q; i++)
            {
                string[] q = input.String().Split(' ');
                if (q[0] == "1")
                {
                    char c = q[2][0];
                    int index = int.Parse(q[1]);
                    sumByAlphabet[c].Add(index, 1);
                    sumByAlphabet[S[index - 1]].Add(index, -1);
                    S[index - 1] = c;
                }
                else if (q[0] == "2")
                {
                    int left = int.Parse(q[1]);
                    int right = int.Parse(q[2]);
                    
                    int a = 0;
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (sumByAlphabet[c].Sum(right) - sumByAlphabet[c].Sum(left - 1) > 0)
                        {
                            a++;
                        }
                    }
                    Console.WriteLine(a);
                }
            }
        }
    }

    class BinaryIndexedTree
    {
        private int[] _bit = new int[1000000];
        private int _n;

        public BinaryIndexedTree(int n)
        {
            _n = n;
        }

        /// <summary>
        /// a に wを足す
        /// </summary>
        /// <param name="a"></param>
        /// <param name="w"></param>
        public void Add(int a, int w)
        {
            for (int x = a; x <= _n; x += (x & -x))
            {
                _bit[x] += w;
            }
        }

        /// <summary>
        /// a番目の値の合計値を取る
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Sum(int a)
        {
            int ret = 0;
            for (int x = a; x > 0; x -= (x & -x))
            {
                ret += _bit[x];
            }

            return ret;
        }
    }
}