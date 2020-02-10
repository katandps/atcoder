using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC154E
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
            N = input.String();
            K = int.Parse(input.String());
        }

        private string N;
        private int K;

        public void Solve()
        {
            if (N.Length < K)
            {
                Console.WriteLine(0);
                return;
            }

            if (K == 1)
            {
                // 先頭桁が0でなく、ほかがすべて0
                int v = N[0] - 48;
                Console.WriteLine((N.Length - 1) * 9 + v);
                return;
            }

            if (K == 2)
            {
                Console.WriteLine(two(N));
                return;
            }

            // K == 3
            Console.WriteLine(three());
        }

        long two(string n)
        {
            // Nが足りない
            if (n.Length <= 2 && long.Parse(n) <= 10)
            {
                return 0;
            }

            long ans = 0;
            // 先頭桁が0でない、かつほかの桁に一つだけ0が入る
            // nが100あれば、 99以下の数字は常に組み合わせられる
            // つまりnを2桁落とせば、すべての組み合わせについて試して良い
            for (int i = 0; i < n.Length - 2; i++)
            {
                // i + 2桁目が9通り それぞれについてj+1桁目を0でないとしたとき、それぞれに9通り
                ans += 9 * (i + 1) * 9;
            }

            ans += 9 * (n.Length - 1) * (n[0] - 48 - 1);
            // nの値に近いものは全探索
            // 先頭桁の数字はn[0]とする
            bool over = false;
            // 2つ目の数字のインデックス
            for (int j = 1; j < n.Length; j++)
            {
                if (over)
                {
                    ans += 9;
                    continue;
                }

                if (n[j] - 48 > 0)
                {
                    over = true;
                }

                ans += n[j] - 48;
            }

            return ans;
        }

        long three()
        {
            // Nが足りない
            if (N.Length <= 3 && long.Parse(N) <= 110)
            {
                return 0;
            }

            long ans3 = 0;
            // 先頭桁が0でない、かつほかの桁に一つだけ0が入る
            // Nが1000あれば、 999以下の数字は常に組み合わせられる
            // つまりNを3桁落とせば、すべての組み合わせについて試して良い
            long t = 1;
            for (int i = 1; i <= N.Length - 3; i++)
            {
                // i + 2桁目が9通り それぞれについてj+1桁目とk+1を0でないとしたとき、それぞれに9通り
                // 2つ目と3つ目の数字を区別しないので/2
                ans3 += 9 * 9 * 9 * t;
                t += i + 1;
            }

            // Nの値に近いものは全探索
            // 先頭桁の数字はN[0]とする


            // 2つ目と3つ目の数字の選び方(full)
          //  ans3 += 9 * 9 * (N.Length - 1) * (N.Length - 2) / 2 * (N[0] - 1);
            // 1つ目の数字はN[0]
            // 2つ目の数字のインデックス
            for (int i = 1; i < N.Length - 1; i++)
            {
                // 2つ目の数字はN[j]とする
                ans3 += 9 * (N.Length - i - 1) * (N[i] - 1);
                // 3つ目の数字のインデックス
                var over = false;
                for (int j = i + 1; j < N.Length; j++)
                {
                    if (over)
                    {
                        ans3 += 9;
                        continue;
                    }

                    if (N[j] - 48 > 0)
                    {
                        over = true;
                    }

                    ans3 += N[j] - 48;
                }
            }

            return ans3;
        }
    }
}