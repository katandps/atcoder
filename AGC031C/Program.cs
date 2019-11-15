using System;
using System.Linq;

namespace AGC031C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] longs = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            long N = longs[0];
            long A = longs[1];
            long B = longs[2];

            Solver solver = new Solver();
            string ans = solver.solve(N, A, B);
            Console.WriteLine(ans);
        }
    }

    class Solver
    {
        public string solve(long N, long A, long B)
        {
            if (N == 1)
            {
                return "YES\n" + A + " " + B;
            }

            long diff = Math.Abs(A - B);

            bool[] diffBits = new bool[N];
            for (int i = 0; i < N; i++)
            {
                diffBits[i] = diff % 2 > 0;
                diff = diff >> 1;
            }

            int diffs = diffBits.Count(n => n);
            int nonDiffs = diffBits.Count(n => !n);

            if (nonDiffs > 1 | diffs % 2 == 0)
            {
                return "NO";
            }

            Searcher searcher = new Searcher(A, diffBits, "", 0);

            return "YES\n" + A + " " + searcher.search();
        }
    }

    class Searcher
    {
        private long A;
        private bool[] diffBits;
        private string log;
        private int depth;

        public Searcher(long A, bool[] diffBits, string log, int depth)
        {
            this.A = A;
            this.diffBits = diffBits;
            this.log = log;
            this.depth = depth;
        }

        public string search()
        {
            int targetBit1 = -1;
            int targetBit2 = -1;
            int see = -1;
            for (int i = 0; i < diffBits.Length; i++)
            {
                if (diffBits[i])
                {
                    see++;
                }
                if (see == depth)
                {
                    targetBit1 = i;
                }

                if (see == depth + 1)
                {
                    targetBit2 = i;
                }
            }

            if (targetBit2 == -1)
            {
                return one(targetBit1);
            }

            long seed1 = (long) Math.Pow(2, targetBit1);
            long seed2 = (long) Math.Pow(2, targetBit2);

            Searcher aaa;
            
            A ^= seed1;
            add(A);
            
            A ^= seed2;
            add(A);
            
            A ^= seed1;
            add(A);

            aaa = new Searcher(A, diffBits, log, depth + 2);
            log = aaa.search();
            A = aaa.A;

            A ^= seed2;
            add(A);
            
            A ^= seed1;
            add(A);

            A ^= seed2;
            add(A);

            return log;
        }

        void add(long A)
        {
            log += Convert.ToString(A, 2) + " ";
        }

        public string one(int index)
        {
            long diffSeed = (long) Math.Pow(2, index);

            int notDiffIndex = -1;
            for (int i = 0; i < diffBits.Length; i++)
            {
                if (!diffBits[i])
                {
                    notDiffIndex = i;
                }
            }

            if (notDiffIndex == -1)
            {
                A ^= diffSeed;
                add(A);
                return log;
            }

            long nonDiffSeed = (long) Math.Pow(2, notDiffIndex);

            A ^= nonDiffSeed;
            add(A);

            A ^= diffSeed;
            add(A);

            A ^= nonDiffSeed;
            add(A);

            return log;
        }
    }
}