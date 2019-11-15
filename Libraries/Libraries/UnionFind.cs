namespace Libraries
{
    public class UnionFind
    {
        private readonly int[] par;
        private readonly int[] rank;

        public UnionFind(int maxN)
        {
            par = new int[maxN + 1];
            rank = new int[maxN + 1];
            Init(maxN);
        }

        private void Init(int n)
        {
            for (var i = 1; i <= n; i++)
            {
                par[i] = i;
                rank[i] = 0;
            }
        }

        public int Root(int x)
        {
            if (par[x] == x) return x;
            return par[x] = Root(par[x]);
        }

        public int Rank(int x)
        {
            return rank[x];
        }

        public bool Same(int x, int y)
        {
            return Root(x) == Root(y);
        }

        public void Unite(int x, int y)
        {
            x = Root(x);
            y = Root(y);
            if (x == y) return;
            if (rank[x] < rank[y])
            {
                var tmp = x;
                x = y;
                y = tmp;
            }

            if (rank[x] == rank[y]) ++rank[x];
            par[x] = y;
        }
    }
}