using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static ABC114D.Input;

namespace ABC114D
{
    static class Input
    {
        private static Func<string, T[]> Cast<T>() => _ => _.Split(' ').Select(Convert<T>()).ToArray();

        private static Func<string, T> Convert<T>()
        {
            Type t = typeof(T);
            if (t == typeof(string)) return _ => (T) (object) _;
            if (t == typeof(int)) return _ => (T) (object) int.Parse(_);
            if (t == typeof(long)) return _ => (T) (object) long.Parse(_);
            if (t == typeof(double)) return _ => (T) (object) double.Parse(_);
            if (t == typeof(string[])) return _ => (T) (object) Cast<string>()(_);
            if (t == typeof(int[])) return _ => (T) (object) Cast<int>()(_);
            if (t == typeof(long[])) return _ => (T) (object) Cast<long>()(_);
            if (t == typeof(double[])) return _ => (T) (object) Cast<double>()(_);

            throw new NotSupportedException(t + "is not supported.");
        }

        private static T Convert<T>(string s) => Convert<T>()(s);

        private static string String() => Console.ReadLine();

        private static string[] String(long rowNumber) => new bool[rowNumber].Select(_ => String()).ToArray();

        public static void Cin<T>(out T a) => a = Convert<T>(String());

        public static void Cin<T1, T2>(out T1 a1, out T2 a2)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
        }

        public static void Cin<T1, T2, T3>(out T1 a1, out T2 a2, out T3 a3)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
        }

        public static void Cin<T1, T2, T3, T4>(out T1 a1, out T2 a2, out T3 a3, out T4 a4)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
        }

        public static void Cin<T1, T2, T3, T4, T5>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
        }

        public static void Cin<T1, T2, T3, T4, T5, T6>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5, out T6 a6)
        {
            var v = Convert<string[]>(String());
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
            set(v[5], out a6);
        }

        private static void set<T1>(string s, out T1 o1) => o1 = Convert<T1>(s);

        public static void Cin<T>(long n, out T[] l) => l = String(n).Select(Convert<T>()).ToArray();

        public static void Cin<T1, T2>(long n, out T1[] l1, out T2[] l2)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i]);
        }

        public static void Cin<T1, T2, T3>(long n, out T1[] l1, out T2[] l2, out T3[] l3)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i]);
        }

        public static void Cin<T1, T2, T3, T4>(long n, out T1[] l1, out T2[] l2, out T3[] l3, out T4[] l4)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            l4 = new T4[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i], out l4[i]);
        }

        public static void Cin<T>(out T[] a) => a = Convert<T[]>(String());

        public static void Cin<T>(long h, out T[][] map) => map = String(h).Select(Convert<T[]>()).ToArray();
    }

    class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            Console.SetOut(streamWriter);
            new Solver().Solve();
            Console.Out.Flush();
        }

        public static void Debug()
        {
            new Solver().Solve();
        }
    }

    class Solver
    {
        private int N;

        public void Solve()
        {
            Cin(out N);
            Dictionary<int, int> divisors = new Dictionary<int, int>();
            foreach (long p in Primes(100))
            {
                divisors.Add((int) p, 0);
            }

            for (int i = 1; i <= N; i++)
            {
                var t = i;
                var j = 2;
                while (t > 1)
                {
                    if (t % j == 0)
                    {
                        divisors[j]++;
                        t /= j;
                        continue;
                    }

                    j++;
                }
            }

            int ans = 0;
            List<int> cnt = new List<int>();
            foreach (KeyValuePair<int, int> i in divisors)
            {
                cnt.Add(i.Value);
            }

            //一つだけ選ぶ
            for (int i = 0; i < cnt.Count; i++)
            {
                if (cnt[i] >= 74) ans++;
            }

            //二つ選ぶ
            for (int i = 0; i < cnt.Count; i++)
            {
                for (int j = i + 1; j < cnt.Count; j++)
                {
                    for (int n = 2; n <= cnt[i]; n++)
                    {
                        for (int m = 2; m <= cnt[j]; m++)
                        {
                            if ((n + 1) * (m + 1) == 75) ans++;
                        }
                    }
                }
            }

            //３つ
            for (int i = 0; i < cnt.Count; i++)
            {
                for (int j = i + 1; j < cnt.Count; j++)
                {
                    for (int k = j + 1; k < cnt.Count; k++)
                    {
                        for (int n = 2; n <= cnt[i]; n++)
                        {
                            for (int m = 2; m <= cnt[j]; m++)
                            {
                                for (int l = 2; l <= cnt[k]; l++)
                                {
                                    if ((n + 1) * (m + 1) * (l + 1) == 75) ans++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(ans);
        }

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