using textAnalysis = Text_Analysis.Services.TextAnalysisService;

namespace TestProject_Text_Analysis.TextAnalysisTests
{
    public class GetUniqWordsCountTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 0)]
        [InlineData(1, 1)]
        [InlineData(10, 3)]
        [InlineData(5, 5)]
        public void GetUniqWordsCountTest_Boundary(
            int totalWords, int uniqWords)
        {
            var list = new List<KeyValuePair<string, int>>();

            int nonUniqCount = totalWords - uniqWords;
            for (int i = 0; i < nonUniqCount; i++)
            {
                list.Add(new KeyValuePair<string, int>($"word{i}", 2));
            }

            for (int i = 0; i < uniqWords; i++)
            {
                list.Add(new KeyValuePair<string, int>($"uniq{i}", 1));
            }

            // Act
            int result = textAnalysis.GetUniqWordsCount(list);

            // Assert
            Assert.Equal(uniqWords, result);
        }

    }
}
