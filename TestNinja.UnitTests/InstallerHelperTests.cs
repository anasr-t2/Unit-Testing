using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadSucceeded_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("cust1", "installer1");

            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var result = _installerHelper.DownloadInstaller("cust1", "installer1");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_WhenCalled_CallsDownloadFileWithSameParams()
        {
            string customer = "cust1";
            string installer = "installer1";
            string url = string.Format("http://example.com/{0}/{1}",
                        customer,
                        installer);

            var result = _installerHelper.DownloadInstaller(customer, installer);
            _fileDownloader.Verify(fd => fd.DownloadFile(url, null));
        }
    }
}
