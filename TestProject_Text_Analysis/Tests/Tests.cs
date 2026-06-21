using System;
using System.Collections.Generic;
using System.Text;
using Text_Analysis.Model;

namespace TestProject_Text_Analysis.Tests
{
    public class Tests
    {
        [Fact]
        public void WordCount_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string testWord = "test";
            int testCount = 5;

            // Act
            var wordCount = new WordCount(testWord, testCount);

            // Assert
            Assert.Equal(testWord, wordCount.Word);
            Assert.Equal(testCount, wordCount.Count);
        }
    }
}
