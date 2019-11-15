using System;
using System.Collections.Generic;
using System.Linq;

namespace AGC032C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long[] NM = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
            long N = NM[0];
            long M = NM[1];
            
            Edge[] edges = new Edge[M];
            for (int i = 0; i < M; i++)
            {
                long[] e = Console.ReadLine().Split(' ').Select(a => long.Parse(a)).ToArray();
                edges[i] = new Edge(e[0], e[1]);
            }
            
            long[] points = new long[N];
            for (int i = 0; i < M; i++)
            {
                points[edges[i].a - 1]++;
                points[edges[i].b - 1]++;
            }

            List<long> dupPoints = new List<long>();
            for (int i = 0; i < N; i++)
            {
                if (points[i] % 2 != 0)
                {
                    Console.WriteLine("No");
                    return;
                }

                if (points[i] > 2)
                {
                    for (int j = 0; j < (points[i] - 2) / 2; j++)
                    {
                        dupPoints.Add(i);
                    }
                }
            }

            int eulerCircits = 0;
            while (dupPoints.Count > 0)
            {
                long dup = dupPoints[0];
                dupPoints.RemoveAt(0);
                long[] aa = dupPoints.ToArray();
                

                
            }
        }
    }
    
    class Edge
    {
        public long a;
        public long b;
        public Edge(long a, long b)
        {
            this.a = a;
            this.b = b;
        }

        public override bool Equals(object obj)
        {
            //objがnullか、型が違うときは、等価でない
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            //この型が継承できないクラスや構造体であれば、次のようにできる
            //if (!(obj is TestClass))

            //Numberで比較する
            Edge c = (Edge)obj;
            return a == c.a & b == c.b;
        }
    }
}