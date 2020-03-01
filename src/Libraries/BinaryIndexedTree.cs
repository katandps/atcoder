namespace Libraries
{
    /// <summary>
    /// BIT
    /// </summary>
    class BinaryIndexedTree
    {
        private int[] _bit = new int[1000000];
        private int _n;

        public BinaryIndexedTree(int n)
        {
            _n = n;
        }

        /// <summary>
        /// a に wを足す
        /// </summary>
        /// <param name="a"></param>
        /// <param name="w"></param>
        public void Add(int a, int w)
        {
            for (int x = a; x <= _n; x += (x & -x))
            {
                _bit[x] += w;
            }
        }

        /// <summary>
        /// a番目の値の合計値を取る
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Sum(int a)
        {
            int ret = 0;
            for (int x = a; x > 0; x -= (x & -x))
            {
                ret += _bit[x];
            }

            return ret;
        }
    }
}