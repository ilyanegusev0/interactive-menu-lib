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
            ConsoleColor previousBg = Console.BackgroundColor;

            Console.SetCursorPosition(0, startRow);

            for (int i = 0; i < menu.Items.Count; i++)
            {
                MenuItem item = menu.Items[i];

                if (!item.IsVisible)
                    continue;

                bool isSelected = item is ISelectable && i == menu.SelectedIndex;
                bool isSelectable = menu.IsSelectable(item);
                string selector = isSelected ? _options.Selector : string.Empty;

                ConsoleColor color;
                ConsoleColor? background;
                if (!item.IsEnabled)
                {
                    color = _options.DisabledColor;
                    background = _options.DisabledBackgroundColor;
                }
                else if (isSelected && isSelectable)
                {
                    color = _options.SelectedColor;
                    background = _options.SelectedBackgroundColor;
                }
                else
                {
                    color = item.Color ?? _options.DefaultColor;
                    background = _options.DefaultBackgroundColor;
                }

                var lines = item.Render(selector).ToList();

                if (lines.Count < 1)
                    continue;

                var alignment = item.Alignment ?? _options.Alignment;

                Console.ForegroundColor = color;
                Console.BackgroundColor = background ?? previousBg;
                foreach (string line in lines)
                {
                    string alignedLine = AlignText(line, alignment, out int padding);

                    item.CursorLeft = padding;
                    item.CursorTop = Console.CursorTop;

                    Console.WriteLine(alignedLine.PadRight(Console.WindowWidth));
                }

                
            }

            Console.ForegroundColor = previousColor;
            Console.BackgroundColor = previousBg;
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