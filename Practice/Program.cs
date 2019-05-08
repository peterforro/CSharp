using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice {
    class Program {
        static void Main(string[] args) {
            var list = new DoublyLinkedList<int>() {1, 2, 3, 4};
            for (int i = 0; i < list.Count; ++i) {
                list[i] = 100 + i;
                //Console.WriteLine(list[i]);
            }

            foreach (var element in list) {
                Console.WriteLine(element);
            }
            Console.ReadKey();

        }
    }




    class DoublyLinkedList<T> : IList<T>, IEnumerator<T> {


        class Node {
            public T data;
            public Node next, prev;
            public Node(T data) {
                this.data = data;
            }
        }


        private Node head;
        private Node tail;
        private Node currentObj;


        public IEnumerator<T> GetEnumerator() {
            return this;
        }


        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Add(T data) {
            var newNode = new Node(data);
            if (head == null && tail == null) {
                head = tail = newNode;
            } else {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            ++Count;
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public bool Contains(T item) {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public bool Remove(T item) {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; }
        public int IndexOf(T item) {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item) {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index) {
            throw new NotImplementedException();
        }

        public T this[int index] {
            get {
                if (index >= 0 && index < Count) {
                    int idx = 0;
                    var iter = this.GetEnumerator();
                    while (iter.MoveNext()) {
                        if (idx == index) {
                            return Current;
                        }
                        ++idx;
                    }
                }
                return head.data;
            }
            set {
                if (index >= 0 && index < Count) {
                    int idx = 0;
                    var iter = this.GetEnumerator();
                    while (iter.MoveNext()) {
                        if (idx == index) {
                            currentObj.data = value;
                        }
                        ++idx;
                    }
                }
            }
        }

        public void Dispose() { }

        public bool MoveNext() {
            currentObj = currentObj == null ? head : currentObj.next;
            return currentObj != null;
        }

        public void Reset() {
            currentObj = null;
        }

        public T Current => currentObj.data;

        object IEnumerator.Current => Current;


        public override string ToString() {
            var sb = new StringBuilder();
            Node iter = head;
            while (iter != null) {
                sb.Append(iter.data + " ");
                iter = iter.next;
            }
            return sb.ToString();
        }
    }





}
