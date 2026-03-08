using textAnalysis = Text_Analysis.Services.TextAnalysisService;

namespace TestProject_Text_Analysis.TextAnalysisTests
{
    public class GetWordsCountTests
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(5, 5)]
        [InlineData(1000, 1000)]
        public void GetWordsCount_Boundary(object input, int expectedCount)
        {
            // Arrange
            List<string>? words = input == null
                ? null
                : Enumerable.Range(0, (int)input).Select(i => $"word{i}").ToList();

            // Act
            int result = textAnalysis.GetWordsCount(words);

            // Assert
            Assert.Equal(expectedCount, result);
        }
    }
}
