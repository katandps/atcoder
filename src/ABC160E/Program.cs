using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC160E.Input;

namespace ABC160E
{
    static class Input
    {
        private static Func<string, T[]> Cast<T>() => _ => _.Split(' ').Select(Convert<T>()).ToArray();

        private static Func<string, T> Convert<T>()
        {
            Type t = typeof(T);
            if (t == typeof(string)) return _ => (T) (object) _;
            if (t == typeof(int)) return _ => (T) (object) int.Parse(_);
            if (t == typeof(long)) return _ => (T) (object) long.Parse(_);
            if (t == typeof(double)) return _ => (T) (object) double.Parse(_);
            if (t == typeof(string[])) return _ => (T) (object) _.Split(' ');
            if (t == typeof(int[])) return _ => (T) (object) Cast<int>()(_);
            if (t == typeof(long[])) return _ => (T) (object) Cast<long>()(_);
            if (t == typeof(double[])) return _ => (T) (object) Cast<double>()(_);

            throw new NotSupportedException(t + "is not supported.");
        }

        private static T Convert<T>(string s) => Convert<T>()(s);

        private static string String() => Console.ReadLine();

        private static string[] String(long rowNumber) => new bool[rowNumber].Select(_ => String()).ToArray();

        public static void Cin<T>(out T a) => a = Convert<T>(String());

        public static void Cin<T1, T2>(out T1 a1, out T2 a2)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
        }

        public static void Cin<T1, T2, T3>(out T1 a1, out T2 a2, out T3 a3)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
        }

        public static void Cin<T1, T2, T3, T4>(out T1 a1, out T2 a2, out T3 a3, out T4 a4)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
        }

        public static void Cin<T1, T2, T3, T4, T5>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
        }

        public static void Cin<T1, T2, T3, T4, T5, T6>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5, out T6 a6)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
            set(v[5], out a6);
        }

        private static void set<T1>(string s, out T1 o1) => o1 = Convert<T1>(s);

        public static void Cin<T>(long n, out T[] l) => l = String(n).Select(Convert<T>()).ToArray();

        public static void Cin<T1, T2>(long n, out T1[] l1, out T2[] l2)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i]);
        }

        public static void Cin<T1, T2, T3>(long n, out T1[] l1, out T2[] l2, out T3[] l3)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i]);
        }

        public static void Cin<T1, T2, T3, T4>(long n, out T1[] l1, out T2[] l2, out T3[] l3, out T4[] l4)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            l4 = new T4[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i], out l4[i]);
        }

        public static void Cin<T>(out T[] a) => a = Convert<T[]>(String());

        public static void Cin<T>(long h, out T[][] map) => map = String(h).Select(Convert<T[]>()).ToArray();
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
        private long X, Y, A, B, C;
        private long[] p, q, r;

        public void Solve()
        {
            Cin(out X, out Y, out A, out B, out C);
            Cin(out p);
            Cin(out q);
            Cin(out r);

            Array.Sort(p);
            Array.Sort(q);
            Array.Sort(r);
            Array.Reverse(p);
            Array.Reverse(q);
            Array.Reverse(r);

            //たべるやつ
            var xpq = new PriorityQueue<long>(false);
            var ypq = new PriorityQueue<long>(false);
            int count = 1;
            foreach (long l in p)
            {
                if (count > X) break;
                xpq.Enqueue(l);
                count++;
            }

            count = 1;
            foreach (long l in q)
            {
                if (count > Y) break;
                ypq.Enqueue(l);
                count++;
            }

            long ans = 0;
            for (int i = 0; i < C; i++)
            {
                var x = xpq.Dequeue();
                var y = ypq.Dequeue();
                if (x < y)
                {
                    ypq.Enqueue(y);
                    if (x < r[i])
                    {
                        xpq.Enqueue(r[i]);
                    }
                    else
                    {
                        xpq.Enqueue(x);
                    }
                }
                else
                {
                    xpq.Enqueue(x);
                    if (y < r[i])
                    {
                        ypq.Enqueue(r[i]);
                    }
                    else
                    {
                        ypq.Enqueue(y);
                    }
                }
            }

            while (xpq.Count > 0)
            {
                ans += xpq.Dequeue();
            }

            while (ypq.Count > 0)
            {
                ans += ypq.Dequeue();
            }


            Console.WriteLine(ans);
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