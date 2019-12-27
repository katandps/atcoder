using NUnit.Framework;
using Libraries;

namespace LibraryTest
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            PriorityQueue<long> pq = new PriorityQueue<long>();
            pq.Enqueue(3);
            pq.Enqueue(2);
            pq.Enqueue(5);
            pq.Enqueue(1);
            pq.Enqueue(4);

            Assert.AreEqual(5, pq.Dequeue());
            Assert.AreEqual(4, pq.Dequeue());
            Assert.AreEqual(3, pq.Dequeue());
            Assert.AreEqual(2, pq.Dequeue());
            Assert.AreEqual(1, pq.Dequeue());
            
            pq.Enqueue(4);
            pq.Enqueue(4);
            pq.Enqueue(5);

            Assert.AreEqual(5, pq.Dequeue());
            
            pq.Enqueue(6);
            pq.Enqueue(5);
            pq.Enqueue(6);
            
            Assert.AreEqual(6, pq.Dequeue());
            Assert.AreEqual(6, pq.Dequeue());
            Assert.AreEqual(5, pq.Dequeue());
            Assert.AreEqual(4, pq.Dequeue());
            Assert.AreEqual(4, pq.Dequeue());
        }
    }
}