using System;
using System.Collections.Generic;
using System.Collections;
using DictionaryUsage.Model;
using DictionaryUsage.KeyIdentity;

namespace DictionaryUsage {

    class Program {

        static void Main(string[] args) {
            Dictionary<Point,string> points = new Dictionary<Point,string>(new LengthComparer());
            points.Add(new Point(1,9),"A");
            points.Add(new Point(1,-19), "B" );
            var iterator = points.GetEnumerator();
            while (iterator.MoveNext()) {
                KeyValuePair<Point, string> KVP = iterator.Current;
                Console.WriteLine($"{KVP.Key} - {KVP.Value}");
            }



        }
    }
}
