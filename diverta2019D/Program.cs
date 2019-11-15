using System;
using System.Collections.Generic;
using System.Linq;

namespace diverta2019D
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();

            Dictionary<long, int> soinsuu = new Dictionary<long, int>();
            long temp = N;
            long a = 2;
            double Root = Math.Sqrt(N);
            while (temp > 1)
            {
                if (temp % a == 0)
                {
                    if (soinsuu.ContainsKey(a))
                    {
                        soinsuu[a]++;
                        temp /= a;
                        continue;
                    }

                    soinsuu.Add(a, 1);
                    temp /= a;
                    continue;
                }

                a++;
                if (a > Root)
                {
                    soinsuu.Add(temp, 1);
                    break;
                }
            }

            long flag = 1;
            foreach (KeyValuePair<long, int> sosuu in soinsuu)
            {
                flag *= sosuu.Value + 1;
            }

            Dictionary<long, bool> aa = new Dictionary<long, bool>();
            long ans = 0;
            for (int i = 0; i < flag; i++)
            {
                int l = i;
                long K = 1;
                foreach (var keyValuePair in soinsuu)
                {
                    int ko = l % (keyValuePair.Value + 1);
                    K *= (long) Math.Pow(keyValuePair.Key, ko);
                    l /= keyValuePair.Value + 1;
                }

                if (K > N / K + 1 && !aa.ContainsKey(K))
                {
                    aa.Add(K, true);
                    ans += K - 1;
                }
            }

            Console.WriteLine(ans);
        }
    }

    internal static class CIN
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int[] IntArray()
        {
            return Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(Console.ReadLine());
        }

        public static long[] LongArray()
        {
            return Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
        }

        public static double[] DoubleArray()
        {
            return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        }
    }
}