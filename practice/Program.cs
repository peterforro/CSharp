using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace practice
{
    /// <summary>
    /// A sample class to try out binary serialization!!!
    /// Implements the IDeserializationCallback interface, to recalculate the unserialized field.
    /// </summary>
    [Serializable]
    public class Person : IDeserializationCallback
    {
        private static int _instanceCounter;

        private int _ID;
        private string _name;
        private int _birthYear;
        private string _email;

        /// <summary>
        /// A calculated value field, it is not necessary to serialize
        /// </summary>
        [NonSerialized]
        private int _age;

        /// <summary>
        /// Static method to serialize an instance of this class.
        /// </summary>
        /// <param name="obj">Person object to serialize</param>
        /// <param name="destPath">The path of the destination folder</param>
        public static void Serialize(Person obj, string destPath)
        {
            var fileName = Path.Combine(destPath, $"obj{obj._ID}.dat");
            using (FileStream fs = File.Open(fileName, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, obj);
                    Console.WriteLine($"Object{obj._ID} has been serialized");
                }
                catch (SerializationException exception)
                {
                    Console.WriteLine("Serialization: " + exception.Message);
                }
            }
        }

        /// <summary>
        /// Deser
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Person Deserialize(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    return (Person)formatter.Deserialize(fs);
                }
                catch (SerializationException exception)
                {
                    Console.WriteLine("Deserialization: " + exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Initializes an instance of the Person class
        /// </summary>
        /// <param name="name">Name of ther person</param>
        /// <param name="birthYear">Year of birth</param>
        /// <param name="email">Email address</param>
        public Person(string name, int birthYear, string email)
        {
            _ID = ++_instanceCounter;
            _name = name;
            _birthYear = birthYear;
            _email = email;
            _age = DateTime.Now.Year - birthYear;
        }

        /// <summary>
        /// Return the string representation of the object.
        /// This method override is inherited from the object base class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _name + " - " + $"{_birthYear}" + " - " + $"{_age}" + " - " + _email;
        }

        /// <summary>
        /// After deserialization it calculates the not serialized age field's value
        /// </summary>
        /// <param name="sender"></param>
        public void OnDeserialization(object sender)
        {
            _age = DateTime.Now.Year - _birthYear;
        }
    }

    /// <summary>
    /// Main program
    /// </summary>
    class Program
    {
        private const int _personNumber = 2;
        private const string _destPath = @"D:\code\C#\";
        private const string _extension = ".dat";

        /// <summary>
        /// Helper method to create a new person instance.
        /// Reads in the needed data (name, year of birth, email) from the consol
        /// </summary>
        /// <returns>New person object</returns>
        private static Person NewPerson()
        {
            Console.Write("\nName?: ");
            var name = Console.ReadLine();
            Console.Write("Birth year?: ");
            var birthYear = int.Parse(Console.ReadLine());
            Console.Write("Email?: ");
            var email = Console.ReadLine();
            return new Person(name, birthYear, email);
        }

        /// <summary>
        /// Static method to do some binary serialization
        /// </summary>
        private static void BinaraySerializationTest()
        {
            var persons = new List<Person>();
            for (var i = 0; i < _personNumber; ++i)
            {
                persons.Add(NewPerson());
            }
            persons.ForEach(person => Person.Serialize(person, _destPath));
        }

        /// <summary>
        /// Static method to do some binary deserialization
        /// </summary>
        private static void BinaryDeserializationTest()
        {
            var di = new DirectoryInfo(_destPath);
            var serializedObjs = di.GetFiles("*" + _extension);
            var persons = new List<Person>();
            foreach(var obj in serializedObjs)
            {
                persons.Add(Person.Deserialize(obj.FullName));
            }
        
            foreach(var person in persons)
            {
                Console.WriteLine(person);
            }
        }

        /// <summary>
        /// Main Entry of the program
        /// </summary>
        public static void Main()
        {
            BinaraySerializationTest();
            BinaryDeserializationTest();
            Console.ReadKey();
        }
    }
}
