using System;
using System.Collections.Generic;
using System.Linq;

namespace Asakatsu20200312F
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
            input.Long(out N, out M);
            input.Long(out A);

            match = new int[10];
            match[1] = 2;
            match[2] = 5;
            match[3] = 5;
            match[4] = 4;
            match[5] = 5;
            match[6] = 6;
            match[7] = 3;
            match[8] = 7;
            match[9] = 6;
        }

        private long N;
        private long M;
        private long[] A;

        //match
        private int[] match;

        public void Solve()
        {
            Array.Sort(A);

            // 使って良い数字のうち、最もパフォーマンス(桁数>数字)が大きいものを選択する
            long bestPerf = -1;
            long bestPerfUse = 10;
            foreach (long ai in A)
            {
                if (match[ai] < bestPerfUse)
                {
                    bestPerfUse = match[ai];
                    bestPerf = ai;
                }
                else if (match[ai] == bestPerfUse && ai > bestPerf)
                {
                    bestPerf = ai;
                }
            }

            if (N % bestPerfUse == 0)
            {
                for (long i = 0; i < N / bestPerfUse; i++)
                {
                    Console.Write(bestPerf);
                }

                Console.WriteLine();
                return;
            }

            //残りがパフォーマンスの最も高い数字の倍数になるように残りをDPして、大きい方の数字から辞書の逆順に出力
            List<long>[] dp = new List<long>[421];
            for (long i = 0; i < 421; i++)
            {
                dp[i] = new List<long>();
            }

            dp[0].Add(0);

            var l = A.ToList();
            l.Remove(bestPerf);
            A = l.ToArray();
            for (long i = 0; i < 421; i++)
            {
                foreach (long ai in A)
                {
                    if (dp[i].Count <= 0 || i + match[ai] > 420 || i + match[ai] > N)
                    {
                        continue;
                    }

                    List<long> b = new List<long>();
                    foreach (long m in dp[i])
                    {
                        b.Add(m);
                    }

                    b.Add(ai);
                    dp[i + match[ai]] = Comp(dp[i + match[ai]], b);
                }
            }

            List<long> k1 = new List<long>();
            List<long> k2 = new List<long>();
            List<long> k3 = new List<long>();
            long rest = N;
            for (long i = 1; i < 421; i++)
            {
                if (k1.Count == 0 && (N - i) % bestPerfUse == 0 && dp[i].Count > 0)
                {
                    k1 = dp[i];
                    rest = N - i;
                }
                else if (k2.Count == 0 && (N - i) % bestPerfUse == 0 && dp[i].Count > 0)
                {
                    k2 = dp[i];
                    for (long j = 0; j < (rest - N + i) / bestPerfUse; j++)
                    {
                        k1.Add(bestPerf);
                    }

                    rest = N - i;
                }
                else if (k3.Count == 0 && (N - i) % bestPerfUse == 0 && dp[i].Count > 0)
                {
                    k3 = dp[i];
                    for (long j = 0; j < (rest - N + i) / bestPerfUse; j++)
                    {
                        k1.Add(bestPerf);
                        k2.Add(bestPerf);
                    }

                    rest = N - i;
                }
            }

            var best = Comp(k1, Comp(k2, k3));
            best.Remove(0);
            for (long i = 0; i < rest / bestPerfUse; i++)
            {
                best.Add(bestPerf);
            }

            best.Sort();
            best.Reverse();
            for (long i = 0; i < best.Count; i++)
            {
                Console.Write(best[(int) i]);
            }

            Console.WriteLine();
        }

        List<long> Comp(List<long> a, List<long> b)
        {
            //桁数が大きいほうが有利
            if (a.Count != b.Count)
            {
                return a.Count > b.Count ? a : b;
            }

            a.Sort();
            b.Sort();
            a.Reverse();
            b.Reverse();

            //持っている数字を大きい方から比べて大きいほうが有利
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return a[i] > b[i] ? a : b;
                }
            }

            return a;
        }
    }
}