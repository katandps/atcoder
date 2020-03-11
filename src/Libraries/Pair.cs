using System.Collections.Generic;

namespace Libraries
{
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
            return (int) a.B - (int) b.B;
        }
    }
}