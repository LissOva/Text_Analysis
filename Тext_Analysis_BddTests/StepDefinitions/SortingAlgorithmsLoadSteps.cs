using System.Diagnostics;
using Reqnroll;
using Text_Analysis.Services;
using Xunit;

namespace Text_Analysis_BddTests.StepDefinitions
{
    [Binding]
    public class SortingAlgorithmsLoadSteps
    {
        private Dictionary<string, int> _dataset = new();
        private List<KeyValuePair<string, int>> _bubbleResult = new();
        private List<KeyValuePair<string, int>> _builtInResult = new();
        private long _bubbleTimeMs;
        private long _builtInTimeMs;

        [Given(@"сгенерирован частотный словарь слов типа ""(.*)"" размером (.*)")]
        public void GivenFrequencyDictionaryGenerated(string dataType, int size)
        {
            _dataset = new Dictionary<string, int>();
            var random = new Random(42);

            for (int i = 0; i < size; i++)
            {
                string word = $"word_{i}";
                int freq = dataType switch
                {
                    "Uniform" => 5,
                    "Reversed" => i + 1,
                    _ => random.Next(1, 1000)
                };
                _dataset[word] = freq;
            }
        }

        [When(@"выполняется сортировка словаря алгоритмом ""BubbleSort""")]
        public void WhenBubbleSortExecuted()
        {
            _bubbleResult = SortingService.BubbleSort(_dataset);
        }

        [When(@"выполняется сортировка словаря алгоритмом ""BuiltInSort""")]
        public void WhenBuiltInSortExecuted()
        {
            _builtInResult = SortingService.BuiltInSort(_dataset);
        }

        [Then(@"оба алгоритма должны вернуть идентичный порядок пар слово-частота")]
        public void ThenBothAlgorithmsReturnIdenticalResults()
        {
            Assert.Equal(_bubbleResult.Count, _builtInResult.Count);
            for (int i = 0; i < _bubbleResult.Count; i++)
            {
                Assert.Equal(_bubbleResult[i].Value, _builtInResult[i].Value);
            }
        }

        [Given(@"сгенерирован большой синтетический датасет со (.*) уникальными словами")]
        public void GivenLargeDatasetGenerated(int size)
        {
            _dataset = new Dictionary<string, int>();
            var rnd = new Random(1337);
            for (int i = 0; i < size; i++)
            {
                _dataset[$"term_{i}"] = rnd.Next(1, 10000);
            }
        }

        [When(@"замеряется время работы алгоритмов ""BubbleSort"" и ""BuiltInSort""")]
        public void WhenTimingBothAlgorithms()
        {
            var sw = Stopwatch.StartNew();
            _builtInResult = SortingService.BuiltInSort(_dataset);
            sw.Stop();
            _builtInTimeMs = sw.ElapsedMilliseconds;

            sw.Restart();
            _bubbleResult = SortingService.BubbleSort(_dataset);
            sw.Stop();
            _bubbleTimeMs = sw.ElapsedMilliseconds;
        }

        [Then(@"алгоритм ""BuiltInSort"" должен завершиться быстрее чем за (.*) миллисекунд")]
        public void ThenBuiltInSortFastEnough(int maxMs)
        {
            Assert.True(_builtInTimeMs <= maxMs, $"BuiltInSort занял {_builtInTimeMs} мс, что больше {maxMs} мс");
        }

        [Then(@"алгоритм ""BuiltInSort"" должен работать быстрее алгоритма ""BubbleSort"" минимум в (.*) раз")]
        public void ThenBuiltInFasterThanBubble(int factor)
        {
            // Если BuiltInSort сработал за 0 мс, берем минимальную оценку в 1 мс
            long safeBuiltIn = Math.Max(1, _builtInTimeMs);
            Assert.True(_bubbleTimeMs >= safeBuiltIn * factor,
                $"BubbleSort ({_bubbleTimeMs} мс) не был быстрее BuiltInSort ({_builtInTimeMs} мс) хотя бы в {factor} раз");
        }
    }
}