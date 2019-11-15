using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC139E
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = CIN.Long();
            long[][] A = new long[N + 1][];
            Dictionary<string, HashSet<string>> condition = new Dictionary<string, HashSet<string>>();
            for (int i = 1; i <= N; i++)
            {
                A[i] = CIN.LongArray();
                for (int j = 1; j < A[i].Length; j++)
                {
                    string game = toStr(A[i][j], i);
                    if (condition.ContainsKey(game))
                    {
                        condition[game].Add(toStr(A[i][j - 1], i));
                    }
                    else
                    {
                        condition.Add(game, new HashSet<string> {toStr(A[i][j - 1], i)});
                    }
                }
            }

            int[] indexes = new int[N + 1];
            HashSet<string> done = new HashSet<string>();

            HashSet<long> turn = new HashSet<long>();
            long games = N * (N - 1) / 2;
            int ans = 0;
            while (done.Count < games)
            {
                bool cannot = true;
                turn = new HashSet<long>();
                for (int i = 1; i <= N; i++)
                {
                    if (indexes[i] == N - 1)
                    {
                        continue;
                    }
                    if (turn.Contains(i) || turn.Contains(A[i][indexes[i]]))
                    {
                        continue;
                    }

                    string game = toStr(i, A[i][indexes[i]]);
                    if (done.Contains(game))
                    {
                        continue;
                    }
                    if (condition.ContainsKey(game))
                    {
                        bool dame = false;

                        List<string> removeList = new List<string>();
                        foreach (string g in condition[game])
                        {
                            if (done.Contains(g))
                            {
                                removeList.Add(g);
                                continue;
                            }
                            dame = true;
                            break;
                        }

                        foreach (string re in removeList)
                        {
                            condition[game].Remove(re);
                        }

                        if (condition[game].Count == 0)
                        {
                            condition.Remove(game);
                        }
                        if (dame)
                        {
                            continue;
                        }
                    }

                    done.Add(game);
                    turn.Add(i);
                    turn.Add(A[i][indexes[i]]);
                    indexes[A[i][indexes[i]]]++;
                    indexes[i]++;
                    cannot = false;
                }

                if (cannot)
                {
                    Console.WriteLine(-1);
                    return;
                }

                ans++;
            }

            Console.WriteLine(ans);
        }

        static string toStr(long A, long B)
        {
            return "" + Math.Min(A, B) + "_" + Math.Max(A, B);
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