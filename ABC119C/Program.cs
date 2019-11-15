using System;
using System.Linq;

namespace ABC119C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] NABC = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
            int N = NABC[0];
            int A = NABC[1];
            int B = NABC[2];
            int C = NABC[3];

            int[] L = new int[8];
            for (int i = 0; i < N; i++)
            {
                L[i] = int.Parse(Console.ReadLine());
            }

            int[] ABC = {A, B, C};
            Array.Sort(ABC);
            Console.WriteLine(calc(L, ABC, N));
        }


        private static int calc(int[] L, int[] ABC, int N)
        {
            int MP = int.MaxValue;
            int[] bs = new int[4];
            int[] loop = new int[8];
            for (loop[0] = 0; loop[0] < 4; loop[0]++)
            {
                for (loop[1] = 0; loop[1] < 4; loop[1]++)
                {
                    for (loop[2] = 0; loop[2] < 4; loop[2]++)
                    {
                        for (loop[3] = 0; loop[3] < 4; loop[3]++)
                        {
                            for (loop[4] = 0; loop[4] < 4; loop[4]++)
                            {
                                for (loop[5] = 0; loop[5] < 4; loop[5]++)
                                {
                                    for (loop[6] = 0; loop[6] < 4; loop[6]++)
                                    {
                                        for (loop[7] = 0; loop[7] < 4; loop[7]++)
                                        {
                                            int four = 0;
                                            for (int i = 0; i < N; i++)
                                            {
                                                if (loop[i] == 3)
                                                {
                                                    four++;
                                                }

                                                bs[loop[i]] += L[i];
                                            }
                                            if (bs[0] == 0 | bs[1] == 0 | bs[2] == 0)
                                            {
                                                bs = new int[4];
                                                continue;
                                            }
                                            int[] bbs = {bs[0], bs[1], bs[2]};
                                            bs = new int[4];
                                            Array.Sort(bbs);
                                            int curScore =
                                                Math.Abs(bbs[0] - ABC[0]) + Math.Abs(bbs[1] - ABC[1]) +
                                                Math.Abs(bbs[2] - ABC[2]) + (N - 3 - four) * 10;
                                            MP = Math.Min(curScore, MP);
                                        } 
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return MP;
        }
    }
}