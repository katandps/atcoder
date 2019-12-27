using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// namespaceの値をコンテスト名にして運用
namespace ABC137D
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

        public void LongsArray(int rowNumber, ref long[] A, ref long[] B)
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
    
    class PriorityQueue<T> : IEnumerable<T>
    {
        private readonly List<T> data = new List<T>();
        private readonly IComparer<T> comparer;
        private readonly bool isDescending;

        public PriorityQueue(IComparer<T> comparer, bool isDescending = true)
        {
            this.comparer = comparer;
            this.isDescending = isDescending;
        }

        public PriorityQueue(Comparison<T> comparison, bool isDescending = true)
            : this(Comparer<T>.Create(comparison), isDescending)
        {
        }

        public PriorityQueue(bool isDescending = true)
            : this(Comparer<T>.Default, isDescending)
        {
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            var childIndex = data.Count - 1;
            while (childIndex > 0)
            {
                var parentIndex = (childIndex - 1) / 2;
                if (Compare(data[childIndex], data[parentIndex]) >= 0) break;
                Swap(childIndex,parentIndex);
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (Count < 1)
            {
                throw new Exception("キューに値が入っていません");
            }
            
            var lastIndex = data.Count - 1;
            var firstItem = data[0];
            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);
            lastIndex--;

            var parentIndex = 0;
            while (true)
            {
                var childIndex = parentIndex * 2 + 1;
                if (childIndex > lastIndex)
                {
                    break;
                }

                var rightChild = childIndex + 1;
                if (rightChild <= lastIndex && Compare(data[rightChild], data[childIndex]) < 0)
                {
                    childIndex = rightChild;
                }

                if (Compare(data[parentIndex], data[childIndex]) <= 0)
                {
                    break;
                }
                Swap(parentIndex, childIndex);
                parentIndex = childIndex;
            }
            
            return firstItem;
        }

        public T Peek()
        {
            return data[0];
        }

        private void Swap(int a, int b)
        {
            var tmp = data[a];
            data[a] = data[b];
            data[b] = tmp;
        }

        private int Compare(T a, T b)
        {
            return isDescending ? comparer.Compare(b, a) : comparer.Compare(a, b);
        }

        public int Count => data.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
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
            input.Longs(ref N, ref M);
            input.LongsArray((int)N, ref A, ref B);
        }

        private long N;
        private long M;
        private long[] A;
        private long[] B;

        public void Solve()
        {
            //最後の日から順番に取得したい
            // <日数、<報酬>>
            Dictionary<long, List<long>> tasks = new Dictionary<long, List<long>>();
            for (int i = 1; i <= M; i++)
            {
                tasks.Add(i, new List<long>());
            }
            for (int i = 0; i < N; i++)
            {
                if (!tasks.ContainsKey(A[i]))
                {
                    continue;
                }
                tasks[A[i]].Add(B[i]);
            }
            
            PriorityQueue<long> pq = new PriorityQueue<long>();

            long ans = 0;
            for (int i = 1; i <= M; i++)
            {
                foreach (long l in tasks[i])
                {
                    pq.Enqueue(l);
                }

                if (pq.Count < 1)
                {
                    continue;
                }
                ans += pq.Dequeue();
            }
            
            Console.WriteLine(ans);
        }
    }
}