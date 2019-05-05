using System;
using System.Diagnostics.Eventing.Reader;
using System.Text;



namespace LinkedList.DoublyLinkedList {


    class LinkedList<T> {

        class Node {
            private static int instanceCounter;
            private string ID;
            public T data;
            public Node next, prev;
            public Node(T data) {
                ID = $"Node-{++instanceCounter}";
                this.data = data;
            }

            ~Node() {
                Console.WriteLine($"Deleted: {ID}");
            }
        }


        private Node head;
        private Node tail;


        public int Size {
            get;
            private set;
        }


        public void Add(T obj) {
            Node newNode = new Node(obj);
            if (head == null && tail == null) {
                head = tail = newNode;
            } else if (head == tail && head != null && tail != null) {
                head.next = tail = newNode;
                newNode.prev = head;
            } else {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            ++Size;
        }


        public void Insert(int index, T obj) {
            if (index < 0) return;
            if (Size == 0 || index > Size - 1) {
                Add(obj);
                return;
            }
            Node newNode = new Node(obj);
            if (index == Size - 1) {
                newNode.next = tail;
                newNode.prev = tail.prev;
                tail.prev.next = newNode;
                tail.prev = newNode;
            } else if(index == 0 && Size > 0) {
                newNode.next = head;
                head = newNode;
            } else {
                Node iter = head;
                for (int idx = 0; idx != index; ++idx, iter = iter.next);
                newNode.next = iter;
                newNode.prev = iter.prev;
                iter.prev.next = iter.prev = newNode;
            }
            ++Size;
        }


        public void Delete(int index) {
            if (index < 0 || index >= Size) return;
            if (Size == 1) {
                head = tail = null;
            } else if (index == 0) {
                head.next.prev = null;
                head = head.next;
            } else if (index == Size - 1) {
                tail.prev.next = null;
                tail = tail.prev;
            }
            else {
                Node iter = head;
                int idx = 0;
                while (iter.next != null && idx != index) {
                    iter = iter.next;
                    ++idx;
                }
                iter.prev.next = iter.next;
                iter.next.prev = iter.prev;
            }
            --Size;
            GC.Collect();
        }


        public void Add(params T[] objs) {
            foreach (var obj in objs) {
                Add(obj);
            }
        }


        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (Node iter = head; iter != null; iter = iter.next) {
                sb.Append(iter.data.ToString() + " ");
            }
            return sb.ToString();
        }
    }
}
