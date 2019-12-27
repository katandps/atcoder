using System;

namespace Libraries
{
    /// <summary>
    /// めぐる式二分探索
    /// 性質上、実装を部分的にコピーして使う
    /// 
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// 二分探索
        /// </summary>
        /// <returns>条件を満たす最小の値</returns>
        long Search()
        {
            long ng = -1;
            long ok = Int32.MaxValue;

            while (Math.Abs(ok - ng) > 1)
            {
                long mid = (ok + ng) / 2;
                if (IsOK(mid)) ok = mid;
                else ng = mid;
            }

            return ok;
        }

        bool IsOK(long key)
        {
            return true;
        }
    }
}