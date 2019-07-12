using System;

namespace DoublyLinkedList
{
    /// <summary>
    /// Empty List exception will be thrown if we try to do invalid operations on an empty
    /// linked list, due to it is empty.
    /// </summary>
    public class EmptyListException : Exception
    {
        /// <summary>
        /// Initializes a new empty list exception with a string message given in the argument
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public EmptyListException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new empty list exception without a message
        /// </summary>
        public EmptyListException() { }
    }
}
