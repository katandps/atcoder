using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Asakatsu20200324F.Input;

namespace Asakatsu20200324F
{
    static class Input
    {
        private static Func<string, T[]> Cast<T>() => _ => _.Split(' ').Select(Convert<T>()).ToArray();

        private static Func<string, T> Convert<T>()
        {
            Type t = typeof(T);
            if (t == typeof(string)) return _ => (T) (object) _;
            if (t == typeof(int)) return _ => (T) (object) int.Parse(_);
            if (t == typeof(long)) return _ => (T) (object) long.Parse(_);
            if (t == typeof(double)) return _ => (T) (object) double.Parse(_);
            if (t == typeof(string[])) return _ => (T) (object) _.Split(' ');
            if (t == typeof(int[])) return _ => (T) (object) Cast<int>()(_);
            if (t == typeof(long[])) return _ => (T) (object) Cast<long>()(_);
            if (t == typeof(double[])) return _ => (T) (object) Cast<double>()(_);

            throw new NotSupportedException(t + "is not supported.");
        }

        private static T Convert<T>(string s) => Convert<T>()(s);

        private static string String() => Console.ReadLine();

        private static string[] String(long rowNumber) => new bool[rowNumber].Select(_ => String()).ToArray();

        public static void Cin<T>(out T a) => a = Convert<T>(String());

        public static void Cin<T1, T2>(out T1 a1, out T2 a2)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
        }

