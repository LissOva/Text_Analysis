using Text_Analysis.Model;
using Text_Analysis.Services;

string userSelect = "";
do
{
    Console.Clear();
    //Главное меню
    FormattingService.ConsoleTitle("Text Analysis\n");
    Console.WriteLine("Select a text input method:");
    FormattingService.ConsoleButton("1");
    Console.WriteLine("Keyboard (only 1 text)");
    FormattingService.ConsoleButton("2");
    Console.WriteLine("File");
    Console.WriteLine("\nОther functions:");
    FormattingService.ConsoleButton("I");
    Console.WriteLine("for more Information about program");
    FormattingService.ConsoleButton("E");
    Console.WriteLine("for Exit");
    Console.Write("\nSelect: ");

    userSelect = Console.ReadLine();
    userSelect = userSelect.ToUpper();

    TextDataset texts = new TextDataset();

    switch (userSelect)
    {
        //Ввод с клавиатуры
        case "1":
            texts = TextLoaderService.TextInputKeyboard();
            TextAnalysisService.AnalysisText(texts);
            break;
        //Чтение с файла
        case "2":
            texts = TextLoaderService.TextInputFile();
            TextAnalysisService.AnalysisText(texts);
            break;
        //Информация о приложении
        case "I":
            Console.WriteLine("This application analyzes your text. \n" +
                "You provide a title and the content of the text.\n" +
                "As a result, you see the top words by frequency of usage and the percentage of unique words.\n" +
                "\nYou can use JSON file:\n" +
                "...Text_Analysis\\Dataset\\input.json");
            break;
        //Выход
        case "E":
            Environment.Exit(0);
            break;
        //Другие случаи
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The selected option was not found.\nPlease try again.");
            Console.ResetColor();
            break;
    }
    Console.ReadKey();
} while (userSelect != "E");
