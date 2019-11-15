using System;

namespace ABC054C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = input[0];
            var m = input[1];

            var matrix = new bool[n][];
            for (var i = 0; i < n; i++)
            {
                var p = new bool[n];
                matrix[i] = p;
            }

            for (var i = 0; i < m; i++)
            {
                var line = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                matrix[line[0]][line[1]] = true;
            }

            var solver = new Solver();
            Console.WriteLine(solver.Solve(matrix));
        }
    }

    public class Solver
    {
        public int Solve(bool[][] matrix)
        {
            var cur = 1;
            var history = new int[8];
            return n(cur, matrix, history);
            var patterns = matrix[1];
            for (var i = 0; i < patterns.Length; i++)
            {
            }
        }

        private int n(int cur, bool[][] matrix, int[] history)
        {
            return 1;
        }
    }
}