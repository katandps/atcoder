using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC136D
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = CIN.String();

            List<Pair> L = new List<Pair>();

            bool RMode = true;
            int start = 0;
            int rl = -1;
            for (int i = 0; i < S.Length; i++)
            {
                if (RMode && S[i] == 'L')
                {
                    rl = i - 1;
                    RMode = false;
                }
                else if (!RMode && S[i] == 'R')
                {
                    RMode = true;
                    L.Add(new Pair(start, i - 1, rl));
                    start = i;
                    rl = -1;
                }
            }

            L.Add(new Pair(start, S.Length - 1, rl));

            foreach (Pair pair in L)
            {
                for (long i = pair.L; i <= pair.R; i++)
                {
                    if (i == pair.RL)
                    {
                        long A = pair.R - pair.L + 1;
                        if (A % 2 == 0)
                        {
                            A = A / 2;
                        }
                        else
                        {
                            if (pair.R % 2 == pair.RL % 2)
                            {
                                A = A / 2 + 1;
                            }
                            else
                            {
                                A = A / 2;
                            }
                        }
                                 
                        Console.Write("" + A + " ");
                        continue;
                    }

                    if (i == pair.RL + 1)
                    {
                        long A = pair.R - pair.L + 1;
                        if (A % 2 == 0)
                        {
                            A = A / 2;
                        }
                        else
                        {
                            if (pair.R % 2 == pair.RL % 2)
                            {
                                A = A / 2;
                            }
                            else
                            {
                                A = A / 2 + 1;
                            }
                        }
                        Console.Write("" + A + " ");
                        continue;
                    }
                    
                    Console.Write("0 ");
                }
            }

            Console.WriteLine("");
        }
    }

    class Pair
    {
        public long L;
        public long R;
        public long RL;

        public Pair(long l, long r, long rl)
        {
            L = l;
            R = r;
            RL = rl;
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