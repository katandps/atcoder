namespace UnionFind
{
    public class UnionFind
    {
        private int[] par;

        public UnionFind(int maxN)
        {
            par = new int[maxN + 1];
            Init(maxN);
        }

        void Init(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                par[i] = i;
            }
        }

        public int Root(int x)
        {
            if (par[x] == x)
            {
                return x;
            }

            return par[x] = Root(par[x]);
        }

        public bool Same(int x, int y)
        {
            return Root(x) == Root(y);
        }

        public void Unite(int x, int y)
        {
            x = Root(x);
            y = Root(y);
            if (x == y)
            {
                return;
            }

            par[x] = y;
        }
    }
}