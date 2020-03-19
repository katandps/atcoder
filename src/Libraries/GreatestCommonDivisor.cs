namespace Libraries
{
    /// <summary>
    /// 最大公約数
    /// </summary>
    public class GreatestCommonDivisor
    {
        public static long Gcd(long a, long b)
        {
            if (a < b)
                // 引数を入替えて自分を呼び出す
                return Gcd(b, a);
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }
    }
}