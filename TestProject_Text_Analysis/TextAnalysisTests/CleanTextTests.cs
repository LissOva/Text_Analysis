using textAnalysis = Text_Analysis.Services.TextAnalysisService;

namespace TestProject_Text_Analysis.TextAnalysisTests
{
    public class CleanTextTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("A", "a")]
        [InlineData("5", "")]
        [InlineData("     ", "")]
        public void CleanText_BoundaryInputs(string input, string expected)
        {
            string result = textAnalysis.CleanText(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hello, world!", "hello world")]
        [InlineData("Test: 123 +456 @example", "test example")]
        [InlineData("!@#$%^&*()", "")]
        [InlineData("123 456", "")]
        public void CleanText_Punctuation_Digits(string input, string expected)
        {
            string result = textAnalysis.CleanText(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("don't stop", "don't stop")]
        [InlineData("state-of-the-art", "state-of-the-art")]
        [InlineData("'Start' don't \"stop\" -test- end'", "start don't stop test end")]
        public void CleanText_Apostrophes_Hyphens(string input, string expected)
        {
            string result = textAnalysis.CleanText(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hello WORLD", "hello world")]
        [InlineData("  multiple   spaces  ", "multiple spaces")]
        [InlineData("Привет, МИР!", "привет мир")]
        public void CleanText_Normalization(string input, string expected)
        {
            string result = textAnalysis.CleanText(input);
            Assert.Equal(expected, result);
        }
    }
}
