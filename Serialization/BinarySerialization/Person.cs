using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    /// <summary>
    /// A sample class to try out binary serialization!!!
    /// Implements the IDeserializationCallback interface, to recalculate the unserialized field.
    /// </summary>
    [Serializable]
    public class Person : IDeserializationCallback
    {
        private static int _instanceCounter;

        /// <summary>
        /// Gets the ID of the person.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Gets the person's name.
        /// </summary>
        private string Name;

        /// <summary>
        /// Gets the person's Birth year.
        /// </summary>
        public int BirthYear { get; }

        /// <summary>
        /// Gets the person's Email address.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets or sets ther person's Age. The setter is private.
        /// This is a calculated field, so it won't be serialized.
        /// </summary>
        [field: NonSerialized]
        public int Age 
        {
            private set;
            get;
        }

        /// <summary>
        /// Static method to serialize an instance of this class.
        /// </summary>
        /// <param name="obj">Person object to serialize</param>
        /// <param name="destPath">The path of the destination folder</param>
        public static void Serialize(Person obj, string destPath)
        {
            var fileName = Path.Combine(destPath, $"obj{obj.ID}.dat");
            using (FileStream fs = File.Open(fileName, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, obj);
                    Console.WriteLine($"Object{obj.ID} has been serialized");
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
            ID = ++_instanceCounter;
            Name = name;
            BirthYear = birthYear;
            Email = email;
            Age = DateTime.Now.Year - birthYear;
        }

        /// <summary>
        /// Return the string representation of the object.
        /// This method override is inherited from the object base class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + "\n" + $"{BirthYear}" + "\n" + $"{Age}" + "\n" + Email;
        }

        /// <summary>
        /// After deserialization it calculates the not serialized age field's value
        /// </summary>
        /// <param name="sender"></param>
        public void OnDeserialization(object sender)
        {
            Age = DateTime.Now.Year - BirthYear;
        }
    }
}
