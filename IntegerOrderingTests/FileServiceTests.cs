using IntegerOrdering.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegerOrderingTests
{
    public class FileServiceTests
    {
        private Mock<IFileService> _fileServiceMock;

        public FileServiceTests()
        {
            _fileServiceMock = new Mock<IFileService>();
        }

        [Fact]
        public void GetLatestFile_IsValid()
        {
            var fileService = _fileServiceMock.Object;
            string expected = "1 2 3 4 5";
            _fileServiceMock.Setup<string>(f => f.GetLatestResults()).Returns("1 2 3 4 5").ToString();
            var actual = fileService.GetLatestResults();
            Assert.Equal(expected, actual);
        }
    }
}
