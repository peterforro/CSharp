using System;
using System.Linq;

namespace StackCollection
{
    /// <summary>
    /// Generic Implementation of the Stack (LIFO) Collection.    
    /// </summary>
    /// <typeparam name="T">Generic Parameter for the specific instantiation</typeparam>
    public class Stack<T>
    {
        private T[] data;

        /// <summary>
        /// Sets or gets the size (capacity) of the stack. The setter is private
        /// </summary>
        public int Capacity {
            private set;
            get;
        }

        /// <summary>
        /// Sets or gets the number of the elements contained by the stack. The setter is private. 
        /// </summary>
        public int Count {
            private set;
            get;
        }

        /// <summary>
        /// Constructor of the Stack class. It initializes a default size to the inner storage.
        /// </summary>
        /// <param name="capacity">Initial size of the Stack, its default value is 10</param>
        public Stack(int capacity = 10)
        {
            this.Capacity = capacity;
            data = new T[capacity];
        }

        /// <summary>
        /// Pushes the data given in the argument to the top of the collection
        /// </summary>
        /// <param name="data">data to be added to the stack</param>
        public void Push(T data)
        {
            if (Count == Capacity)
            {
                AugmentCapacity();
            }
            this.data[Count++] = data;
        }

        /// <summary>
        /// If the Number of the elements reaches the capacity of the stack, this method will be called to augment the capacity with 10, and it copies the original
        /// content to the new, augmented size stack.
        /// </summary>
        private void AugmentCapacity()
        {
            Capacity += 10;
            var tmp = new T[Capacity];
            Array.Copy(data, tmp, Count);
            data = tmp;
        }

        /// <summary>
        /// Gets the Last element of the stack. (Stack - Last in First Out)
        /// </summary>
        /// <returns>Removes and returns the last element from the stack.</returns>
        public T Pop()
        {
            var lastElement = data[Count - 1];
            data[--Count] = default(T);
            return lastElement;
        }

        /// <summary>
        /// Show the last element of the stack, without removing it.
        /// </summary>
        /// <returns>The last element of the stack</returns>
        public T Peek()
        {
            return data[Count - 1];
        }


        /// <summary>
        /// Override of the ToString method (inherited from the object class)
        /// </summary>
        /// <returns>returns the string representation of the stack. The latest element is on the top of the string.</returns>
        public override string ToString()
        {
            var tmp = new T[Count];
            Array.Copy(data, tmp, Count);
            return String.Join("\n", tmp.Reverse());
        }
    }
}
