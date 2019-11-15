using System;
using System.Collections.Generic;
using System.Linq;

namespace AGC034B
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = CIN.String();
            List<char> I = new List<char>();

            bool B = false;
            for (int i = 0; i < S.Length; i++)
            {
                if (B)
                {
                    if (S[i] == 'C')
                    {
                        B = false;
                        I.Add('B');
                        continue;
                    }

                    if (S[i] == 'A')
                    {
                        B = false;
                        I.Add('X');
                        I.Add('A');
                        continue;
                    }

                    if (S[i] == 'B')
                    {
                        I.Add('X');
                        continue;
                    }
                }

                if (S[i] == 'B')
                {
                    B = true;
                    continue;
                }

                if (S[i] == 'A')
                {
                    I.Add('A');
                    continue;
                }

                if (S[i] == 'C')
                {
                    I.Add('X');
                }
            }

            var II = I.ToArray();

            long ans = 0;
            int curA = 0;
            for (int i = 0; i < II.Count(); i++)
            {
                if (II[i] == 'A')
                {
                    curA++;
                    continue;
                }

                if (II[i] == 'B')
                {
                    ans += curA;
                    continue;
                }

                if (II[i] == 'X')
                {
                    curA = 0;
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