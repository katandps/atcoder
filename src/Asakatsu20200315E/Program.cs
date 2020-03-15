using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Asakatsu20200315E
{
    class Input
    {
        /// <summary>
        /// 1行の入力を取得する
        /// </summary>
        /// <returns>文字列</returns>
        public void String(out string s)
        {
            s = Console.ReadLine();
        }

        /// <summary>
        /// 複数行の入力を取得
        /// </summary>
        /// <returns>文字列の配列</returns>
        public void String(long rowNumber, out string[] s)
        {
            s = new String[rowNumber];
            for (long i = 0; i < rowNumber; i++)
            {
                String(out s[i]);
            }
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>int型の値</returns>
        public void Int(out int i)
        {
            string s;
            String(out s);
            i = int.Parse(s);
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <param name="a"></param>
        public void Long(out long a)
        {
            string s;
            String(out s);
            a = long.Parse(s);
        }

        /// <summary>
        /// 2つの整数が1行に書かれている入力を、2つのlongで受け取る
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Long(out long a, out long b)
        {
            long[] lArr;
            Long(out lArr);
            a = lArr[0];
            b = lArr[1];
        }

        /// <summary>
        /// 3つの整数が1行に書かれている入力を、3つのlongで受け取る
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Long(out long a, out long b, out long c)
        {
            long[] lArr;
            Long(out lArr);
            a = lArr[0];
            b = lArr[1];
            c = lArr[2];
        }

        /// <summary>
        /// 4つの整数が1行に書かれている入力を、4つのlongで受け取る
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void Long(out long a, out long b, out long c, out long d)
        {
            long[] lArr;
            Long(out lArr);
            a = lArr[0];
            b = lArr[1];
            c = lArr[2];
            d = lArr[3];
        }

        public void Long(out long[] lArr)
        {
            lArr = Split().Select(long.Parse).ToArray();
        }

        public void Long(long rowNumber, out long[] lArr)
        {
            lArr = new long[rowNumber];
            for (long i = 0; i < rowNumber; i++)
            {
                Long(out lArr[i]);
            }
        }

        /// <summary>
        /// 2つの整数が複数行に書かれている入力を、2つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Long(long rowNumber, out long[] a, out long[] b)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                Long(out a[i], out b[i]);
            }
        }

        /// <summary>
        /// 3つの整数が複数行に書かれている入力を、3つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Long(long rowNumber, out long[] a, out long[] b, out long[] c)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            c = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                Long(out a[i], out b[i], out c[i]);
            }
        }

        /// <summary>
        /// 4つの整数が複数行に書かれている入力を、4つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void Long(long rowNumber, out long[] a, out long[] b, out long[] c, out long[] d)
        {
            a = new long[rowNumber];
            b = new long[rowNumber];
            c = new long[rowNumber];
            d = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                Long(out a[i], out b[i], out c[i], out d[i]);
            }
        }

        /// <summary>
        /// h行w列のLongのmapを入力する
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        /// <param name="a"></param>
        public void Long(long h, long w, out long[][] a)
        {
            a = new long[h][];
            for (long i = 0; i < h; i++)
            {
                Long(out a[i]);
            }
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の値</returns>
        public void Double(out double d)
        {
            string s;
            String(out s);
            d = double.Parse(s);
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の配列</returns>
        public void Double(out double[] dArr)
        {
            dArr = Split().Select(double.Parse).ToArray();
        }

        private IEnumerable<string> Split()
        {
            string s;
            String(out s);
            return s.Split(' ');
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            Console.SetOut(streamWriter);
            Solver solver = new Solver();
            solver.Solve();
            Console.Out.Flush();
        }

        public static void Debug()
        {
            Solver solver = new Solver();
            solver.Solve();
        }
    }

    class Solver
    {
        private Input input;

        public Solver()
        {
            input = new Input();
            input.Long(out N);
            input.String(out S);
            input.Long(out QN);
            input.String(QN, out Q);
        }

        private long N;
        private string S;
        private long QN;
        private string[] Q;

        public void Solve()
        {
            Dictionary<char, BinaryIndexedTree> bit = new Dictionary<char, BinaryIndexedTree>();
            for (int i = 0; i < 26; i++)
            {
                bit.Add((char) ('a' + i), new BinaryIndexedTree((int) N + 1));
            }

            for (int i = 0; i < N; i++)
            {
                bit[S[i]].Add(i + 1, 1);
            }

            char[] C = S.ToCharArray();
            foreach (string q in Q)
            {
                string[] qq = q.Split(' ');
                if (qq[0] == "1")
                {
                    var i = int.Parse(qq[1]);
                    char c = qq[2][0];
                    if (C[i - 1] == c) continue;
                    bit[C[i - 1]].Add(i, -1);
                    bit[c].Add(i, 1);
                    C[i - 1] = c;
                }
                else
                {
                    //q2
                    var l = int.Parse(qq[1]);
                    var r = int.Parse(qq[2]);

                    int count = 0;
                    for (char i = 'a'; i <= 'z'; i++)
                    {
                        //Console.WriteLine("" + i + " " + bit[i].Sum(r) + " " + bit[i].Sum(l));
                        if (bit[i].Sum(r) != bit[i].Sum(l - 1)) count++;
                    }

                    Console.WriteLine(count);
                }
            }
        }
    }

    /// <summary>
    /// BIT
    /// </summary>
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