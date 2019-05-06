using System;
using System.Collections;
using System.Text;



namespace LinkedList.DoublyLinkedList {


    class LinkedList<T> {


        //NODE: listaelemek osztalya, talan lehetne struct is?! C++-ban tuti hogy struct-ot használtunk
        class Node {
            private static int instanceCounter;
            private string ID;
            public T data;
            public Node next, prev;
            public Node(T data) {
                ID = $"Node-{++instanceCounter}";
                this.data = data;
            }

            //Destruktor: csak es kizarolag a GC mukodesenek szemleltetesere, amugy teljesen felesleges
            ~Node() {
                Console.WriteLine($"Deleted: {ID}");
            }
        }


        //SENTINEL: referencia valtozok, amik a lista elejere es vegere mutatnak
        private Node head;
        private Node tail;


        //PROPERTY: az elemszam modositasahoz (classon belül) illetve lekerdezesehez
        public int Size {
            get;
            private set;
        }


        //ÚJ obj hozzáadasá a listához
        public void Add(T obj) {
            Node newNode = new Node(obj);
            switch (Size) {
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


        //Add fuggveny overloadolasa, valtozo szamu parametert (arbitary arguments) var az argumentumaba
        public void Add(params T[] objs) {
            foreach (var obj in objs) {
                Add(obj);
            }
        }



        //Új obj beszúrása a megadott pozícióra, SetIterators függvényt használja
        public void Insert(int index, T obj) {
            if (index < 0 || index >= Size) return;
            Node front, delay;
            SetIterators(index, out front, out delay);
            var newNode = new Node(obj);
            if (delay == null && head == null) {            //1. eset: ures listaba torteno beszuras, kvazi inicializalas
                head = tail = newNode;
            } else if (delay == null) {                     //2. eset: n elemszamu lista elso poziciora (0-as index) torteno beszuras (jobbra shiftel)
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            } else {                                        //3. eset: minden mas eset, azaz lanckozi illetve lancvegi beszuras
                newNode.next = front;
                newNode.prev = delay;
                delay.next = front.prev = newNode;
            }
            ++Size;
        }


        //SetIterators: beallitja a front es keslekedo referenciakat a megfelelo poziciora az index alapjan, torleshez es insert-hez
        private void SetIterators(int index, out Node front, out Node delay) {
            int idx = 0;
            front = head;
            delay = null;
            while (front.next != null && idx != index) {
                delay = front;
                front = front.next;
                ++idx;
            }
        }


        //adott indexu elemet torli a listabol. SetIterators fuggvenyt hasznalja
        public void Delete(int index) {
            if (index >= Size || index < 0) return;
            Node front, delay;
            SetIterators(index, out front, out delay);
            if (delay == null && head == tail) {        //1. eset: csak 1 elem van listaban, es azt toroljuk
                head = tail = null;
            } else if (delay == null) {                 //2. eset: n+1 elemszamu lista elso elemet toroljuk
                front.next.prev = null;
                head = front.next;
            } else if (front.next == null) {            //3. eset: n+1 elemszamu lista utolso elemet toroljuk
                delay.next = null;
                tail = delay;
            } else {                                    //4. eset: n>2 elemszamu lista valamelyik belso elemet toroljuk
                delay.next = front.next;
                front.next.prev = delay;
            }
            --Size;
        }


        //indexer operator overload: indexelo operator hasznalhato, irashoz es olvasashoz egyarant
        public T this[int index] {
            get {
                var iter = head;
                int idx = 0;
                while (idx != index) {
                    ++idx;
                    iter = iter.next;
                }
                return iter.data;
            }
            set {
                var iter = head;
                int idx = 0;
                while (idx != index) {
                    ++idx;
                    iter = iter.next;
                }
                iter.data = value;
            }
        }


        //iterator method: foreach ciklus hasznalhatosagahoz
        public IEnumerable getEach() {
            var iter = head;
            while (iter != null) {
                yield return iter.data;
                iter = iter.next;
            }
        }


        //ToString metodus (object ososztalytol orokolt)
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (Node iter = head; iter != null; iter = iter.next) {
                sb.Append(iter.data.ToString() + " ");
            }
            return sb.ToString();
        }
    }
}
