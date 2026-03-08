using textAnalysis = Text_Analysis.Services.TextAnalysisService;

namespace TestProject_Text_Analysis.TextAnalysisTests
{
    public class GetUniqWordPercentTests
    {
        [Theory]
        [InlineData(0, 0, 0)]          
        [InlineData(100, 0, 0)]
        [InlineData(200, 100, 50)]
        [InlineData(100, 100, 100)]
        public void GetUniqWordPercentTest_Boundary(
            double totalCount, double uniqCount, double expectedPercent)
        {
            // Act
            double result = textAnalysis.GetUniqWordPercent(totalCount, uniqCount);

            // Assert
            Assert.Equal(expectedPercent, result, 2); // точность до 2 знаков
        }
    }
}
