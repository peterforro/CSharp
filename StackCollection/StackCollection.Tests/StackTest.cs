using NUnit.Framework;
using System;
using System.Text;

namespace StackCollection.Tests
{
    [TestFixture]
    public class StackTest
    {
        [Test]
        public void Push_EmptyStack_CountShouldBe0()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void Stack_EmptyStack_InitialCapacityShouldBe10()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(10, stack.Capacity);
        }

        [Test]
        public void Push_FirstElement_CountShouldBe1()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Push_GivenArg1ToEmptyStack()
        {
            var stack = new Stack<int>();
            var expected = "1";
            stack.Push(1);
            Assert.AreEqual(expected, stack.ToString());
        }

        [Test]
        public void Push_NewElements_LatestElementShouldBeAtTheTop()
        {
            var stack = new Stack<int>();
            var expected = "3\n2\n1";
            stack.Push(1); stack.Push(2); stack.Push(3);
            Assert.AreEqual(expected, stack.ToString());
        }

        [Test]
        public void Push_CountReachesCapacity_StackCapacityShouldBeAugmentedWith10()
        {
            var stack = new Stack<int>(1);
            stack.Push(1); stack.Push(2);
            Assert.AreEqual(11, stack.Capacity);
        }

        [Test]
        public void Push_CountReachesCapacity_StackShouldBeCopiedAndTheNewElementAddedProperly()
        {
            var stack = new Stack<int>(1);
            stack.Push(1); stack.Push(2); stack.Push(3);
            var expected = "3\n2\n1";
            Assert.AreEqual(expected, stack.ToString());
        }

        [Test]
        public void Pop_ShouldGetTheLastElementOfTheStack()
        {
            var stack = new Stack<int>(2);
            var expected = 2;
            stack.Push(1); stack.Push(2);
            Assert.AreEqual(expected, stack.Pop());
        }

        [Test]
        public void Pop_PoppingStackWhileCountNotReachesZero()
        {
            var stack = new Stack<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            var expected = "10987654321";
            var sb = new StringBuilder();
            while(stack.Count != 0)
            {
                sb.Append($"{stack.Pop()}");
            }
            Assert.AreEqual(expected, sb.ToString());
        }


        [Test]
        public void Pop_ShouldDecrementCountValue()
        {
            var stack = new Stack<int>(2);
            stack.Push(1); stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Peek_ShouldGetTheLastElement()
        {
            var stack = new Stack<int>(2);
            var expected = 2;
            stack.Push(1); stack.Push(2);
            Assert.AreEqual(expected, stack.Peek());
        }

        [Test]
        public void Peek_ShouldntRemoveLastElement()
        {
            var stack = new Stack<int>(2);
            var expected = 2;
            stack.Push(1); stack.Push(2);
            stack.Peek();
            Assert.AreEqual(expected, stack.Pop());
        }

        [Test]
        public void Contains_ValueToLookForIs2_ShouldReturnTure()
        {
            var stack = new Stack<int>(3);
            var expected = true;
            stack.Push(1); stack.Push(2); stack.Push(3);
            Assert.AreEqual(expected, stack.Contains(2));
        }

        [Test]
        public void Contains_ValueToLookForIs0_ShouldReturnFalse()
        {
            var stack = new Stack<int>(3);
            var expected = false;
            stack.Push(1); stack.Push(2); stack.Push(3);
            Assert.AreEqual(expected, stack.Contains(0));
        }

        [Test]
        public void ToArray_ReturnedArrayContentShouldEqualWithSample()
        {
            var stack = new Stack<int>(3);
            stack.Push(1); stack.Push(2); stack.Push(3);
            var expected = "123";
            var array = stack.ToArray();
            var sb = new StringBuilder();
            foreach(var element in array)
            {
                sb.Append($"{element}");
            }
            Assert.AreEqual(expected, sb.ToString());
        }

        [Test]
        public void Stack_InitializeStackWithAnArrayInConstructor()
        {
            int[] numbers = new int[] { 1, 2, 3 };
            var stack = new Stack<int>(numbers);
            var expected = "3\n2\n1";
            Assert.AreEqual(expected, stack.ToString());
        }

        [Test]
        public void Indexer_TestIndexerWhetherWorksProperly()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            var stack = new Stack<int>(numbers);
            var expected = 3;
            Assert.AreEqual(expected, stack[3]);
        }

        [Test]
        public void Indexer_TestingAssignmentOperatorOnIndexer()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            var stack = new Stack<int>(numbers);
            var expected = 69;
            stack[1] = 69;
            Assert.AreEqual(expected, stack[1]);
        }
        
        [Test]
        public void Indexer_IndexerIsEqualToCount_ShouldThrowIndexOutOfRangeException()
        {
            int[] numbers = new int[] { 1, 2, 3 };
            var stack = new Stack<int>(numbers);
            Assert.Throws<IndexOutOfRangeException>(() => { var number = numbers[3]; });
        }

        [Test]
        public void Indexer_IndexerIsLessThanZero_ShouldThrowIndexOutOfRangeException()
        {
            int[] numbers = new int[] { 1, 2, 3 };
            var stack = new Stack<int>(numbers);
            Assert.Throws<IndexOutOfRangeException>(() => { var number = numbers[-1]; });
        }

        [Test]
        public void GetEach_TestingTheIteratorMethod_ShouldGetTheWholeContentOfTheStack()
        {
            int[] numbers = new int[] { 1, 2, 3 };
            var stack = new Stack<int>(numbers);
            var expected = "321";
            var sb = new StringBuilder();
            foreach(var element in stack.GetEach())
            {
                sb.Append(element);
            }
            Assert.AreEqual(expected, sb.ToString());
        }

        [Test]
        public void Pop_PoppingOnEmptyStack_ShouldTrhowInvalidOperationException()
        {
            var stack = new Stack<int>();
            Assert.Throws<InvalidOperationException>(() => { var number = stack.Pop(); });
        }

        [Test]
        public void Peek_PeekOnEmptyStack_ShouldReturnInvalidOperationException()
        {
            var stack = new Stack<int>();
            Assert.Throws<InvalidOperationException>(() => { var number = stack.Pop(); });
        }
    }
}
