using System;
using LinkedList.DoublyLinkedList;

namespace LinkedList {

    class Program {

        static void Main(string[] args) {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1,2,3);
            list.Insert(4,69);
            list.Delete(list.Size-1);
            Console.WriteLine(list);
            Console.ReadKey();
        }
    }
}
