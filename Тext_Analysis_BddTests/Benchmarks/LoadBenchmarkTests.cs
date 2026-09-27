using System.Diagnostics;
using System.Text.Json;
using Text_Analysis.Services;
using Xunit;
using Xunit.Abstractions;

namespace Text_Analysis_BddTests.Benchmarks
{
    public class LoadBenchmarkTests
    {
        private readonly ITestOutputHelper _output;

        public LoadBenchmarkTests(ITestOutputHelper output)
        {
            _output = output;
        }

        // Генерация датасета с четкой кодировкой структуры
        public static Dictionary<string, int> GenerateDataset(int size, string type)
        {
            var dict = new Dictionary<string, int>(size);
            var rnd = new Random(42);

            for (int i = 0; i < size; i++)
            {
                string word = $"word_{i:D7}";
                int freq = type switch
                {
                    "REV" => i,                 // Reversed: наихудший случай
                    "UNI" => 1,                 // Uniform: одинаковые значения
                    "RND" => rnd.Next(1, 10000),// Random: случайное распределение
                    _ => rnd.Next(1, 1000)
                };
                dict[word] = freq;
            }
            return dict;
        }

        [Fact]
        public void RunComparativeBenchmark()
        {
            // Наборы размеров для сравнительного профилирования
            int[] sizes = [1000, 3000, 5000, 10000, 20000];
            string[] types = ["REV", "RND"];

            _output.WriteLine("DatasetCode | Size | Type | BubbleSort(ms) | BuiltInSort(ms) | Ratio(Bubble/BuiltIn)");

            foreach (var type in types)
            {
                foreach (var size in sizes)
                {
                    string code = $"DS_{type}_{size}";
                    var data = GenerateDataset(size, type);

                    // Замер BuiltInSort
                    var sw = Stopwatch.StartNew();
                    var resBuiltIn = SortingService.BuiltInSort(data);
                    sw.Stop();
                    long builtInMs = sw.ElapsedMilliseconds;

                    // Замер BubbleSort
                    sw.Restart();
                    var resBubble = SortingService.BubbleSort(data);
                    sw.Stop();
                    long bubbleMs = sw.ElapsedMilliseconds;

                    double ratio = builtInMs > 0 ? (double)bubbleMs / builtInMs : bubbleMs;

                    _output.WriteLine($"{code} | {size} | {type} | {bubbleMs} | {builtInMs} | {ratio:F2}x");
                }
            }
        }

        [Fact]
        public void RunMaxBoundaryExperiment_BubbleSort()
        {
            // Поиск границы t1: при N = 60000-80000 элементов BubbleSort на худшем случае
            // выполняет ~ 2-4 млрд сравнений и как раз занимает 2-5 минут
            int size = 160000;
            var data = GenerateDataset(size, "REV");

            _output.WriteLine($"Старт предварительного эксперимента для BubbleSort на N={size}...");
            var sw = Stopwatch.StartNew();
            SortingService.BubbleSort(data);
            sw.Stop();

            _output.WriteLine($"BubbleSort завершился за: {sw.Elapsed.TotalMinutes:F2} минут ({sw.ElapsedMilliseconds} мс)");
        }
    }
}