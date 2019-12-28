using System;
using System.Collections.Generic;
using System.Linq;

// namespaceの値をコンテスト名にして運用
namespace AGC041B
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
            input.Longs(ref N, ref M, ref V, ref P);
            A = input.ArrayLong();
        }

        private long N;
        private long M;
        private long V;
        private long P;
        private long[] A;
        private long minScore;

        public void Solve()
        {
            Array.Sort(A);
            Array.Reverse(A);

            //P番目のスコアと同じスコアになれば採用される
            minScore = A[P - 1];
            long pOver = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] > minScore)
                {
                    pOver++;
                }
            }
            // 投票可能問題数が採用予定問題数以上のとき、ボーダースコアよりスコアが低い問題に投票させないと
            // 採用させることができない
            long voteByJudge = V - pOver;

            Console.WriteLine(Search(voteByJudge) + 1);
        }
        
        /// <summary>
        /// 二分探索
        /// </summary>
        /// <returns>条件を満たす最小の値</returns>
        long Search(long voteByJudge)
        {
            // だめ
            long ng = N;
            // 採用可能性あり
            long ok = -1;

            while (Math.Abs(ok - ng) > 1)
            {
                long mid = (ok + ng) / 2;
                if (isOk(mid, voteByJudge)) ok = mid;
                else ng = mid;
            }

            return ok;
        }

        bool isOk(long index, long voteByJudge)
        {
            // 採用可能
            if (A[index] >= minScore)
            {
                return true;
            }

            // どう足しても足りない
            if (A[index] + M < minScore)
            {
                return false;
            }

            // 投票可能問題が採用予定問題より小さいなら、
            // 採用確定問題にだけ投票すれば最低点を超えられる
            // 任意の問題を採用できる
            if (voteByJudge <= 0)
            {
                return true;
            }

            long rest = 0;
            long max = A[index] + M;
            for (int i = 0; i < N; i++)
            {
                if (A[i] > minScore)
                {
                    rest += M;
                    continue;
                }

                if (index == i)
                {
                    rest += M;
                    continue;
                }
                
                rest += Math.Min(max - A[i], M);
            }

            return rest >= M * V;
        }
    }
}