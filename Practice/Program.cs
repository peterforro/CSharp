using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice {
    class Program {
        static void Main(string[] args) {

            var fruits = new List<string> {
                "banana", "lemon", "mango", "melon"
            };
            //fruits.Remove("lemon");
            Console.WriteLine(fruits.Count);
            foreach (var fruit in fruits) {
                Console.WriteLine(fruit);
            }

            List<string> fruits2 = new List<string>();
            fruits2.Add("hello bello");


            Console.ReadKey();

        }
    }
}
