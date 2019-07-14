using NUnit.Framework;
using Dojo;

namespace dojo.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AreIsomorphic_GivenTwoIsomorphicStrings_ShouldReturnTrue()
        {
            var str1 = "foo";
            var str2 = "bee";
            var result = IsomorphicStrings.AreIsomorphic(str1, str2);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AreIsomorphic_GivenTwoNotIsomorphicButSameLengthStrings_ShouldRetrunFalse()
        {
            var str1 = "foo";
            var str2 = "bob";
            var result = IsomorphicStrings.AreIsomorphic(str1, str2);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AreIsomorphic_GivenTwoDifferentLengthStrings_ShoudReturnFalse()
        {
            var str1 = "foo";
            var str2 = "boob";
            var result = IsomorphicStrings.AreIsomorphic(str1, str2);
            Assert.AreEqual(false, result);
        }

    }
}
