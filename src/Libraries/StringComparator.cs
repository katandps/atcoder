using System;
using System.Collections.Generic;

namespace Libraries
{
    /// <summary>
    /// usage; Array.Sort(arr, new StringComparator)
    /// </summary>
    class StringComparator : IComparer<string>
    {
        int IComparer<string>.Compare(string a, string b)
        {
            int length = Math.Min(a.Length, b.Length);
            for (int i = 0; i < length; i++)
            {
                if (a[i] < b[i]) return -1;
                if (a[i] > b[i]) return 1;
            }

            return a.Length - b.Length;
        }
    }
}