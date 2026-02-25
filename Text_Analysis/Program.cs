using Microsoft.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using Text_Analysis;
using Text_Analysis.Model;

string userSelect = "";
do
{
    Console.Clear();
    //Главное меню
    ConsoleTitle("Text Analysis\n");
    Console.WriteLine("Select a text input method:");
    ConsoleButton("1");
    Console.WriteLine("Keyboard (only 1 text)");
    ConsoleButton("2");
    Console.WriteLine("File");
    Console.WriteLine("\nОther functions:");
    ConsoleButton("I");
    Console.WriteLine("for more Information about program");
    ConsoleButton("E");
    Console.WriteLine("for Exit");
    Console.Write("\nSelect: ");

    userSelect = Console.ReadLine();
    userSelect = userSelect.ToUpper();

    TextDataset texts = new TextDataset();

    switch (userSelect)
    {
        case "1":
            texts = TextInputKeyboard();
            AnalysisText(texts);
            break;
        case "2":
            texts = TextInputFile();
            AnalysisText(texts);
            break;
        case "I":
            Console.WriteLine("This application analyzes your text. \n" +
                "You provide a title and the content of the text.\n" +
                "As a result, you see the top words by frequency of usage and the percentage of unique words.\n" +
                "\nYou can use JSON file:\n" +
                "...Text_Analysis\\Dataset\\input.json");
            break;
        case "E":
            Environment.Exit(0);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The selected option was not found.\nPlease try again.");
            Console.ResetColor();
            break;
    }
    Console.ReadKey();
} while (userSelect != "E");


//Форматирование кнопок
static void ConsoleButton(string btn)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($" [{btn}] ");
    Console.ResetColor();

}

//Форматирование заголовков
static void ConsoleTitle(string title)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\n" + title);
    Console.ResetColor();

}

// Обработка текстов
static void AnalysisText(TextDataset texts)
{
    Console.Clear();
    foreach (var textItem in texts.Texts)
    {
        ConsoleTitle(textItem.Title);

        string text = textItem.Content;
        text = text.ToLowerInvariant();
        text = CleanText(text);

        List<string> wordList = text.Split(' ').ToList();

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (var word in wordList)
        {
            if (wordCount.ContainsKey(word)) wordCount[word]++;
            else wordCount[word] = 1;
        }

        var sortedBuiltIn = BuiltInSort(wordCount);

        var sortedBubbleSort = BubbleSort(wordCount);

    }
}

static TextDataset TextInputKeyboard()
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
static TextDataset TextInputFile()
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

//Подготовка текста
//В тексте остаются только буквы, апострофы внyтри слова и одиночные пробелы 
static string CleanText(string text)
{
    if (string.IsNullOrEmpty(text))
        return string.Empty;

    string cleaned = Regex.Replace(text, "[^a-zA-Zа-яА-ЯёЁ'\\s]", " ");
    cleaned = Regex.Replace(cleaned, "(?<=\\s|^)'|'(?=\\s|$)", "");
    cleaned = Regex.Replace(cleaned, "\\s+", " ");
    cleaned = cleaned.Trim();

    return cleaned;
}

//Встроенна сортировка
//Используются средства C# для сортировки
static List<KeyValuePair<string, int>> BuiltInSort(Dictionary<string, int> dictionary)
{
    return dictionary.OrderByDescending(pair => pair.Value).ToList();
}

//Сортировка пузырьком
static List<KeyValuePair<string, int>> BubbleSort(Dictionary<string, int> dictionary)
{
    var items = dictionary.ToArray();
    int n = items.Length;

    for (int i = 0; i < n - 1; i++)
    {
        bool swapped = false;

        for (int j = 0; j < n - i - 1; j++)
        {
            if (items[j].Value < items[j + 1].Value)
            {
                var temp = items[j];
                items[j] = items[j + 1];
                items[j + 1] = temp;
                swapped = true;
            }
        }

        if (!swapped)
            break;
    }

    return [.. items];
}

//Сортировка слиянием
static List<KeyValuePair<string, int>> MergeSort(Dictionary<string, int> dictionary)
{
    return new List<KeyValuePair<string, int>>();
}

//Сортировка Шелла
static List<KeyValuePair<string, int>> ShellSort(Dictionary<string, int> dictionary)
{
    return new List<KeyValuePair<string, int>>();
}

