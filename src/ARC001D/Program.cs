using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC001D
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
        }

        public void Solve()
        {
            Console.WriteLine(0);
        }
    }
}