using System;
using System.Collections.Generic;
using System.Linq;

namespace Libraries
{
    public class Point
    {
        private double X;
        private double Y;

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