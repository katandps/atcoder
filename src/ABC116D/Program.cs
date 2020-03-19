using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC116D.Input;

namespace ABC116D
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

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2)
        {
            l1 = new List<T>();
            l2 = new List<T>();
            foreach (List<T> l in String(rowNumber).Select(Convert<List<T>>()))
            {
                l1.Add(l[0]);
                l2.Add(l[1]);
            }
        }

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2, out List<T> l3)
        {
            l1 = new List<T>();
            l2 = new List<T>();
            l3 = new List<T>();
            foreach (List<T> l in String(rowNumber).Select(Convert<List<T>>()))
            {
                l1.Add(l[0]);
                l2.Add(l[1]);
                l3.Add(l[2]);
            }
        }

        public static void @in<T>(long rowNumber, out List<T> l1, out List<T> l2, out List<T> l3, out List<T> l4)
        {
            l1 = new List<T>();
            l2 = new List<T>();
            l3 = new List<T>();
            l4 = new List<T>();
            foreach (List<T> l in String(rowNumber).Select(Convert<List<T>>()))
            {
                l1.Add(l[0]);
                l2.Add(l[1]);
                l3.Add(l[2]);
                l4.Add(l[3]);
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
        private long N;
        private long K;
        private List<long> t;
        private List<long> d;

        public void Solve()
        {
            @in(out N, out K);
            @in(N, out t, out d);

            Pair[] sushi = new Pair[N];
            for (int i = 0; i < N; i++)
            {
                sushi[i] = new Pair(t[i], d[i], i);
            }

            Array.Sort(sushi, new PairComperator());
            //現在のもの
            var s = new PriorityQueue<Pair>(new PairComperator());
            //残り
            var k = new PriorityQueue<Pair>(new PairComperator(), false);
            long sum = 0;
            Dictionary<long, int> count = new Dictionary<long, int>();
            for (int i = 0; i < K; i++)
            {
                sum += sushi[i].B;
                if (!count.ContainsKey(sushi[i].A)) count.Add(sushi[i].A, 0);
                count[sushi[i].A]++;
                s.Enqueue(sushi[i]);
            }

            long kinds = count.Count;

            for (long i = K; i < N; i++)
            {
                k.Enqueue(sushi[i]);
                if (!count.ContainsKey(sushi[i].A)) count.Add(sushi[i].A, 0);
            }

            long ans = sum + kinds * kinds;
            while (k.Count > 0 && s.Count > 0)
            {
                //2個以上持ってるのを外す
                var couldnt = true;
                while (s.Count > 0)
                {
                    var o = s.Dequeue();
                    if (count[o.A] > 1)
                    {
                        count[o.A]--;
                        sum -= o.B;
                        couldnt = false;
                        break;
                    }
                }

                if (couldnt) break;

                //持ってないのを入れる
                couldnt = true;
                while (k.Count > 0)
                {
                    var c = k.Dequeue();
                    if (count[c.A] > 0) continue;

                    count[c.A]++;
                    sum += c.B;
                    kinds++;
                    couldnt = false;
                    break;
                }

                if (couldnt) break;
                ans = Math.Max(ans, sum + kinds * kinds);
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


    /// <summary>
    /// 値のペア ソート/出力用のindexも持つ
    /// </summary>
    class Pair
    {
        public long A;
        public long B;
        public long I;

        public Pair(long a, long b, long i)
        {
            A = a;
            B = b;
            I = i;
        }

        public override string ToString()
        {
            return "i: " + I + "  A: " + A + "  B: " + B;
        }
    }

    class PairComperator : IComparer<Pair>
    {
        int IComparer<Pair>.Compare(Pair a, Pair b)
        {
            return (int) b.B - (int) a.B;
        }
    }
}