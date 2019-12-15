using System;
using System.Collections.Generic;
using System.Linq;

namespace PAST001E
{
    class Program
    {
        static void Main(string[] args)
        {
            var nq = Cin.LArr();
            string[] S = new string[nq[1]];
            for (int i = 0; i < nq[1]; i++)
            {
                S[i] = Cin.String();
            }

            var solver = new Solver(nq[0], S);
            solver.Solve();
        }
    }

    class Solver
    {
        private long N;
        private string[] S;

        public Solver(long n, string[] s)
        {
            N = n;
            S = s;
        }

        public IConvertible Solve()
        {
            bool[][] follow = new bool[N + 1][];
            for (int i = 0; i < N + 1; i++)
            {
                follow[i] = new bool[N + 1];
            }

            foreach (string query in S)
            {
                var q = query.Split(' ').Select(int.Parse).ToArray();
                if (q[0] == 1)
                {
                    follow[q[1]][q[2]] = true;
                }
                else if (q[0] == 2)
                {
                    var a = q[1];
                    for (int i = 1; i <= N; i++)
                    {
                        if (follow[i][a])
                        {
                            follow[a][i] = true;
                        }
                    }
                }
                else if (q[0] == 3)
                {
                    var a = q[1];
                    List<long> add = new List<long>();
                    for (int i = 1; i <= N; i++)
                    {
                        if (!follow[a][i])
                        {
                            continue;
                        }

                        var b = i;
                        for (int j = 1; j <= N; j++)
                        {
                            if (follow[b][j])
                            {
                               // Console.WriteLine("" + a + " " + b + " " + j);
                                add.Add(j);
                            }
                        }
                    }

                    foreach (long f in add)
                    {
                        follow[a][f] = true;
                    }
                }

                //rite(follow);
                //onsole.WriteLine("");
            }

            for (int i = 0; i <= N; i++)
            {
                follow[i][i] = false;
            }

            Write(follow);
            return 0;
        }

        private void Write(bool[][] f)
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    Console.Write(f[i][j] ? "Y" : "N");
                }

                Console.WriteLine("");
            }
        }
    }

    internal static class Cin
    {
        public static string String()
        {
            return Console.ReadLine();
        }

        public static int Int()
        {
            return int.Parse(String());
        }

        public static int[] IArr()
        {
            return Split().Select(int.Parse).ToArray();
        }

        public static long Long()
        {
            return long.Parse(String());
        }

        public static long[] LArr()
        {
            return Split().Select(long.Parse).ToArray();
        }

        public static double Double()
        {
            return double.Parse(String());
        }

        public static double[] DArr()
        {
            return Split().Select(double.Parse).ToArray();
        }

        private static IEnumerable<String> Split()
        {
            return String().Split(' ');
        }
    }
}