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
            int n = 1;
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

                var top = GetTop(sortedBuiltIn);
                int totalCount = GetWordsCount(wordList);
                int uniqCount = GetUniqWordsCount(sortedBuiltIn);
                double uniqPercentage = GetUniqWordPercent(totalCount, uniqCount);

                TextHandlerService.TextOutputConsole(textItem.Title, top, totalCount, uniqCount, uniqPercentage);
                TextHandlerService.TextOutputFile(n, textItem.Title, top, totalCount, uniqCount, uniqPercentage);
                n++;
            }
        }

        //Подготовка текста
        //В тексте остаются только буквы, апострофы/дефисы внyтри слова и одиночные пробелы 
        public static string CleanText(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            text = text.ToLowerInvariant();

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string cleaned = Regex.Replace(text, "[^a-zA-Zа-яА-ЯёЁ'\\-\\s]", " ");
            cleaned = Regex.Replace(cleaned, "(?<=\\s|^)['-]|['-](?=\\s|$)", "");
            cleaned = Regex.Replace(cleaned, "\\s+", " ");
            cleaned = cleaned.Trim();

            return cleaned;
        }

        //Получить топ использования слов
        public static List<WordCount> GetTop(List<KeyValuePair<string, int>> list)
        {
            if (list == null || list.Count == 0)
                return new List<WordCount>();

            List<WordCount> TopWords = new List<WordCount>();
            int i = 0;
            for (int rank = 0; rank < 10 && i < list.Count; rank++)
            {
                TopWords.Add(new WordCount(list[i].Key, list[i].Value));
                while (i + 1 < list.Count && list[i].Value == list[i + 1].Value)
                {
                    TopWords.Add(new WordCount(list[i + 1].Key, list[i + 1].Value));
                    i++;
                }
                i++;
            }
            return TopWords;
        }

        //Получить общее количество слов
        public static int GetWordsCount(List<string> words)
        {
            if(words == null) return 0;
            return words.Count;
        }

        //Получить количество уникальных слов
        public static int GetUniqWordsCount(List<KeyValuePair<string, int>> list)
        {
            int uniqCount = 0;
            int n = list.Count - 1;
            while (n >= 0 && list[n].Value == 1)
            {
                uniqCount++;
                n--;
            }
            return uniqCount;
        }

        //Получить процент уникальных слов
        public static double GetUniqWordPercent(double totalCount, double uniqCount)
        {
            if (totalCount == 0)
                return 0;

            return uniqCount * 100.0 / totalCount;
        }


    }
}
