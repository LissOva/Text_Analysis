using sortingService = Text_Analysis.Services.SortingService;

namespace TestProject_Text_Analysis.UnitTests
{
    public class ShellSortTests
    {   
        [Fact]
        public void ShellSortTest_NormalList()
        {
            // Arrange 
            var value = TestValue.normalDictionary;

            // Act
            var result = sortingService.ShellSort(value);

            // Assert
            var expectedResult = TestValue.normalList;
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void ShellSortTest_OneWordList()
        {
            // Arrange 
            var value = TestValue.oneWordDictionary;

            // Assumption 
            Assume.That(value.Count == 1);
            Assume.That(value.Values.Any());

            // Act
            var result = sortingService.ShellSort(value);

            // Assert
            var expectedResult = TestValue.oneWordList;
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void ShellSortTest_TwoWordsList()
        {
            // Arrange 
            var value = TestValue.twoWordsDictionary;

            // Assumption 
            Assume.That(value.Count == 2);
            Assume.That(value.Values.Any());

            // Act
            var result = sortingService.ShellSort(value);

            // Assert
            var expectedResult = TestValue.twoWordList;
            Assert.Equal(result, expectedResult);
        }


        [Fact]
        public void ShellSortTest_LargeList()
        {
            // Arrange
            var value = TestValue.GenerateLargeDictionary();

            // Assumption 
            Assume.That(value.Count == 1000);
            Assume.That(value.Values.Any());

            // Act
            var result = sortingService.ShellSort(value);

            // Assert
            Assert.Equal(1000, result.Count);      
            Assert.Equal(999, result[0].Value);    
            Assert.Equal(0, result[999].Value);    
            Assert.True(result[0].Value > result[1].Value);  
            Assert.False(result[998].Value < result[999].Value); 
        }

        [Fact]
        public void ShellSortTest_SameList()
        {
            // Arrange
            var value = TestValue.sameValueDictionary;

            // Act
            var result = sortingService.ShellSort(value);

            // Assert
            // Assert
            var expectedResult = TestValue.sameValueList;
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void ShellSortTest_ReversedList()
        {
            // Arrange
            var value = TestValue.reversedDictionary;

            // Act
            var result = sortingService.ShellSort(value);

            // Assert
            var expectedResult = TestValue.reversedList;
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void ShellSortTest_EmptyList()
        {
            // Arrange 
            var value = new Dictionary<string, int>();

            // Act
            var result = sortingService.ShellSort(value);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ShellSortTest_Null()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sortingService.ShellSort(null));
        }
    }
}
