namespace Labb_1___LINQ.utils;

public class Menu(string[] options)
{
    public string[] Options { get; set; } = options;
    private int SelectedOption = 0;

    public int Show()
    {
        bool isSelected = false;
        Console.WriteLine("Press arrow up and down to navigate. Select with enter");
        (int Left, int Top) = Console.GetCursorPosition();

        while (!isSelected)
        {
            for (int i = 0; i < Options.Length; i++)
            {
                Console.SetCursorPosition(Left, Top + i);
                var Option = Options[i];
                Console.WriteLine(SelectedOption == i ? $"\u001b[32m{Option}\u001b[0m" : Option);
            }
            var Key = Console.ReadKey().Key;

            switch (Key)
            {
                case ConsoleKey.UpArrow:
                    SelectedOption = SelectedOption <= 0 ? Options.Length - 1 : SelectedOption - 1;

                    break;
                case ConsoleKey.DownArrow:
                    SelectedOption = SelectedOption < Options.Length - 1 ? ++SelectedOption : SelectedOption = 0;
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    break;
            }
        }
        return SelectedOption;
    }
}
