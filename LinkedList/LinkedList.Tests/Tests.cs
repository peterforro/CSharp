using DoublyLinkedList;
using NUnit.Framework;
using System;

namespace LinkedList.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Add_AddingTheFirstElement_GetsTheRightStringRepresentation()
        {
            var newElement = "aaa";
            var linkedList = new LinkedList<string>();
            linkedList.Add(newElement);
            Assert.AreEqual("aaa", linkedList.ToString());
        }

        [Test]
        public void Add_AddingMultipleElements_GetsTheRightStringRepresentation()
        {
            var newElement1 = 0;
            var newElement2 = 1;
            var newElement3 = 2;
            var expected = "0, 1, 2";
            var linkedList = new LinkedList<int>();
            linkedList.Add(newElement1);
            linkedList.Add(newElement2);
            linkedList.Add(newElement3);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Add_AddingMultipleElementsAtOnce_GetsTheRightStringRepresentation()
        {
            var newElement1 = 0;
            var newElement2 = 1;
            var newElement3 = 2;
            var expected = "0, 1, 2";
            var linkedList = new LinkedList<int>();
            linkedList.Add(newElement1, newElement2, newElement3);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Insert_InsertElementToAnEmptyLinkedList_GetsTheRughtStringRepresentation()
        {
            var linkedList = new LinkedList<int>();
            var newElement = 0;
            var expected = "0";
            linkedList.Insert(0, newElement);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Insert_InsertElementToAnIndexBiggerThanTheLastExistingIndexOfTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>(0);
            var newElement = 1;
            var expected = "0, 1";
            linkedList.Insert(1, newElement);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Insert_InsertElementBetweenTheFirstAndTheLastIndexOfTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            var newElement = 69;
            var expected = "0, 69, 1, 2";
            linkedList.Insert(1, newElement);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Insert_InsertingElementToTheLastExistingIndexOfTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            var newElement = 69;
            var expected = "0, 1, 69, 2";
            linkedList.Insert(2, newElement);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Insert_InsertingToANegativeIndex_ShouldThrowIndexOutOfRangeException()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            var newElement = 69;
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.Insert(-1, newElement));
        }

        [Test]
        public void Add_InitializingTheLinkedListWithThreeElement_CountGetsTheRightNumberOfElements()
        {
            var linkedList = new LinkedList<int>(1, 2, 3);
            var expected = 3;
            Assert.AreEqual(expected, linkedList.Count);
        }

        [Test]
        public void AddRange_AddingAnIEnumerableCollectionToAnEmptyLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>();
            var newElements = new int[] { 0, 1, 2 };
            var expected = "0, 1, 2";
            linkedList.AddRange(newElements);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void AddRange_AddingAnIEnumerableCollectionToANotEmptyLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>(0);
            var newElements = new int[] { 1, 2 };
            var expected = "0, 1, 2";
            linkedList.AddRange(newElements);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Remove_RemoveTheFirstElementOfTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            var expected = "1, 2";
            linkedList.Remove(0);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Remove_RemoveTheLastElementOfTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            var expected = "0, 1";
            linkedList.Remove(2);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Remove_RemoveAnElementBetweenTheFirstAndTheLastIndex_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            var expected = "0, 2";
            linkedList.Remove(1);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Remove_TryToRemoveNegativeIndexElement_ShouldThrowIndexOutOfRangeException()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.Remove(-1));
        }

        [Test]
        public void Remove_TryToRemoveABiggerIndexElementThanTheLastIndex_ShouldThrowIndexOutOfRangeException()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            Assert.Throws<IndexOutOfRangeException>(() => linkedList.Remove(3));
        }

        [Test]
        public void Remove_TryToRemoveOnAnEmptyLinkedList_ShouldThrowEmptyListException()
        {
            var linkedList = new LinkedList<int>();
            Assert.Throws<EmptyListException>(() => linkedList.Remove(1));
        }

        [Test]
        public void Remove_RemoveSpecifiedObjectdFromTheFirstIndexOfTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<string>("aaa", "bbb", "ccc");
            var toRemove = "aaa";
            var expected = "bbb, ccc";
            linkedList.Remove(toRemove);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Remove_TryToRemoveSpecifiedObjectFromAnEmptyLinkedList_ShouldThrowEmptyListException()
        {
            var linkedList = new LinkedList<string>();
            var toRemove = "aaa";
            Assert.Throws<EmptyListException>(() => linkedList.Remove(toRemove));
        }

        [Test]
        public void Remove_RemoveSpecifiedObjectFromTheEndOfTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<string>("aaa", "bbb", "ccc");
            var toRemove = "ccc";
            var expected = "aaa, bbb";
            linkedList.Remove(toRemove);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Remove_RemoveSpecifiedObjectBetweenTheFirstAndTheLastElementFromTheLinkedList_GetsTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<string>("aaa", "bbb", "ccc");
            var toRemove = "bbb";
            var expected = "aaa, ccc";
            linkedList.Remove(toRemove);
            Assert.AreEqual(expected, linkedList.ToString());
        }

        [Test]
        public void Indexer_GivenIndex2_ShouldGetTheRightElementOfTheLinkedList()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            var expected = 1;
            Assert.AreEqual(expected, linkedList[1]);
        }

        [Test]
        public void Indexer_GivenIndexIsNegative_ShouldThrowIndexOutOfRangeException()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            Assert.Throws<IndexOutOfRangeException>(() => { var result = linkedList[-1]; });
        }

        [Test]
        public void Indexer_GivenIndexIsBiggerThanTheLast_ShouldThrowIndexOutOfRangeException()
        {
            var linkedList = new LinkedList<int>(0, 1, 2);
            Assert.Throws<IndexOutOfRangeException>(() => { var result = linkedList[3]; });
        }

        [Test]
        public void Indexer_ForLoopsWorksProperlyOnTheLinkedList_ShouldGetTheRightStringRepresentation()
        {
            var linkedList = new LinkedList<string>("aaa", "bbb", "ccc");
            var tmp = new string[linkedList.Count];
            for (var i = 0; i < linkedList.Count; ++i)
            {
                tmp[i] = linkedList[i];
            }
            Assert.AreEqual(linkedList.ToString(), String.Join(", ", tmp));
        }

        [Test]
        public void Contains_TryToFindSpecifiedObject_ShouldReturnTrue()
        {
            var linkedList = new LinkedList<string>("aaa", "bbb", "ccc");
            var toFind = "bbb";
            Assert.AreEqual(true, linkedList.Contains(toFind));
        }
    }
}
