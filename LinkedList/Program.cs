using System;
using LinkedList.DoublyLinkedList;


namespace LinkedList {

    class Program {

        static void Main(string[] args) {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1,2,3,4,5,6);

            //list.Insert(1,69);
            //list.Delete(1);
            //GC.Collect();
            //Console.WriteLine(list);
            //Console.ReadKey();

            /*for (int i = 0; i < list.Size; ++i) {
                list[i] = 100 + i;
            }*/

            foreach (var obj in list.getEach()) {
                Console.WriteLine(obj);
            }

            Console.ReadKey();
        }
    }
}
