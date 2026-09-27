using Reqnroll;
using Text_Analysis.Services;
using Xunit;

namespace Text_Analysis_BddTests.StepDefinitions
{
    [Binding]
    public class StatisticsCalculationSteps
    {
        private string _content = string.Empty;
        private List<string> _wordList = new();
        private Dictionary<string, int> _wordFrequencies = new();
        private List<KeyValuePair<string, int>> _sortedPairs = new();
        private int _totalCount;
        private int _uniqCount;
        private double _uniqPercentage;

        [Given(@"пользователь вводит текст для анализа:")]
        public void GivenUserEntersTextTable(Table table)
        {
            var row = table.Rows[0];
            _content = row["Content"];
        }

        [When(@"система выполняет подсчет частоты слов")]
        public void WhenSystemCountsFrequencies()
        {
            string cleaned = TextAnalysisService.CleanText(_content);
            _wordList = cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            _wordFrequencies = new Dictionary<string, int>();
            foreach (var w in _wordList)
            {
                if (_wordFrequencies.ContainsKey(w))
                    _wordFrequencies[w]++;
                else
                    _wordFrequencies[w] = 1;
            }

            _sortedPairs = SortingService.BuiltInSort(_wordFrequencies);
            _totalCount = TextAnalysisService.GetWordsCount(_wordList);
        }

        [When(@"система определяет список уникальных слов")]
        public void WhenSystemCalculatesUniqueWords()
        {
            _uniqCount = TextAnalysisService.GetUniqWordsCount(_sortedPairs);
            _uniqPercentage = TextAnalysisService.GetUniqWordPercent(_totalCount, _uniqCount);
        }

        [Then(@"общее количество слов должно быть равно (.*)")]
        public void ThenTotalWordsCountShouldBe(int expected)
        {
            Assert.Equal(expected, _totalCount);
        }

        [Then(@"количество уникальных слов должно быть равно (.*)")]
        public void ThenUniqueWordsCountShouldBe(int expected)
        {
            Assert.Equal(expected, _uniqCount);
        }

        [Then(@"процент уникальных слов должен быть (.*)")]
        public void ThenUniqueWordsPercentageShouldBe(double expected)
        {
            Assert.Equal(expected, _uniqPercentage, precision: 2);
        }

        [Then(@"слово ""(.*)"" не должно считаться уникальным")]
        public void ThenWordShouldNotBeUnique(string word)
        {
            Assert.True(_wordFrequencies.ContainsKey(word));
            Assert.True(_wordFrequencies[word] > 1, $"Слово '{word}' встретилось {_wordFrequencies[word]} раз, а ожидалось > 1");
        }
    }
}