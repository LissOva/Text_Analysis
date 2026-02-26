namespace Text_Analysis.Services
{
    public class FormattingService
    {
        //Форматирование кнопок
        public static void ConsoleButton(string btn)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" [{btn}] ");
            Console.ResetColor();

        }

        //Форматирование заголовков
        public static void ConsoleTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(title);
            Console.ResetColor();

        }
        //Выделение слов
        public static void ConsoleHighlight(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Console.ResetColor();

        }

    }
}
