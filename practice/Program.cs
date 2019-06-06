
namespace practice
{
   public class ArrayList<T>
    {
        private T[] data;
        private int capacity;
        int count;
        private object locker = new object();

        public ArrayList(int capacity)
        {
            this.capacity = capacity;
            data = new T[capacity];
        }

        public void Add(T element)
        {
            lock (locker)
            {
                data[count++] = element;
            }
        }

        public void Print()
        {
            foreach(var element in data)
            {
                System.Console.WriteLine(element);
            }
        }

    }

   class Program
    {
        public static void Main()
        {

        }
    }
}
