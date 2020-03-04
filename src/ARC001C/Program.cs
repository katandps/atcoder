using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC001C
{
    class Input
    {
        /// <summary>
        /// 1行の入力を取得する
        /// </summary>
        /// <returns>文字列</returns>
        public string String()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// 複数行の入力を取得
        /// </summary>
        /// <returns>文字列の配列</returns>
        public string[] ArrayString(int rowNumber)
        {
            string[] s = new string[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                s[i] = String();
            }

            return s;
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>int型の値</returns>
        public int Int()
        {
            return int.Parse(String());
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>int型の配列</returns>
        public int[] ArrayInt()
        {
            return Split().Select(int.Parse).ToArray();
        }

        /// <summary>
        /// 複数行の入力を取得
        /// </summary>
        /// <param name="rowNumber">行数</param>
        /// <returns>int型の配列</returns>
        public int[] ArrayInt(int rowNumber)
        {
            int[] ints = new int[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                ints[i] = Int();
            }

            return ints;
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>long型の値</returns>
        public long Long()
        {
            return long.Parse(String());
        }

        /// <summary>
        /// 2つの整数が1行に書かれている入力を、2つのlongで受け取る
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void Longs(ref long A, ref long B)
        {
            var longs = ArrayLong();
            A = longs[0];
            B = longs[1];
        }

        /// <summary>
        /// 3つの整数が1行に書かれている入力を、3つのlongで受け取る
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void Longs(ref long A, ref long B, ref long C)
        {
            var longs = ArrayLong();
            A = longs[0];
            B = longs[1];
            C = longs[2];
        }

        /// <summary>
        /// 4つの整数が1行に書かれている入力を、4つのlongで受け取る
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        public void Longs(ref long A, ref long B, ref long C, ref long D)
        {
            var longs = ArrayLong();
            A = longs[0];
            B = longs[1];
            C = longs[2];
            D = longs[3];
        }

        /// <summary>
        /// 2つの整数が複数行に書かれている入力を、2つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void LongsArray(long rowNumber, ref long[] A, ref long[] B)
        {
            A = new long[rowNumber];
            B = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                var l = ArrayLong();
                A[i] = l[0];
                B[i] = l[1];
            }
        }

        /// <summary>
        /// 3つの整数が複数行に書かれている入力を、2つのlong[]で受け取る
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void LongsArray(long rowNumber, ref long[] A, ref long[] B, ref long[] C)
        {
            A = new long[rowNumber];
            B = new long[rowNumber];
            C = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                var l = ArrayLong();
                A[i] = l[0];
                B[i] = l[1];
                C[i] = l[2];
            }
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>long型の配列</returns>
        public long[] ArrayLong()
        {
            return Split().Select(long.Parse).ToArray();
        }

        public long[] ArrayLong(int rowNumber)
        {
            long[] longs = new long[rowNumber];
            for (int i = 0; i < rowNumber; i++)
            {
                longs[i] = Long();
            }

            return longs;
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の値</returns>
        public double Double()
        {
            return double.Parse(String());
        }

        /// <summary>
        /// 1行の入力を取得
        /// </summary>
        /// <returns>double型の配列</returns>
        public double[] ArrayDouble()
        {
            return Split().Select(double.Parse).ToArray();
        }

        private IEnumerable<string> Split()
        {
            return String().Split(' ');
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver();
            solver.Solve();
        }
    }

    class Solver
    {
        public Solver()
        {
            Input input = new Input();
            C = new bool[8][];
            for (int i = 0; i < 8; i++)
            {
                C[i] = new bool[8];
                var s = input.String();
                for (int j = 0; j < 8; j++)
                {
                    C[i][j] = s[j] == 'Q';
                }
            }
        }

        private bool[][] C;

        public void Solve()
        {
            bool[][] A;
            A = new bool[8][];
            for (int i = 0; i < 8; i++)
            {
                A[i] = new bool[8];
                Array.Copy(C[i], A[i], 8);
            }
            
            if (set(A, 3))
            {
                
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (Ans[i][j])
                        {
                            Console.Write("Q");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No Answer");
            }
        }

        private bool[][] Ans;

        private bool set(bool[][] map, int count)
        {
            if (count == 8)
            {
                Ans = map;
                return mapIsValid(map);
            }

            // 8行
            for (int y = 0; y < 8; y++)
            {
                //ヨコ
                if (map[y].Contains(true))
                {
                    continue;
                }

                bool _break = false;
                // 8列 タテ
                for (int x = 0; x < 8; x++)
                {
                    // ヨコ
                    for (int k = 0; k < 8; k++)
                    {
                        if (map[k][x])
                        {
                            _break = true;
                        }
                    }

                    // ナナメ
                    for (int i = 1; i < 7; i++)
                    {
                        //横軸を決めたとき、(タテの座標±i, ヨコの座標±i)の位置にtrueが入っていた場合配置不可
                        if (x - i >= 0 && y - i >= 0 && map[y - i][x - i])
                        {
                            _break = true;
                            break;
                        }

                        if (x + i <= 7 && y + i <= 7 && map[y + i][x + i])
                        {
                            _break = true;
                            break;
                        }

                        if (x - i >= 0 && y + i <= 7 && map[y + i][x - i])
                        {
                            _break = true;
                            break;
                        }

                        if (x + i <= 7 && y - i >= 0 && map[y - i][x + i])
                        {
                            _break = true;
                            break;
                        }
                    }

                    // 入れられない
                    if (_break)
                    {
                        _break = false;
                        continue;
                    }

                    map[y] = new bool[8];
                    map[y][x] = true;
                    if (set(map, count + 1))
                    {
                        return true;
                    }

                    map[y] = new bool[8];
                }
            }

            return false;
        }

        private bool mapIsValid(bool[][] map)
        {
            for (int y = 0; y < 8; y++)
            {
                // 縦横
                int cx = 0;
                int cy = 0;
                bool crossIsNotValid = false;
                for (int x = 0; x < 8; x++)
                {
                    cx += map[y][x] ? 1 : 0;
                    cy += map[x][y] ? 1 : 0;

                    // ナナメ
                    if (map[y][x])
                    {
                        for (int i = 1; i < 7; i++)
                        {
                            if (x - i >= 0 && y - i >= 0 && map[y - i][x - i])
                            {
                                crossIsNotValid = true;
                                break;
                            }

                            if (x + i <= 7 && y + i <= 7 && map[y + i][x + i])
                            {
                                crossIsNotValid = true;
                                break;
                            }

                            if (x - i >= 0 && y + i <= 7 && map[y + i][x - i])
                            {
                                crossIsNotValid = true;
                                break;
                            }

                            if (x + i <= 7 && y - i >= 0 && map[y - i][x + i])
                            {
                                crossIsNotValid = true;
                                break;
                            }
                        }
                    }
                }

                if (cx > 1 || cx == 0 || cy > 1 || cy == 0 || crossIsNotValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}