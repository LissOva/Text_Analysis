using Text_Analysis.Model;
using System.Text.Json;

namespace Text_Analysis.Services
{
    public class TextLoaderService
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
    }
}
