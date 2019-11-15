using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC103A
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = Input.Long();
            var V = Input.LongArray();

            var even = new long[N / 2];
            var odd = new long[N / 2];
            for (var i = 0; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    even[i / 2] = V[i];
                    continue;
                }

                odd[i / 2] = V[i];
            }

            Array.Sort(odd);
            Array.Sort(even);

            var oddCount = new Dictionary<long, int>();
            for (var i = 0; i < N / 2; i++)
            {
                if (oddCount.ContainsKey(odd[i]))
                {
                    oddCount[odd[i]]++;
                    continue;
                }

                oddCount.Add(odd[i], 1);
            }

            var evenCount = new Dictionary<long, int>();
            for (var i = 0; i < N / 2; i++)
            {
                if (evenCount.ContainsKey(even[i]))
                {
                    evenCount[even[i]]++;
                    continue;
                }

                evenCount.Add(even[i], 1);
            }

            var evenMaxKey = evenCount.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            var oddMaxKey = oddCount.OrderByDescending(x => x.Value).FirstOrDefault().Key;

            if (evenMaxKey != oddMaxKey)
            {
                Console.WriteLine(N - evenCount[evenMaxKey] - oddCount[oddMaxKey]);
                return;
            }

            long evenMaxValue = evenCount[evenMaxKey];
            long oddMaxValue = oddCount[oddMaxKey];

            evenCount.Remove(evenMaxKey);
            oddCount.Remove(oddMaxKey);

            long evenNextValue = 0;
            long oddNextValue = 0;
            if (evenCount.Count != 0)
                evenNextValue = evenCount[evenCount.OrderByDescending(x => x.Value).FirstOrDefault().Key];

            if (oddCount.Count != 0)
                oddNextValue = oddCount[oddCount.OrderByDescending(x => x.Value).FirstOrDefault().Key];

            Console.WriteLine(N - Math.Max(evenMaxValue + oddNextValue, evenNextValue + oddMaxValue));
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