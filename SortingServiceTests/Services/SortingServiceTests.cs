using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntegerOrdering.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerOrdering.Services.Tests
{
    [TestClass()]
    public class SortingServiceTests
    {
        IFileService _fileService;
        ISortingService _sortingService;
        SortingServiceTests(IFileService fileService, ISortingService sortingService)
        {
            _fileService = fileService;
            _sortingService = sortingService;
        }
        [TestMethod()]
        public void SortDataTest()
        {
            _sortingService.SortData("1 3 2 5 2");

            Assert.Fail();
        }
    }
}