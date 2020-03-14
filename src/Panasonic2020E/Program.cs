using System;
using System.Collections.Generic;
using System.Linq;

namespace Panasonic2020E
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
        /// 1行の入力を取得する
        /// </summary>
        /// <returns>文字列</returns>
        public void String(out char[] s)
        {
            s = Console.ReadLine().ToCharArray();
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
            input.String(out a);
            input.String(out b);
            input.String(out c);
        }

        private char[] a;
        private char[] b;
        private char[] c;

        private const int M = 2000;

        public void Solve()
        {
            bool[] ab = new bool[100000];
            bool[] ac = new bool[100000];
            bool[] bc = new bool[100000];

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (!match(a[i], b[j])) ab[i - j + 50000] = true;
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < c.Length; j++)
                {
                    if (!match(a[i], c[j])) ac[i - j + 50000] = true;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < c.Length; j++)
                {
                    if (!match(b[i], c[j])) bc[i - j + 50000] = true;
                }
            }

            int ans = 3 * M;
            for (int i = -2 * M; i <= 2 * M; i++)
            {
                for (int j = -2 * M; j <= 2 * M; j++)
                {
                    if (!ab[i + 50000] && !ac[j + 50000] && !bc[j - i + 50000])
                    {
                        var l = Math.Min(0, Math.Min(i, j));
                        var r = Math.Max(a.Length, Math.Max(b.Length + i, c.Length + j));
                        ans = Math.Min(ans, r - l);
                    }
                }
            }

            Console.WriteLine(ans);
        }

        bool match(char c1, char c2)
        {
            return c1 == '?' || c2 == '?' || c1 == c2;
        }
    }
}