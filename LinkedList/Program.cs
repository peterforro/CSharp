using System;
using LinkedList.DoublyLinkedList;


namespace LinkedList {

    class Program {

        static void Main(string[] args) {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1,2,3,4,5,6);
            foreach (var element in list) {
                Console.WriteLine(element);
            }
            Console.ReadKey();

        }
    }
}
