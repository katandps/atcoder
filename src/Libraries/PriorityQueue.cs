using System;
using System.Collections;
using System.Collections.Generic;

namespace Libraries
{
    public class PriorityQueue<T> : IEnumerable<T>
    {
        private readonly List<T> data = new List<T>();
        private readonly IComparer<T> comparer;
        private readonly bool isDescending;

        public PriorityQueue(IComparer<T> comparer, bool isDescending = true)
        {
            this.comparer = comparer;
            this.isDescending = isDescending;
        }

        public PriorityQueue(Comparison<T> comparison, bool isDescending = true)
            : this(Comparer<T>.Create(comparison), isDescending)
        {
        }

        public PriorityQueue(bool isDescending = true)
            : this(Comparer<T>.Default, isDescending)
        {
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            var childIndex = data.Count - 1;
            while (childIndex > 0)
            {
                var parentIndex = (childIndex - 1) / 2;
                if (Compare(data[childIndex], data[parentIndex]) >= 0) break;
                Swap(childIndex,parentIndex);
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (Count < 1)
            {
                throw new Exception("キューに値が入っていません");
            }
            
            var lastIndex = data.Count - 1;
            var firstItem = data[0];
            data[0] = data[lastIndex];
            data.RemoveAt(lastIndex);
            lastIndex--;

            var parentIndex = 0;
            while (true)
            {
                var childIndex = parentIndex * 2 + 1;
                if (childIndex > lastIndex)
                {
                    break;
                }

                var rightChild = childIndex + 1;
                if (rightChild <= lastIndex && Compare(data[rightChild], data[childIndex]) < 0)
                {
                    childIndex = rightChild;
                }

                if (Compare(data[parentIndex], data[childIndex]) <= 0)
                {
                    break;
                }
                Swap(parentIndex, childIndex);
                parentIndex = childIndex;
            }
            
            return firstItem;
        }

        public T Peek()
        {
            return data[0];
        }

        private void Swap(int a, int b)
        {
            var tmp = data[a];
            data[a] = data[b];
            data[b] = tmp;
        }

        private int Compare(T a, T b)
        {
            return isDescending ? comparer.Compare(b, a) : comparer.Compare(a, b);
        }

        public int Count => data.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}