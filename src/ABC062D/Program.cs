using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC062D.Input;

namespace ABC062D
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
        private int N;
        private List<long> A;

        public void Solve()
        {
            @in(out N);
            @in(out A);

            long leftSum = 0;
            long rightSum = 0;
            long[] leftOut = new long[N + 1];
            long[] rightOut = new long[N + 1];
//            List<long> left = new List<long>();
            PriorityQueue<long> left = new PriorityQueue<long>(new LeftComparer());
            PriorityQueue<long> right = new PriorityQueue<long>(new RightComparer());
            for (int i = 0; i < N; i++)
            {
                leftSum += A[i];
                left.Enqueue(A[i]);
                rightSum += A[3 * N - i - 1];
                right.Enqueue(A[3 * N - i - 1]);
            }

            for (int i = 0; i < N; i++)
            {
                leftOut[i + 1] = leftOut[i] + left.Dequeue();
                left.Enqueue(A[i + N]);
                rightOut[N - i - 1] = rightOut[N - i] + right.Dequeue();
                right.Enqueue(A[2 * N - i - 1]);
            }

            long[] leftIn = new long[N + 1];
            long[] rightIn = new long[N + 1];
            for (int i = 0; i < N; i++)
            {
                leftIn[i + 1] = leftIn[i] + A[i + N];
                rightIn[N - i - 1] = rightIn[N - i] + A[2 * N - i - 1];
            }

            long[] leftMaxPerf = new long[N + 1];
            long[] rightMaxPerf = new long[N + 1];
            for (int i = 0; i < N; i++)
            {
                leftMaxPerf[i + 1] = Math.Max(leftMaxPerf[i], leftIn[i + 1] - leftOut[i + 1]);
                rightMaxPerf[N - i - 1] = Math.Max(rightMaxPerf[N - i], rightOut[N - i - 1] - rightIn[N - i - 1]);
            }

            long ans = (long) -Math.Pow(10, 15);
            for (int i = 0; i <= N; i++)
            {
                var a = leftSum - rightSum + leftMaxPerf[i] + rightMaxPerf[i];
                ans = Math.Max(ans, a);
            }

            Console.WriteLine(ans);
        }
    }

    class LeftComparer : IComparer<long>
    {
        int IComparer<long>.Compare(long a, long b)
        {
            return b - a >= 0 ? 1 : -1;
        }
    }

    class RightComparer : IComparer<long>
    {
        int IComparer<long>.Compare(long a, long b)
        {
            return a - b >= 0 ? 1 : -1;
        }
    }

    public class PriorityQueue<T> : IEnumerable<T>
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
                Swap(childIndex, parentIndex);
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
}