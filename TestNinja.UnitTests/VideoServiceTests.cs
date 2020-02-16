using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using Newtonsoft.Json;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnsError()
        {            
            _fileReader.Setup(fr => fr.ReadFile(It.IsAny<string>())).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_ValidFile_ReturnsTitle()
        {
            _fileReader.Setup(fr => fr.ReadFile("video.txt")).Returns(JsonConvert.SerializeObject(new Video { Id = 1, Title = "abc", IsProcessed = true }));

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Is.EqualTo("abc").IgnoreCase);
        }


        [Test]
        public void GetUnprocessedVideosAsCsv_EmptyVideosList_ReturnsEmptyString()
        {
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }


        [Test]
        public void GetUnprocessedVideosAsCsv_FilledVideosList_ReturnsIdsCommaSeparated()
        {
            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video> {
                new Video { Id = 1, Title = "abc", IsProcessed = false },
                new Video { Id = 2, Title = "abc", IsProcessed = false },
                new Video { Id = 3, Title = "abc", IsProcessed = false },
                new Video { Id = 4, Title = "abc", IsProcessed = false },
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3,4"));
        }
    }
}
