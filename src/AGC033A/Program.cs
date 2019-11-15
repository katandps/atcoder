using System;
using System.Collections.Generic;
using System.Linq;

namespace AGC033A
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] HW = CIN.IntArray();
            var H = HW[0];
            var W = HW[1];
            string[] A = new string[H];
            for (int i = 0; i < H; i++)
            {
                A[i] = CIN.String();
            }
            List<Black> queue = new List<Black>();
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (A[i][j] == '#')
                    {
                        queue.Add(new Black(j, i, 0));
                    }
                }
            }

            int[][] data = new int[HW[0]][];
            for (int i = 0; i < HW[0]; i++)
            {
                data[i] = new int[HW[1]];
                for (int j = 0; j < HW[1]; j++)
                {
                    data[i][j] = A[i][j] == '.' ? -1 : 0;
                }
            }
            long deepest = 0;
            while (queue.Count > 0)
            {
                Black pop = queue.First();
                queue.Remove(pop);

                foreach (Black variable in pop.N(H, W))
                {
                    if (variable.isNew(data))
                    {
                        data[variable.Y][variable.X] = variable.Deep;
                        deepest = Math.Max(deepest, variable.Deep);
                        queue.Add(variable);
                    }
                }
            }
            
            Console.WriteLine(deepest);
        }
    }

    class Black
    {
        public int X;
        public int Y;
        public int Deep;

        public Black(int X, int Y, int Deep)
        {
            this.X = X;
            this.Y = Y;
            this.Deep = Deep;
        }

        public Black[] N(int H, int W)
        {
            List<Black> b = new List<Black>();
            if (X > 0)
            {
                b.Add(new Black(X - 1, Y, Deep + 1));
            }

            if (X < W - 1)
            {
                b.Add(new Black(X + 1, Y, Deep + 1));
            }

            if (Y > 0)
            {
                b.Add(new Black(X, Y - 1, Deep + 1));
            }

            if (Y < H - 1)
            {
                b.Add(new Black(X, Y + 1, Deep + 1));
            }

            return b.ToArray();
        }

        public bool isNew(int[][] Data)
        {
            return Data[Y][X] == -1;// | Data[Y][X] > Deep;
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
