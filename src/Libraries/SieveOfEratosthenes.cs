using System.Collections.Generic;

namespace Libraries
{
    public class SieveOfEratosthenes
    {
        /// m以下の素数を列挙する
        HashSet<long> Primes(long m)
        {
            HashSet<long> l = new HashSet<long>();
            bool[] b = new bool[m + 1];
            b[0] = true;
            b[1] = true;
            for (int i = 2; i < m; i++)
            {
                for (int j = 2; i * j <= m; j++)
                {
                    b[i * j] = true;
                }
            }

            for (int i = 2; i <= m; i++)
            {
                if (!b[i])
                {
                    l.Add(i);
                }
            }

            return l;
        }
    }
}