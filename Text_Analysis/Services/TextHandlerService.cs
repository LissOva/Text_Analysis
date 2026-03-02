using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Text_Analysis.Model;

namespace Text_Analysis.Services
{
    public class TextHandlerService
    {
        //Ввод с клавиатуры
        public static TextDataset TextInputKeyboard()
        {
            Console.WriteLine("Ener title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Ener text: ");
            string text = Console.ReadLine();

            TextItem textItem = new TextItem(title, text);

            TextDataset dataset = new TextDataset(textItem);

            return dataset;
        }

        //Чтение из файла json
        public static TextDataset TextInputFile()
        {

            string filePath = Path.Combine(
             AppDomain.CurrentDomain.BaseDirectory,
             "..",
             "..",
             "..",
             "Dataset",
             "input.json"
         );
            filePath = Path.GetFullPath(filePath);

            string json = File.ReadAllText(filePath);
            TextDataset dataset = JsonSerializer.Deserialize<TextDataset>(json);

            return dataset;
        }

        //Вывод в консоль
        public static void TextOutputConsole(string title, List<WordCount> list, int totalCount, int uniqCount, double uniqPercent)
        {
            const int width = 38;
            const int rankWidth = 3;
            const int wordWidth = 20;
            const int countWidth = 5;

            Console.Write(new string(' ', (width - title.Length) / 2));
            FormattingService.ConsoleTitle(title);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"#",rankWidth}    {"Word",-wordWidth}    {"Count",countWidth}");
            Console.WriteLine(new string('-', width));
            Console.ResetColor();

            int i = 0;
            for (int rank = 0; rank < 10 && i < list.Count; rank++)
            {
                Console.WriteLine($"{rank + 1,rankWidth}    {list[i].Word,-wordWidth}    {list[i].Count,countWidth}");

                while (i + 1 < list.Count && list[i].Count == list[i + 1].Count)
                {
                    Console.WriteLine($"{" ",rankWidth}    {list[i + 1].Word,-wordWidth}    {list[i + 1].Count,countWidth}");
                    i++;
                }
                i++;
            }

            FormattingService.ConsoleHighlight("Total number of words: ");
            Console.WriteLine(totalCount);
            FormattingService.ConsoleHighlight("Unique words: ");
            Console.WriteLine(uniqCount);
            FormattingService.ConsoleHighlight("Percentage of unique words: ");
            Console.WriteLine($"{Math.Round(uniqPercent)}%");
        }

        // Запись в файл json
        public static void TextOutputFile(int n, string title, List<WordCount> list, int totalCount, int uniqCount, double uniqPercent)
        {
            // Формируем объект результата
            var result = new AnalysisResult
            {
                Title = title,
                TopWords = list,
                TotalWords = totalCount,
                UniqueWords = uniqCount,
                UniqueWordsPercentage = Math.Round(uniqPercent, 2)
            };

            // Путь к файлу
            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..",
                "Dataset",
                String.Join("", title,"_",n.ToString(), ".json")
            );
            filePath = Path.GetFullPath(filePath);

            // Создаём директорию, если её нет
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Настройки сериализации
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };

            // Сериализация и запись в файл
            string json = JsonSerializer.Serialize(result, options);
            File.WriteAllText(filePath, json);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nРезультаты сохранены в {filePath}\n\n");
            Console.ResetColor();
        }
    }
}
