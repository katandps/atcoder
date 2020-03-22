using System.Collections.Generic;

namespace Libraries
{
    /// <summary>
    /// 順列を生成する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Permutation<T>
    {
        public Permutation(List<T> list)
        {
            Permutate(list);
        }

        public List<List<T>> permutation = new List<List<T>>();

        private void Permutate(List<T> rest, List<T> current = null)
        {
            if (current == null) current = new List<T>();

            foreach (var l in rest)
            {
                var next = new List<T>();
                foreach (T v in current)
                {
                    next.Add(v);
                }

                next.Add(l);

                if (rest.Count == 1)
                {
                    permutation.Add(next);
                    continue;
                }

                var nextRest = new List<T>();
                foreach (T r in rest)
                {
                    if (r.Equals(l)) continue;
                    nextRest.Add(r);
                }

                Permutate(nextRest, next);
            }
        }
    }

    public class StringPermutation
    {
        public StringPermutation(string s)
        {
            Permutate(s);
        }

        public List<string> permutation = new List<string>();
        HashSet<string> memo = new HashSet<string>();

        private void Permutate(string rest, string current = null)
        {
            if (current == null)
            {
                current = "";
            }

            foreach (char c in rest)
            {
                var next = "";
                foreach (char v in current)
                {
                    next += v;
                }

                next += c;

                if (memo.Contains(next)) continue;
                memo.Add(next);

                if (rest.Length == 1)
                {
                    permutation.Add(next);
                    continue;
                }

                var nextRest = new List<char>();
                foreach (char r in rest)
                {
                    if (r.Equals(r)) continue;
                    nextRest.Add(r);
                }

                Permutate(new string(nextRest.ToArray()), next);
            }
        }
    }
}