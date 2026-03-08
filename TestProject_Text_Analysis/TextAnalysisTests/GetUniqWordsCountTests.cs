using textAnalysis = Text_Analysis.Services.TextAnalysisService;

namespace TestProject_Text_Analysis.TextAnalysisTests
{
    public class GetUniqWordsCountTests
    {
        // Граничные случаи: пустой список, один элемент
        [Theory]
        [InlineData(0, 0)]   // пустой список
        [InlineData(5, 0)] // ни одного уникального слова
        [InlineData(1, 1)]   // один уникальный элемент (частота = 1)
        [InlineData(10, 3)]  // 10 слов, из них 3 уникальных в конце
        [InlineData(5, 5)]   // все 5 слов уникальны
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