        public static void Cin<T1, T2, T3>(out T1 a1, out T2 a2, out T3 a3)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
        }

        public static void Cin<T1, T2, T3, T4>(out T1 a1, out T2 a2, out T3 a3, out T4 a4)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
        }

        public static void Cin<T1, T2, T3, T4, T5>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
        }

        public static void Cin<T1, T2, T3, T4, T5, T6>(out T1 a1, out T2 a2, out T3 a3, out T4 a4, out T5 a5, out T6 a6)
        {
            var v = String().Split(' ');
            set(v[0], out a1);
            set(v[1], out a2);
            set(v[2], out a3);
            set(v[3], out a4);
            set(v[4], out a5);
            set(v[5], out a6);
        }

        private static void set<T1>(string s, out T1 o1) => o1 = Convert<T1>(s);

        public static void Cin<T>(long n, out T[] l) => l = String(n).Select(Convert<T>()).ToArray();

        public static void Cin<T1, T2>(long n, out T1[] l1, out T2[] l2)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i]);
        }

        public static void Cin<T1, T2, T3>(long n, out T1[] l1, out T2[] l2, out T3[] l3)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i]);
        }

        public static void Cin<T1, T2, T3, T4>(long n, out T1[] l1, out T2[] l2, out T3[] l3, out T4[] l4)
        {
            l1 = new T1[n];
            l2 = new T2[n];
            l3 = new T3[n];
            l4 = new T4[n];
            for (int i = 0; i < n; i++) Cin(out l1[i], out l2[i], out l3[i], out l4[i]);
        }

        public static void Cin<T>(out T[] a) => a = Convert<T[]>(String());

        public static void Cin<T>(long h, out T[][] map) => map = String(h).Select(Convert<T[]>()).ToArray();
    }

    class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = false};
            Console.SetOut(streamWriter);
            new Solver().Solve();
            Console.Out.Flush();
        }

        public static void Debug()
        {
            new Solver().Solve();
        }
    }

    class Solver
    {
        private int N;
        private double[] x;
        private double[] y;

        public void Solve()
        {
            Cin(out N);
            Cin(N, out x, out y);

            Point[] p = new Point[N];
            for (int i = 0; i < N; i++)
            {
                p[i] = new Point(x[i], y[i]);
            }

            List<Point> kouho = new List<Point>();

            //2点の中間
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    kouho.Add(new Point((p[i].X + p[j].X) / 2, (p[i].Y + p[j].Y) / 2));
                }
            }

            //3点の外心
            for (int i = 0; i < N - 2; i++)
            {
                for (int j = i + 1; j < N - 1; j++)
                {
                    for (int k = i + 2; k < N; k++)
                    {
                        try
                        {
                            kouho.Add(Point.Circumcenter(p[i], p[j], p[k]));
                        }
                        catch
                        {
                        }
                    }
                }
            }

            double min = 4000 * 4000;

            foreach (Point c in kouho)
            {
                double curMin = 0;
                for (int i = 0; i < N; i++)
                {
                    curMin = Math.Max(curMin, (c.X - x[i]) * (c.X - x[i]) + (c.Y - y[i]) * (c.Y - y[i]));
                }

                min = Math.Min(min, curMin);
            }

            Console.WriteLine(Math.Sqrt(min));
        }
    }

    public class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point p, Point q)
        {
            return new Point(p.X + q.X, p.Y + q.Y);
        }

        public static Point operator -(Point p, Point q)
        {
            return new Point(p.X - q.X, p.Y - q.Y);
        }

        public static Point operator *(Point p, double a)
        {
            return new Point(p.X * a, p.Y * a);
        }

        public static Point operator *(double a, Point p)
        {
            return p * a;
        }

        public static Point operator /(Point p, double a)
        {
            return new Point(p.X / a, p.Y / a);
        }

        public static Point operator /(double a, Point p)
        {
            return p / a;
        }

        /// <summary>
        /// 原点を軸に回転させる
        /// </summary>
        /// <param name="ang">ラジアン</param>
        /// <returns>回転後の点</returns>
        public Point Rot(double ang)
        {
            return new Point(Math.Cos(ang) * X - Math.Sin(ang) * Y, Math.Sin(ang) * X + Math.Cos(ang) * Y);
        }

        /// <summary>
        /// 原点を軸にpi/2回転させる
        /// </summary>
        /// <returns>回転後の点</returns>
        public Point Rot90()
        {
            return new Point(-Y, X);
        }

        /// <summary>
        /// X軸に対して反転
        /// </summary>
        /// <returns></returns>
        public Point Conj()
        {
            return new Point(X, -Y);
        }

        /// <summary>
        /// 外積を求める
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns>外積</returns>
        public static double Cross(Point p, Point q)
        {
            return p.X * q.Y - p.Y * q.X;
        }

        /// <summary>
        /// 内積を求める
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns>内積</returns>
        public static double Dot(Point p, Point q)
        {
            return p.X * q.X + p.Y * q.Y;
        }

        /// <summary>
        /// ベクトルのノルム
        /// </summary>
        /// <returns>ノルム</returns>
        public double Norm()
        {
            return Dot(this, this);
        }

        /// <summary>
        /// ベクトルの大きさを求める
        /// </summary>
        /// <returns>大きさ</returns>
        public double Abs()
        {
            return Math.Sqrt(Norm());
        }

        /// <summary>
        /// 3点の外心を求める
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Point Circumcenter(Point p, Point q, Point r)
        {
            Line pq = new Line((p + q) / 2, (p + q) / 2 + (p - q).Rot90());
            Line qr = new Line((q + r) / 2, (q + r) / 2 + (q - r).Rot90());

            return Line.CrossPoint(pq, qr).First();
        }
    }


    public class Line
    {
        private List<Point> Points;

        public Line(Point p, Point q)
        {
            Points = new List<Point>();
            Points.Add(p);
            Points.Add(q);
        }

        public static double Cross(Line l, Line m)
        {
            return Point.Cross(m.Points[1] - m.Points[0], l.Points[1] - l.Points[0]);
        }

        /// <summary>
        /// 2直線の交点を求める
        /// </summary>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <returns>交点のリスト</returns>
        public static List<Point> CrossPoint(Line l, Line m)
        {
            List<Point> res = new List<Point>();

            double d = Cross(l, m);
            if (d < Double.Epsilon)
            {
                return res;
            }

            res.Add(
                l.Points[0] +
                (l.Points[1] - l.Points[0]) *
                Point.Cross(m.Points[1] - m.Points[0], m.Points[1] - l.Points[0]) /
                d
            );
            return res;
        }
    }
}