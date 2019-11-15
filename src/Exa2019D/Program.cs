using System;
using System.Collections.Generic;
using System.Linq;

namespace Exa2019D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] NX = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            int N = NX[0];
            int X = NX[1];

            int[] ss = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            Array.Sort(ss);
            List<int> S = ss.ToList();
            
            Factorial fact = new Factorial(N, 100000007);

            Solver solver = new Solver(X, fact, S);
            Console.WriteLine(solver.solve());
        }
    }

    class Solver
    {
        private int X;
        private Factorial fact;
        private List<int> S;
        
        public Solver(int X, Factorial fact, List<int> S)
        {
            this.X = X;
            this.fact = fact;
            this.S = S;
        }

        public long solve()
        {
            int min = S.Min();
            long ans = 0;
            for (int i = 0; i < S.Count; i++)
            {
                int mod = X % S[i];
                if (mod == 0)
                {
                    continue;
                }
                
                if (mod == min)
                {
                    ans += 0;
                    continue;
                }

                if (mod < min)
                {
                    ans += mod * fact.getFact(S.Count - 1) % 1000000007;
                    continue;
                }

                var ss = new List<int>(S);
                ss.RemoveAt(i);
                Solver solver = new Solver(mod, fact, ss);
                ans += solver.solve();
            }
            Console.Write("a");
            return ans % 1000000007;
        }
    }

    class Factorial
    {
        private long[] mods;
        
        public Factorial(int max, long mod)
        {
            mods = new long[max + 1];
            mods[0] = 1;
            for (int i = 1; i <= max; i++)
            {
                mods[i] = mods[i - 1] * i % mod;
            }
        }

        public long getFact(int param)
        {
            return mods[param];
        }
    }

}