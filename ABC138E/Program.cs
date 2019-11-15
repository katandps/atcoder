using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC138E
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine(search(new List<long> {1, 3, 5, 7, 9}, 15));
           
            string s = CIN.String();
            string t = CIN.String();
            
            HashSet<char> ssub = new HashSet<char>();
            // 文字charに対して、Indexの位置を保存しておく 二分探索で取得する
            Dictionary<char, List<int>> map = new Dictionary<char, List<int>>();

            for (char c = 'a'; c <= 'z'; c++)
            {
                map.Add(c, new List<int>());
            }
            
            for (int i = 0; i < s.Length; i++)
            {
                ssub.Add(s[i]);
                map[s[i]].Add(i);
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!ssub.Contains(t[i]))
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            int curIndex = -1;
            long ans = 0;
            for (int i = 0; i < t.Length; i++)
            {
                char curChar = t[i];
                var list = map[curChar];
                var min = search(list, curIndex + 1);
                
                if (min == list.Count)
                {
                    ans += s.Length - curIndex - 1;
                    curIndex = -1;
                    i--;
                    //Console.WriteLine(curChar + " " + min + " :" + ans);
                    continue;
                }
                
                ans += list[min] - curIndex;
                curIndex = list[min];
                //Console.WriteLine(curChar + " " + min + " " + list[min] + " :" + ans);
            }
            Console.WriteLine(ans);
        }

        static int search(List<int> list, long min)
        {
            int lb = -1;
            int ub = list.Count;

            while (ub - lb > 1)
            {
                int mid = (lb + ub) / 2;
                if (list[mid] >= min)
                {
                    ub = mid;
                }
                else
                {
                    lb = mid;
                }
            }
            return ub;
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