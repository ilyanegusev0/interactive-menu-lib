using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    public class InputItem : MenuItem, ISelectable
    {
        // PROPERTIES
        public string Identificator { get; }

        public string Value { get; private set; }

        public bool CloseMenu { get; set; }

        // CONTRUCTORS

        public InputItem(string text, string identificator) : base(text)
        {
            Identificator = identificator;
            Value = string.Empty;
            Format = "%t%v%s";
            CloseMenu = false;
        }

        // METHODS

        // override

        internal override IEnumerable<string> Render(string selector)
        {
            string formatted = Format
                .Replace("%s", selector)
                .Replace("%t", Text)
                .Replace("%v", Value);

            yield return formatted;
        }

        // internal

        MenuResult? ISelectable.OnSelect(Menu menu)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(CursorLeft + Text.Length, CursorTop);
            Console.Write(new string(' ', Console.WindowWidth - Text.Length));
            Console.SetCursorPosition(CursorLeft + Text.Length, CursorTop);
            Value = Console.ReadLine();
            Console.CursorVisible = false;
            return null;
        }
    }
}