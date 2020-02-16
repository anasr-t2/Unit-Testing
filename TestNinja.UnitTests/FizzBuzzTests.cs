using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15)]
        [TestCase(30)]
        public void GetOutput_DivisibleBy3And5_ReturnFizzBuzz(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo("fizzbuzz").IgnoreCase);
        }

        [Test]
        [TestCase(3)]
        [TestCase(33)]
        public void GetOutput_DivisibleBy3Only_ReturnFizz(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo("fizz").IgnoreCase);
        }


        [Test]
        [TestCase(5)]
        [TestCase(50)]
        public void GetOutput_DivisibleBy5only_ReturnBuzz(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo("buzz").IgnoreCase);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void GetOutput_NotDivisibleBy3Or5_ReturnSameNumber(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(number.ToString()));
        }
    }
}
