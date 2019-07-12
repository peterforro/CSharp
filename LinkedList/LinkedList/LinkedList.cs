using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    /// <summary>
    /// Generic doubly linked list data structure implementation
    /// </summary>
    /// <typeparam name="T">Generic parameter</typeparam>
    public class LinkedList<T>
    {
        /// <summary>
        /// Gets, sets the number of the elements contained by the linked list
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// This inner class represents a node / element of the doubly linked list
        /// </summary>
        class Node
        {
            public static int _instanceCounter = 0;

            public T data;
            public Node next;
            public Node prev;
            public int Id;

            /// <summary>
            /// Initializes a new node of the linked list
            /// </summary>
            /// <param name="data">The generic type data to hold by the new node</param>
            public Node(T data)
            {
                this.data = data;
                Id = ++_instanceCounter;
            }
        }

        private Node head;
        private Node tail;

        /// <summary>
        /// Constructor to initialize the linkedList
        /// </summary>
        /// <param name="elements">Arbitary number parameters to initialize the linked list</param>
        public LinkedList(params T[] elements)
        {
            Add(elements);
        }

        /// <summary>
        /// Adds a new element to the linkedlist.
        /// </summary>
        /// <param name="newElement">Generic new element we want to add to the linked list</param>
        public void Add(T newElement)
        {
            var newNode = new Node(newElement);
            if (head == null && tail == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            ++Count;
        }

        /// <summary>
        /// Insert a new element to a specified index
        /// </summary>
        /// <param name="index">The index number to insert the new element</param>
        /// <param name="newElement">Generic new element</param>
        public void Insert(int index, T newElement)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Count == 0 || index >= Count)
            {
                Add(newElement);
            }
            else
            {
                var newNode = new Node(newElement);
                Node front = head, delay = null;
                var idx = 0;
                while (idx != index)
                {
                    delay = front;
                    front = front.next;
                    ++idx;
                }
                delay.next = newNode;
                front.prev = newNode;
                newNode.prev = delay;
                newNode.next = front;
                ++Count;
            }
        }

        /// <summary>
        /// Adds abritary number of new elements to the linkedlist at once. (method overload) 
        /// </summary>
        /// <param name="newElements">Arbitary number of new elements</param>
        public void Add(params T[] newElements)
        {
            foreach (var element in newElements)
            {
                Add(element);
            }
        }

        /// <summary>
        /// Adds every element of a collection that implements the IEnumerbale interface to the linked list
        /// </summary>
        /// <param name="collection">Collection of elements to add to the linked list</param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                Add(element);
            }
        }

        /// <summary>
        /// Returns the string representation of the linkedlist's content. 
        /// </summary>
        /// <returns>A string of the content.</returns>
        public override string ToString()
        {
            var tmp = new T[Count];
            var index = 0;
            for (var iter = head; iter != null; iter = iter.next)
            {
                tmp[index++] = iter.data;
            }
            return String.Join(", ", tmp);
        }


        /// <summary>
        /// Removes an element from the linked list at the specified index given in the argument
        /// </summary>
        /// <param name="index">The index number of the element to remove</param>
        public void Remove(int index)
        {
            if (Count == 0)
            {
                throw new EmptyListException();
            }
            else if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                head = head.next;
                head.prev = null;
            }
            else if (index == Count - 1)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                Node front = head, delay = null;
                int idx = 0;
                while (idx != index)
                {
                    delay = head;
                    front = front.next;
                    ++idx;
                }
                delay.next = front.next;
                front.next.prev = delay;
            }
            --Count;
        }

        /// <summary>
        /// Remove method overload: Removes the specified object from the linked list, given in the argument
        /// </summary>
        /// <param name="element">The specified object we would like to remove from the linked list</param>
        public void Remove(T element)
        {
            if (Count == 0) throw new EmptyListException();
            Node front = head, delay = null;
            while (front != null && !front.data.Equals(element))
            {
                delay = front;
                front = front.next;
            }
            if (front != null && delay == null)
            {
                head = head.next;
                head.prev = null;
            }
            else if (front.next == null && delay != null)
            {
                tail = delay;
                tail.next = null;
            }
            else
            {
                delay.next = front.next;
                front.next.prev = delay;
            }
            --Count;
        }

        /// <summary>
        /// Determines whether the linked list contains the specified object given in the argument.
        /// </summary>
        /// <param name="element">The specified object we are looking for in the linked list</param>
        /// <returns>True if the linked list contains the object and false if not</returns>
        public bool Contains(T element)
        {
            var iter = head;
            while(iter != null)
            {
                if (iter.data.Equals(element))
                {
                    return true;
                }
                iter = iter.next;
            }
            return false;
        }

        /// <summary>
        /// Indexer of the linked list. Returns the object of the linked list on a specified index.
        /// </summary>
        /// <param name="index">speciefied index of the object to return</param>
        /// <returns>The object of the linked list on the specified index</returns>
        public T this[int index] {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                int idx = 0;
                var iter = head;
                while(idx != index)
                {
                    iter = iter.next;
                    ++idx;
                }
                return iter.data;
            }
        }
    }
}
