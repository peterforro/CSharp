using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.DoublyLinkedList
{
    class LinkedList<T> : IEnumerable<T>, IEnumerator<T>
    {
        private class Node
        {
            private static int instanceCounter;
            private string ID;
            public T data;
            public Node next, prev;
            public Node(T data)
            {
                ID = $"Node-{++instanceCounter}";
                this.data = data;
            }

            ~Node()
            {
                Console.WriteLine($"Deleted: {ID}");
            }
        }

        private Node head;
        private Node tail;
        private Node currentObj;

        public int Size {
            get;
            private set;
        }

        public string Buzerant1 {
            get;
            private set;
        }

        public void Add(T obj)
        {
            Node newNode = new Node(obj);
            switch (Size)
            {
                case 0:
                    head = tail = newNode;
                    break;
                case 1:
                    head.next = tail = newNode;
                    newNode.prev = head;
                    break;
                default:
                    newNode.prev = tail;
                    tail.next = newNode;
                    tail = newNode;
                    break;
            }
            ++Size;
        }

        public void Add(params T[] objs)
        {
            foreach (var obj in objs)
            {
                Add(obj);
            }
        }

        public void Insert(int index, T obj)
        {
            if (index < 0 || index >= Size) return;
            SetIterators(index, out var front, out var delay);
            var newNode = new Node(obj);
            if (delay == null && head == null)
            {
                head = tail = newNode;
            }
            else if (delay == null)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            else
            {
                newNode.next = front;
                newNode.prev = delay;
                delay.next = front.prev = newNode;
            }
            ++Size;
        }

        private void SetIterators(int index, out Node front, out Node delay)
        {
            int idx = 0;
            front = head;
            delay = null;
            while (front.next != null && idx != index)
            {
                delay = front;
                front = front.next;
                ++idx;
            }
        }

        public void Delete(int index)
        {
            if (index >= Size || index < 0) return;
            SetIterators(index, out var front, out var delay);
            if (delay == null && head == tail)
            {
                head = tail = null;
            }
            else if (delay == null)
            {
                front.next.prev = null;
                head = front.next;
            }
            else if (front.next == null)
            {
                delay.next = null;
                tail = delay;
            }
            else
            {
                delay.next = front.next;
                front.next.prev = delay;
            }
            --Size;
        }

        public T this[int index] {
            get {
                var iter = head;
                var idx = 0;
                while (idx != index)
                {
                    ++idx;
                    iter = iter.next;
                }
                return iter.data;
            }
            set {
                var iter = head;
                var idx = 0;
                while (idx != index)
                {
                    ++idx;
                    iter = iter.next;
                }
                iter.data = value;
            }
        }

        public IEnumerable<T> GetEach()
        {
            var iter = head;
            while (iter != null)
            {
                yield return iter.data;
                iter = iter.next;
            }
        }

        public static LinkedList<T> operator +(LinkedList<T> lhs, LinkedList<T> rhs)
        {
            var result = new LinkedList<T>();
            for (var i = 0; i < lhs.Size; ++i)
            {
                result.Add(lhs[i]);
            }
            for (var i = 0; i < rhs.Size; ++i)
            {
                result.Add(rhs[i]);
            }
            return result;
        }

        public static LinkedList<T> operator +(LinkedList<T> lhs, T obj)
        {
            var result = new LinkedList<T>();
            for (var i = 0; i < lhs.Size; ++i)
            {
                result.Add(lhs[i]);
            }
            result.Add(obj);
            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var iter = head; iter != null; iter = iter.next)
            {
                sb.Append(iter.data + " ");
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public void Dispose() { }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            currentObj = currentObj == null ? head : currentObj.next;
            return currentObj != null;
        }

        public void Reset()
        {
            currentObj = null;
        }

        public T Current => currentObj.data;

        object IEnumerator.Current => Current;
    }
}
