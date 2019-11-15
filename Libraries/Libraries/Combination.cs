namespace Libraries
{
    public class Combination
    {
        public long[,] Comb;
        public long N;

        public Combination(int N)
        {
            this.N = N;
            Comb = new long[N + 1, N + 1];
            Init();
        }

        private void Init()
        {
            Comb[0, 0] = 1;
            for (var i = 0; i <= N; i++)
            for (var j = 0; j <= N; j++)
                if (j == 0)
                    Comb[i, j] = 1;
                else
                    Comb[i, j] = Comb[i - 1, j - 1] + Comb[i - 1, j];
        }

        public long Solve(int n, int k)
        {
            if ((k < 0) | (k > n)) return 0;
            return Comb[n, k];
        }
    }
}