using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Fundamentals.Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Fundamentals.Math();
            Console.WriteLine("BeforeTest");
        }

        [OneTimeSetUp]
        public void SetUpFirstly()
        {
            Console.WriteLine("BeforeTest");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("AfterTest");
        }

        [OneTimeTearDown]
        public void TearDownLastly()
        {
            Console.WriteLine("AfterTest");
        }

        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            // Act
            var result = _math.Add(1, 2);

            // Assert
            //Assert.AreEqual(result, 3);
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1,2,2)]
        [TestCase(2,1,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void GetOddNumbers_WhenCalled_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5).ToList();

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
