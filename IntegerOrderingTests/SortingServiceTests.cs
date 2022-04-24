using System;
using Xunit;
using IntegerOrdering.Services;
using Moq;
using IntegerOrdering.Sorters;

namespace IntegerOrderingTests
{
    public class SortingServiceTests
    {
        private Mock<IFileService> _fileServiceMock;   
        
        public SortingServiceTests()
        {
            _fileServiceMock = new Mock<IFileService>();    
        }

        [Fact]
        public void IsUnorderedStringListSorted_Valid()
        {

            var service = new SortingService(_fileServiceMock.Object, new BubbleSort(), new InsertionSort());
            var unsorted = "1 3 2 8 4 9 2";

            var expected = "for insertion sort";

            var result = service.SortStringData(unsorted);
            Assert.Contains(expected, result);
        }

        [Fact]
        public void IsUnorderedArraySorted_Valid()
        {

            var service = new SortingService(_fileServiceMock.Object, new BubbleSort(), new InsertionSort());
            var unsorted = new int[6]{ 1, 3, 2, 8, 4, 9 }; 

            var expected = "for insertion sort"; 
            var result = service.SortIntArray(unsorted);

            Assert.Contains(expected , result);
            expected = "for bubble sort";
            Assert.Contains(expected, result);
        }

        [Fact]
        public void InvalidStringData_Throws_Exception()
        {
            var service = new SortingService(_fileServiceMock.Object, new BubbleSort(), new InsertionSort());
            var unsorted = "";

            Assert.Throws<FormatException>(() => service.SortStringData(unsorted));

        }

        [Fact]
        public void NullArrayData_Throws_Exception()
        {
            var service = new SortingService(_fileServiceMock.Object, new BubbleSort(), new InsertionSort());
            
            Assert.Throws<NullReferenceException>(() => service.SortStringData(null));

        }

    }
}
