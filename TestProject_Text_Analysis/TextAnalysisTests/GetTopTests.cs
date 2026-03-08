using TestProject_Text_Analysis.UnitTests;
using Text_Analysis.Model;
using Text_Analysis.Services;
using textAnalysis = Text_Analysis.Services.TextAnalysisService;

namespace TestProject_Text_Analysis.TextAnalysisTests
{
    public class GetTopTests
    {

        public static List<KeyValuePair<string, int>> normalList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("j", 100),
                new KeyValuePair<string, int>("i", 99),
                new KeyValuePair<string, int>("h", 98),
                new KeyValuePair<string, int>("g", 97),
                new KeyValuePair<string, int>("f", 96),
                new KeyValuePair<string, int>("e", 95),
                new KeyValuePair<string, int>("d", 94),
                new KeyValuePair<string, int>("c", 93),
                new KeyValuePair<string, int>("b", 92),
                new KeyValuePair<string, int>("a", 91),
                new KeyValuePair<string, int>("k", 90),
                new KeyValuePair<string, int>("l", 88)
            };
        List<WordCount> normalTopWords = new List<WordCount>
            {
                new WordCount("j", 100),
                new WordCount("i", 99),
                new WordCount("h", 98),
                new WordCount("g", 97),
                new WordCount("f", 96),
                new WordCount("e", 95),
                new WordCount("d", 94),
                new WordCount("c", 93),
                new WordCount("b", 92),
                new WordCount("a", 91),
            };

        public static List<KeyValuePair<string, int>> oneList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("j", 100),
                new KeyValuePair<string, int>("i", 99),
                new KeyValuePair<string, int>("h", 98),
                new KeyValuePair<string, int>("g", 97),
                new KeyValuePair<string, int>("f", 96),
                new KeyValuePair<string, int>("e", 95),
                new KeyValuePair<string, int>("d", 94),
                new KeyValuePair<string, int>("c", 93),
                new KeyValuePair<string, int>("b", 92),
                new KeyValuePair<string, int>("a", 91),
                new KeyValuePair<string, int>("k", 90),
                new KeyValuePair<string, int>("l", 88)
            };
        List<WordCount> oneTopWords = new List<WordCount>
            {
                new WordCount("j", 100),
                new WordCount("i", 99),
                new WordCount("h", 98),
                new WordCount("g", 97),
                new WordCount("f", 96),
                new WordCount("e", 95),
                new WordCount("d", 94),
                new WordCount("c", 93),
                new WordCount("b", 92),
                new WordCount("a", 91),
            };

        public static List<KeyValuePair<string, int>> smallList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("j", 10),
                new KeyValuePair<string, int>("i", 9),
                new KeyValuePair<string, int>("h", 8),
                new KeyValuePair<string, int>("c", 3),
                new KeyValuePair<string, int>("b", 2)
            };
        List<WordCount> smallTopWords = new List<WordCount>
            {
                new WordCount("j", 10),
                new WordCount("i", 9),
                new WordCount("h", 8),
                new WordCount("c", 3),
                new WordCount("b", 2),
            };

        public static List<KeyValuePair<string, int>> sameCountList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("j", 100),
                new KeyValuePair<string, int>("i", 100),
                new KeyValuePair<string, int>("h", 100),
                new KeyValuePair<string, int>("g", 100),
                new KeyValuePair<string, int>("f", 96),
                new KeyValuePair<string, int>("e", 95),
                new KeyValuePair<string, int>("d", 94),
                new KeyValuePair<string, int>("c", 93),
                new KeyValuePair<string, int>("b", 92),
                new KeyValuePair<string, int>("a", 91),
                new KeyValuePair<string, int>("k", 90),
                new KeyValuePair<string, int>("l", 88),
                new KeyValuePair<string, int>("m", 89),
                new KeyValuePair<string, int>("n", 70),
                new KeyValuePair<string, int>("o", 70),
                new KeyValuePair<string, int>("p", 1),
                new KeyValuePair<string, int>("q", 1),
                new KeyValuePair<string, int>("r", 1),
            };
        List<WordCount> sameCountTopWords = new List<WordCount>
            {
                new WordCount("j", 100),
                new WordCount("i", 100),
                new WordCount("h", 100),
                new WordCount("g", 100),
                new WordCount("f", 96),
                new WordCount("e", 95),
                new WordCount("d", 94),
                new WordCount("c", 93),
                new WordCount("b", 92),
                new WordCount("a", 91),
                new WordCount("k", 90),
                new WordCount("l", 88),
                new WordCount("m", 89),
            };

        [Fact]
        public void GetTopTest_NormalTop() {
            // Arrange 
            var value = normalList;

            // Act
            var result = textAnalysis.GetTop(value);

            // Assert
            var expectedResult = normalTopWords;

            Assert.Equal(result.Count, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Word, result[i].Word);
                Assert.Equal(expectedResult[i].Count, result[i].Count);
            }
        }

        [Fact]
        public void GetTopTest_OneTop()
        {
            // Arrange 
            var value = smallList;

            // Act
            var result = textAnalysis.GetTop(value);

            // Assert
            var expectedResult = smallTopWords;

            Assert.Equal(result.Count, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Word, result[i].Word);
                Assert.Equal(expectedResult[i].Count, result[i].Count);
            }
        }

        [Fact]
        public void GetTopTest_SmallTop()
        {
            // Arrange 
            var value = smallList;

            // Act
            var result = textAnalysis.GetTop(value);

            // Assert
            var expectedResult = smallTopWords;

            Assert.Equal(result.Count, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Word, result[i].Word);
                Assert.Equal(expectedResult[i].Count, result[i].Count);
            }
        }

        [Fact]
        public void GetTopTest_sameCountTop()
        {
            // Arrange 
            var value = sameCountList;

            // Act
            var result = textAnalysis.GetTop(value);

            // Assert
            var expectedResult = sameCountTopWords;

            Assert.Equal(result.Count, expectedResult.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].Word, result[i].Word);
                Assert.Equal(expectedResult[i].Count, result[i].Count);
            }
        }

        public void GetTopTest_EmptyList()
        {
            // Arrange 
            var value = new List<KeyValuePair<string, int>>();

            // Act
            var result = textAnalysis.GetTop(value);

            // Assert
            Assert.Empty(value);
        }

        [Fact]
        public void GetTopTest_Null()
        {
            // Act
            var result = textAnalysis.GetTop(null);

            // Assert
            Assert.Empty(result);
        }
    }
}
