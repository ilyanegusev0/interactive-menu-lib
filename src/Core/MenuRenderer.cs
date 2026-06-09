using InteractiveMenu.Configuration;
using InteractiveMenu.Enums;
using InteractiveMenu.Interfaces;
using InteractiveMenu.Items;

namespace InteractiveMenu.Core
{
    /// <summary>
    /// Provides rendering of menu items in the console.
    /// </summary>
    public class MenuRenderer
    {
        // FIELDS

        private MenuOptions _options;

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuRenderer"/> with default options.
        /// </summary>
        public MenuRenderer()
        {
            _options = new MenuOptions();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MenuRenderer"/> with specified options.
        /// </summary>
        /// <param name="options">The rendering options.</param>
        public MenuRenderer(MenuOptions options)
        {
            _options = options;
        }

        // METHODS

        // internal

        internal void Render(Menu menu, int startRow)
        {
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.SetCursorPosition(0, startRow);

            for (int i = 0; i < menu.Items.Count; i++)
            {
                MenuItem item = menu.Items[i];

                if (!item.IsVisible)
                    continue;

                bool isSelected = item is ISelectable && i == menu.SelectedIndex;
                bool isSelectable = menu.IsSelectable(item);

                if (!item.IsEnabled)
                    Console.ForegroundColor = _options.DisabledColor;
                else if (isSelected && isSelectable)
                    Console.ForegroundColor = _options.SelectedColor;
                else
                    Console.ForegroundColor = item.Color ?? _options.DefaultColor;  

                var lines = item.Render(_options, isSelected).ToList();

                if (lines.Count < 1)
                    continue;

                var alignment = item.Alignment ?? _options.Alignment;
                int padding = 0;

                foreach (string line in lines)
                {
                    string alignedLine = AlignText(line, alignment, out padding);
                    Console.WriteLine(alignedLine.PadRight(Console.WindowWidth));
                }

                item.CursorLeft = padding;
                item.CursorTop = Console.CursorTop;
            }

            Console.ForegroundColor = previousColor;
        }

        // private

        private string AlignText(string text, MenuAlignment alignment, out int padding)
        {
            int width = Console.WindowWidth;
            padding = 0;

            if (text.Length >= width)
                return text;

            switch (alignment)
            {
                case MenuAlignment.Center:
                    padding = (width - text.Length) / 2;
                    break;

                case MenuAlignment.Right:
                    padding = width - text.Length;
                    break;
            }

            return new string(' ', padding) + text;
        }
    }
}