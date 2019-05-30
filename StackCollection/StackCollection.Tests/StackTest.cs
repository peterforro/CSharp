using NUnit.Framework;
using StackCollection;

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
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(expected, stack.ToString());
        }

        [Test]
        public void Push_CountReachesCapacity_StackCapacityShouldBeAugmentedWith10()
        {
            var stack = new Stack<int>(1);
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(11, stack.Capacity);
        }

        [Test]
        public void Push_CountReachesCapacity_StackShouldBeCopiedAndTheNewElementAddedProperly()
        {
            var stack = new Stack<int>(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var expected = "3\n2\n1";
            Assert.AreEqual(expected, stack.ToString());
        }

        [Test]
        public void Pop_ShouldGetTheLastElementOfTheStack()
        {
            var stack = new Stack<int>(2);
            var expected = 2;
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(expected, stack.Pop());
        }

        [Test]
        public void Pop_ShouldDecrementCountValue()
        {
            var stack = new Stack<int>(2);
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Peek_ShouldGetTheLastElement()
        {
            var stack = new Stack<int>(2);
            var expected = 2;
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(expected, stack.Peek());
        }

        [Test]
        public void Peek_ShouldntRemoveLastElement()
        {
            var stack = new Stack<int>(2);
            var expected = 2;
            stack.Push(1);
            stack.Push(2);
            stack.Peek();
            Assert.AreEqual(expected, stack.Pop());
        }
    }
}
