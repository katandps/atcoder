using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC110C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var S = Input.String();
            var T = Input.String();

            var map = new Dictionary<char, char>();
            var map2 = new Dictionary<char, char>();

            for (var i = 0; i < S.Length; i++)
            {
                if (map.ContainsKey(S[i]))
                {
                    if (T[i] != map[S[i]])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                else
                {
                    map.Add(S[i], T[i]);
                }

                if (map2.ContainsKey(T[i]))
                {
                    if (S[i] != map2[T[i]])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
                else
                {
                    map2.Add(T[i], S[i]);
                }
            }

            Console.WriteLine("Yes");
        }
    }


    internal static class Input
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