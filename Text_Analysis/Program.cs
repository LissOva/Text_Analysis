using Microsoft.CodeAnalysis;
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
foreach (var text in texts.Texts)
{
    Console.WriteLine($"Title: {text.Title}");
    Console.WriteLine($"Content: {text.Content}\n");
}

//string text = "";
////rawText = Console.ReadLine();

//text = "The sorting algorithm is important for text analysis. Sorting helps to organize words by frequency. The algorithm must be efficient and fast. Bubble sort is simple but slow. Merge sort is fast and stable. Shell sort is interesting and useful. The built-in sort is optimized and reliable. I love sorting algorithms because they are fundamental. Sorting text data requires clean preprocessing. The text must be cleaned before sorting. Words should be counted first then sorted. The frequency determines the order. High frequency words appear first. Low frequency words appear last. Sorting is essential for analysis. The algorithm choice affects performance. Performance matters for large texts. Large texts need efficient sorting. Efficient algorithms save time and memory. Memory usage is critical for big data. Big data requires smart algorithms. Smart algorithms make programs fast";
//Console.WriteLine(text + "\n");

//text = text.ToLowerInvariant();
//text = CleanText(text);

//List<string> wordList = text.Split(' ').ToList();

//Console.WriteLine(string.Join(" ", wordList) + "\n");

//Dictionary<string, int> wordCount = new Dictionary<string, int>();

//foreach (var word in wordList)
//{
//    if (wordCount.ContainsKey(word)) wordCount[word]++;
//    else wordCount[word] = 1;
//}

//var sortedByValueDesc = BuiltInSort(wordCount);

//Console.WriteLine(string.Join("\n", sortedByValueDesc));

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
//В тексте остаются только буквы, апострофы внитри слова и одиночные пробелы 
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
static List<KeyValuePair<string, int>> BuiltInSort(Dictionary<string, int> dictonary)
{
    return dictonary.OrderByDescending(pair => pair.Value).ToList();
}

//Сортировка пузырьком
static List<KeyValuePair<string, int>> BubbleSort(Dictionary<string, int> dictonary)
{
    return new List<KeyValuePair<string, int>>();
}

//Сортировка Шелла
static List<KeyValuePair<string, int>> Shellsort(Dictionary<string, int> dictonary)
{
    return new List<KeyValuePair<string, int>>();
}

//Сортировка слиянием
static List<KeyValuePair<string, int>> MergeSort(Dictionary<string, int> dictonary)
{
    return new List<KeyValuePair<string, int>>();
}
