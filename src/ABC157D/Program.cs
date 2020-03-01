using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC157D
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
            input.Longs(ref N, ref M, ref K);
            input.LongsArray(M, ref A, ref B);
            input.LongsArray(K, ref C, ref D);
        }

        private long N;
        private long M;
        private long K;
        private long[] A;
        private long[] B;
        private long[] C;
        private long[] D;

        public void Solve()
        {
            var uf = new UnionFind((int)N);
            for (int i = 0; i < M; i++)
            {
                uf.Unite((int)A[i], (int)B[i], 1);
            }
            
            // 同じ木に属するユーザー数を求める
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 1; i <= N; i++)
            {
                var root = uf.Root(i);
                if (!d.ContainsKey(root))
                {
                    d.Add(root, 0);
                }

                d[root]++;
            }
            int[] mayFriends = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                mayFriends[i] = d[uf.Root(i)] - 1; // 自分は除く
            }
            
            // 直接友人関係にある同じ木のユーザー数を求める
            // 全友人関係のHashSetを作ってから異なる木のユーザーを削除する
            Dictionary<int, HashSet<int>> friends = new Dictionary<int, HashSet<int>>();
            for (int i = 1; i <= N; i++)
            {
                friends.Add(i, new HashSet<int>());
            }
            for (int i = 0; i < M; i++)
            {
                var a = (int) A[i];
                var b = (int) B[i];
                friends[a].Add(b);
                friends[b].Add(a);
            }

            foreach (var fr in friends)
            {
                HashSet<int> del = new HashSet<int>();
                foreach (int f in fr.Value)
                {
                    if (uf.Root(fr.Key) != uf.Root(f))
                    {
                        del.Add(f);
                    }
                }

                foreach (int f in del)
                {
                    fr.Value.Remove(f);
                }
            }

            // ブロック関係にある同じ木のユーザー数を求める
            // 全ブロック関係のHashSetを作ってから削除する
            Dictionary<int, HashSet<int>> blocks = new Dictionary<int, HashSet<int>>();
            for (int i = 1; i <= N; i++)
            {
                blocks.Add(i, new HashSet<int>());
            }
            for (int i = 0; i < K; i++)
            {
                var a = (int) C[i];
                var b = (int) D[i];
                blocks[a].Add(b);
                blocks[b].Add(a);
            }

            foreach (var bl in blocks)
            {
                HashSet<int> del = new HashSet<int>();
                foreach (int f in bl.Value)
                {
                    if (uf.Root(bl.Key) != uf.Root(f))
                    {
                        del.Add(f);
                    }
                }

                foreach (int f in del)
                {
                    bl.Value.Remove(f);
                }
            }

            for (int i = 1; i <= N; i++)
            {
                Console.Write("" + (mayFriends[i] - friends[i].Count - blocks[i].Count) + " ");
            }
            Console.WriteLine();
        }
    }
    
    public class UnionFind
    {
        private readonly int[] par;
        private readonly int[] rank;
        private readonly int[] weight;

        public UnionFind(int maxN)
        {
            par = new int[maxN + 1];
            rank = new int[maxN + 1];
            weight = new int[maxN + 1];
            Init(maxN);
        }

        private void Init(int n)
        {
            for (var i = 1; i <= n; i++)
            {
                par[i] = i;
                rank[i] = 0;
                weight[i] = 0;
            }
        }

        public int Root(int x)
        {
            if (par[x] == x) return x;

            var r = Root(par[x]);
            weight[x] += weight[par[x]];
            return par[x] = r;
        }

        public int Weight(int x)
        {
            Root(x);
            return weight[x];
        }

        public int Diff(int x, int y)
        {
            return weight[y] - weight[x];
        }

        public bool Same(int x, int y)
        {
            return Root(x) == Root(y);
        }

        public bool Unite(int x, int y, int d)
        {
            d += weight[x];
            d -= weight[y];

            x = Root(x);
            y = Root(y);

            if (x == y) return false;

            if (rank[x] < rank[y])
            {
                var temp = x;
                x = y;
                y = temp;
                d = -d;
            }

            if (rank[x] == rank[y]) ++rank[x];

            par[y] = x;
            weight[y] = d;
            return true;
        }
    }
}