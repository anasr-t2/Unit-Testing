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
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ReturnSurroundedByStrongTag()
        {
            var htmlFormatter = new HtmlFormatter();

            var result = htmlFormatter.FormatAsBold("abc");

            //Assert.AreEqual(result, "<Strong>abc</strong>");
            Assert.That(result, Is.EqualTo("<Strong>abc</strong>").IgnoreCase);
        }
    }
}
