using System;
using System.Collections.Generic;
using System.Linq;

namespace Libraries
{
    public class WarshallFloyd
    {
        public static long INF = Int32.MaxValue;
        public long[][] ArriveCost;

        /// <summary>
        /// ワーシャルフロイド法で頂点間最短経路を求める
        /// </summary>
        /// <param name="V">頂点の数</param>
        /// <param name="K">辺の数</param>
        /// <param name="A">経路の始点</param>
        /// <param name="B">経路の終点</param>
        /// <param name="C">経路のコスト</param>
        public WarshallFloyd(long V, long K, List<long> A, List<long> B, List<long> C)
        {
            ArriveCost = Enumerable.Repeat(0, (int) V).Select(_ => Enumerable.Repeat(INF, (int) V).ToArray())
                .ToArray();
            for (int i = 0; i < V; i++)
            {
                ArriveCost[i][i] = 0;
            }

            for (int i = 0; i < K; i++)
            {
                ArriveCost[A[i]][B[i]] = Math.Min(ArriveCost[A[i]][B[i]], C[i]);
            }

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    for (int k = 0; k < V; k++)
                    {
                        ArriveCost[j][k] = Math.Min(ArriveCost[j][k], ArriveCost[j][i] + ArriveCost[i][k]);
                    }
                }
            }
        }
    }
}