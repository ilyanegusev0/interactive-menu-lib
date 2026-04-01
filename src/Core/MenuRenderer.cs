using InteractiveMenu.Configuration;
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

                if (item is ISelectable && i == menu.SelectedIndex)
                    Console.ForegroundColor = _options.SelectedColor;
                else
                    Console.ForegroundColor = item.Color ?? _options.DefaultColor;


                if (item is EmptyItem emptyItem)
                {
                    for (int j = 0; j < emptyItem.Count; j++)
                        Console.WriteLine(string.Empty.PadRight(Console.WindowWidth));

                    continue;
                }

                if (_options.IsShowSelector && item is ISelectable && i == menu.SelectedIndex)
                    Console.WriteLine($"{item.Text}{_options.Selector}".PadRight(Console.WindowWidth));
                else
                    Console.WriteLine(item.Text.PadRight(Console.WindowWidth));
            }

            Console.ForegroundColor = previousColor;
        }
    }
}