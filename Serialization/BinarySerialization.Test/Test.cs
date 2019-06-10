using NUnit.Framework;
using System;
using System.IO;

namespace BinarySerialization.Test
{
    [TestFixture]
    public class Tests
    {

        private static string _path = AppDomain.CurrentDomain.BaseDirectory;
        private const string _extension = ".dat";

        [Test]
        public void Person_CreatingANewPerson_ShouldGetTherCorrectAge()
        {
            var person = new Person("apacuka", 1990, "bla@bla.com");
            var expected = DateTime.Now.Year - person.BirthYear;
            Assert.AreEqual(expected, person.Age);
        }

        [Test]
        public void ToString_CreatingANewPerson_ShouldGetTheCorrectStringRepresentation()
        {
            var person = new Person("apacuka", 1990, "bla@bla.com");
            var expected = $"apacuka\n1990\n{DateTime.Now.Year-1990}\nbla@bla.com";
            Assert.AreEqual(expected, person.ToString());
        }

        [Test]
        public void Serialize_CreateFileFromObject()
        {
            var person = new Person("apacuka", 1990, "bla@bla.com");
            Person.Serialize(person, _path);
            var file = new FileInfo(Path.Combine(_path, $"obj{person.ID}{_extension}"));
            Assert.AreEqual(true, file.Exists);
        }

        [Test]
        public void Deserialize_SerializeAPersonThenDeserializeIt_DeserializedShouldGetCorrectStringRepresentation()
        {
            var person = new Person("apacuk", 1990, "bla@bla.com");
            Person.Serialize(person, _path);
            var deserialized = Person.Deserialize(Path.Combine(_path, $"obj{person.ID}{_extension}"));
            Assert.AreEqual(person.ToString(), deserialized.ToString());
        }
    }
}
