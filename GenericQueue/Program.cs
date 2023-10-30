using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class QueueItem<T>
    {
        public QueueItem<T> Next { get; set; }
        public T Value { get; set; }

        public QueueItem(T value, QueueItem<T> next)
        {
            Value = value;
            next.Next = this;
        }
    }

    public class MyQueue<T>
    {
        public QueueItem<T> FirstQueueItem;
        public QueueItem<T> LastQueueItem;
        int count = 0;

        public void Enqueue(T value)
        {
            LastQueueItem = new QueueItem<T>(value, LastQueueItem);

            if (FirstQueueItem == null)
                FirstQueueItem = LastQueueItem;
            count++;
        }

        public T Dequeue()
        {
            if (FirstQueueItem == null)
                return default(T);

            T value = FirstQueueItem.Value;
            FirstQueueItem = FirstQueueItem.Next;

            count--;
            return value;
        }

        public T Peek()
        {
            if (FirstQueueItem == null)
                return default(T);

            return FirstQueueItem.Value;
        }

        public int Count()
        {
            return count;
        }

        public void Clear()
        {
            LastQueueItem = null;
            FirstQueueItem = null;
        }
    }
}
