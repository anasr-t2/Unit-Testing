using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Fundamentals.Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Fundamentals.Stack<string>();
        }

        [Test]
        public void Push_PushNull_ThrowsArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_PushValidValue_ValueAdded()
        {
            _stack.Push("abc");
            //var latestPushedValue = _stack.Peek();
            Assert.That(_stack.Count, Is.EqualTo(1));
            //Assert.That(latestPushedValue, Is.EqualTo("abc"));

        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }
    }
}
