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

            /*
             for (int i = 0; i < list.Size; ++i) {
                list[i] = 100 + i;
            }
            */

            
            /*
             foreach (var obj in list.getEach()) {
                Console.WriteLine(obj);
            } 
            */

            var list2 = new LinkedList<int>();
            list2.Add(7,8,9,10,11,12,13);

            list += list2;
            list += 6969;
            Console.WriteLine(list);

            Console.ReadKey();
        }
    }
}
