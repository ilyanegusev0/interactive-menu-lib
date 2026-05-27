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
                bool isSelected = item is ISelectable && i == menu.SelectedIndex;

                Console.ForegroundColor = isSelected ? _options.SelectedColor : item.Color ?? _options.DefaultColor;

                foreach (string line in item.Render(_options, isSelected))
                {
                    string alignedLine = AlignText(item, line);
                    Console.WriteLine(alignedLine.PadRight(Console.WindowWidth));
                }
            }

            Console.ForegroundColor = previousColor;
        }

        // private

        private string AlignText(MenuItem item, string text)
        {
            int width = Console.WindowWidth;

            if (text.Length >= width)
                return text;

            switch (item.Alignment == null ? _options.Alignment : item.Alignment)
            {
                case MenuAlignment.Center:
                    return new string(' ', (width - text.Length) / 2) + text;

                case MenuAlignment.Right:
                    return new string(' ', width - text.Length) + text;

                default:
                    return text;
            }
        }
    }
}