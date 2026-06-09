using InteractiveMenu.Configuration;
using InteractiveMenu.Interfaces;
using InteractiveMenu.Items;

namespace InteractiveMenu.Core
{
    /// <summary>
    /// Controls menu execution and user interaction.
    /// </summary>
    public class MenuController
    {
        // FIELDS

        private MenuRenderer _renderer;
        private MenuKeyBindings _bindings;

        // CONSTRUCTORS 

        /// <summary>
        /// Initializes a new instance of <see cref="MenuController"/> with a renderer.
        /// </summary>
        /// <param name="renderer">The menu renderer.</param>
        public MenuController(MenuRenderer renderer)
        {
            _renderer = renderer;
            _bindings = new MenuKeyBindings();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MenuController"/> with a renderer and key bindings.
        /// </summary>
        /// <param name="renderer">The menu renderer.</param>
        /// <param name="bindings">The key bindings.</param>
        public MenuController(MenuRenderer renderer, MenuKeyBindings bindings)
        {
            _renderer = renderer;
            _bindings = bindings;
        }

        // METHODS

        // public

        /// <summary>
        /// Runs the menu loop and returns the selected result.
        /// </summary>
        /// <param name="menu">The menu to run.</param>
        /// <returns>The result of the selected item, or null if canceled.</returns>
        public MenuResult? Run(Menu menu)
        {
            Console.CursorVisible = false;

            menu.SelectedIndex = menu.Items.FindIndex(i => menu.IsSelectable(i));
            int startRow = Console.GetCursorPosition().Top;

            NormalizeRadioGroups(menu);

            MenuResult? result = null;

            bool isRunning = true;
            while (isRunning)
            {
                _renderer.Render(menu, startRow);

                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case var k when k >= ConsoleKey.D1 && k <= ConsoleKey.D9:
                        menu.SetSelectedIndexByNumber(k - ConsoleKey.D1 + 1);
                        break;

                    case var k when k >= ConsoleKey.NumPad1 && k <= ConsoleKey.NumPad9:
                        menu.SetSelectedIndexByNumber(k - ConsoleKey.NumPad1 + 1);
                        break;

                    case var k when _bindings.KeyUpSet.Contains(k):
                        menu.Navigate(-1);
                        break;

                    case var k when _bindings.KeyDownSet.Contains(k):
                        menu.Navigate(1);
                        break;

                    case var k when _bindings.KeySelectSet.Contains(k):
                        result = menu.Select();
                        if (result != null)
                            isRunning = false;
                        break;

                    case var k when _bindings.KeyCancelSet.Contains(k):
                        result = new MenuResult.CancelResult();
                        isRunning = false;
                        break;
                }
            }

            Console.CursorVisible = true;

            return result;
        }

        // private

        private void NormalizeRadioGroups(Menu menu)
        {
            var groups = menu.Items
                .OfType<RadioItem>()
                .GroupBy(r => r.Group);

            foreach (var group in groups)
            {
                var lastChecked = group
                    .Where(r => r.IsVisible)
                    .LastOrDefault(r => r.IsChecked);

                if (lastChecked != null)
                {
                    foreach (var radio in group)
                        radio.IsChecked = false;

                    lastChecked.IsChecked = true;
                }
            }
        }
    }
}