using System;

namespace ABC100D
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ints = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = ints[0];
            var m = ints[1];

            var cakes = new Cake[n];
            for (var i = 0; i < n; i++)
            {
                var line = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                cakes[i] = new Cake(line[0], line[1], line[2]);
            }


            long score = 0;
            for (var xt = -1; xt < 2; xt += 2)
            for (var yt = -1; yt < 2; yt += 2)
            for (var zt = -1; zt < 2; zt += 2)
            {
                var scores = new Score[m + 1];
                scores[0] = new Score(0, 0, 0);
                for (var i = 0; i < n; i++)
                for (var j = m; j > 0; j--)
                {
                    if (scores[j - 1] == null) continue;

                    if (scores[j] == null)
                    {
                        scores[j] = scores[j - 1].Add(cakes[i]);
                        continue;
                    }

                    if (scores[j - 1].Add(cakes[i]).Calc(xt, yt, zt) > scores[j].Calc(xt, yt, zt))
                        scores[j] = scores[j - 1].Add(cakes[i]);
                }

                score = Math.Max(score, scores[m].Calc(xt, yt, zt));
            }

            Console.WriteLine(score);
        }
    }

    internal class Cake
    {
        public long X;
        public long Y;
        public long Z;

        public Cake(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    internal class Score
    {
        public long X;
        public long Y;
        public long Z;

        public Score(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Score Add(Cake cake)
        {
            return new Score(X + cake.X, Y + cake.Y, Z + cake.Z);
        }

        public long Calc(int xt, int yt, int zt)
        {
            return X * xt + Y * yt + Z * zt;
        }
    }
}