using System.Text.RegularExpressions;
using Text_Analysis.Model;

namespace Text_Analysis.Services
{
    public class TextAnalysisService
    {
        // Обработка текстов
        public static void AnalysisText(TextDataset texts)
        {
            Console.Clear();
            foreach (var textItem in texts.Texts)
            {
                string text = textItem.Content;
                text = CleanText(text);

                List<string> wordList = text.Split(' ').ToList();

                Dictionary<string, int> wordCount = new Dictionary<string, int>();

                foreach (var word in wordList)
                {
                    if (wordCount.ContainsKey(word)) wordCount[word]++;
                    else wordCount[word] = 1;
                }
                var sortedBuiltIn = SortingService.BuiltInSort(wordCount);
                //var sortedBubbleSort = SortingService.BubbleSort(wordCount);
                //var sortedMergeSort = SortingService.MergeSort(wordCount);
                //var sortedShellSort = SortingService.ShellSort(wordCount);

                Console.Write(new string(' ', (38 - textItem.Title.Length) / 2));
                FormattingService.ConsoleTitle(textItem.Title);
                ConsoleTopWrite(sortedBuiltIn);
                ConsoleStatisticsWrite(wordList, sortedBuiltIn);
            }
        }

        //Подготовка текста
        //В тексте остаются только буквы, апострофы/дефисы внyтри слова и одиночные пробелы 
        internal static string CleanText(string text)
        {
            text = text.ToLowerInvariant();

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string cleaned = Regex.Replace(text, "[^a-zA-Zа-яА-ЯёЁ'\\-\\s]", " ");
            cleaned = Regex.Replace(cleaned, "(?<=\\s|^)['-]|['-](?=\\s|$)", "");
            cleaned = Regex.Replace(cleaned, "\\s+", " ");
            cleaned = cleaned.Trim();

            return cleaned;
        }

        //Вывести топ использования слов
        internal static void ConsoleTopWrite(List<KeyValuePair<string, int>> list)
        {
            const int rankWidth = 3;
            const int wordWidth = 20;
            const int countWidth = 5;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{"#",3}    {"Word",-20}    {"Count",5}");
            Console.WriteLine(new string('-', 38));
            Console.ResetColor();

            int i = 0;
            for (int rank = 0; rank < 10; rank++)
            {
                Console.WriteLine($"{rank + 1,rankWidth}    {list[i].Key,-wordWidth}    {list[i].Value,countWidth}");
                if (list[i].Value == list[i + 1].Value)
                {
                    while (list[i].Value == list[i + 1].Value)
                    {
                        Console.WriteLine($"{" ",rankWidth}    {list[i + 1].Key,-wordWidth}    {list[i + 1].Value,countWidth}");
                        i++;
                    }
                }
                i++;
            }
        }
        
        //Вывести общую статистику

        internal static void ConsoleStatisticsWrite(List<string> words, List<KeyValuePair<string, int>> list)
        {
            FormattingService.ConsoleHighlight("Total number of words: ");
            Console.WriteLine(GetWordsCount(words));
            FormattingService.ConsoleHighlight("Unique words: ");
            Console.WriteLine(CountUniqWords(list));
            FormattingService.ConsoleHighlight("Percentage of unique words: ");
            Console.WriteLine($"{Math.Round(CountUniqWordPercent(GetWordsCount(words), CountUniqWords(list)), 2)}%");
        }
        
        //Получить общее количество слов
        internal static int GetWordsCount(List<string> words)
        {
            return words.Count;
        }

        //Получить количество уникальных слов
        internal static int CountUniqWords(List<KeyValuePair<string, int>> list)
        {
            int uniqCount = 0;
            int n = list.Count - 1;
            while (list[n].Value == 1)
            {
                uniqCount++;
                n--;
            }
            return uniqCount;
        }

        //Получить процент уникальных слов
        internal static double CountUniqWordPercent(double totalCount, double uniqCount)
        {
            return uniqCount * 100.0 / totalCount;
        }

        
    }
}
