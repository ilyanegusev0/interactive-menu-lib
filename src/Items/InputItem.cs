using InteractiveMenu.Configuration;
using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    public class InputItem : MenuItem, ISelectable
    {
        // PROPERTIES
        public string Identificator { get; }

        public string Value { get; private set; }

        // CONTRUCTORS

        public InputItem(string text, string identificator) : base(text)
        {
            Identificator = identificator;
            Value = string.Empty;
        }

        // METHODS

        // override

        internal override IEnumerable<string> Render(MenuOptions options, bool isSelected)
        {
            yield return Text + Value;
        }

        // internal

        MenuResult? ISelectable.OnSelect(Menu menu)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(CursorLeft + Text.Length, CursorTop - 1);
            Value = Console.ReadLine();
            Console.CursorVisible = false;
            return null;
        }
    }
}