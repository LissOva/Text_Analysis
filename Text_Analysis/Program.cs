using Microsoft.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using Text_Analysis;
using Text_Analysis.Model;

Console.Write(
"Text Analysis\n" +
"Select a text input method:\n" +
"1 Keyboard (only 1 text)\n" +
"2 File\n" +
"Select: "
 );

int userSelect = Convert.ToInt32(Console.ReadLine());

TextDataset texts = new TextDataset();

switch (userSelect)
{
    case 1:
        texts = TextInputKeyboard();
        break;
    case 2:
        texts = TextInputFile();
        break;
    default:
        break;
}

// Обработка текстов
foreach (var textItem in texts.Texts)
{
    Console.WriteLine($"Text Analysis: {textItem.Title}");
    Console.WriteLine($"Result:");

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

    var sortedBubbleSort= BubbleSort(wordCount);

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
     "texts.json"
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
    // Преобразуем словарь в массив для сортировки
    var items = dictionary.ToArray();
    int n = items.Length;

    // Сортировка пузырьком по убыванию значения
    for (int i = 0; i < n - 1; i++)
    {
        bool swapped = false;

        for (int j = 0; j < n - i - 1; j++)
        {
            // Сравниваем по значению - сортируем по убыванию
            if (items[j].Value < items[j + 1].Value)
            {
                // Меняем местами
                var temp = items[j];
                items[j] = items[j + 1];
                items[j + 1] = temp;
                swapped = true;
            }
        }

        // Если не было обменов — массив уже отсортирован
        if (!swapped)
            break;
    }

    return new List<KeyValuePair<string, int>>(items);
}

//Сортировка слиянием
static List<KeyValuePair<string, int>> MergeSort(Dictionary<string, int> dictionary)
{
    return new List<KeyValuePair<string, int>>();
}

//Сортировка Шелла
static List<KeyValuePair<string, int>> Shellsort(Dictionary<string, int> dictionary)
{
    return new List<KeyValuePair<string, int>>();
}