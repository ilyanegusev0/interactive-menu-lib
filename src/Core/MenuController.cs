using InteractiveMenu.Configuration;
using InteractiveMenu.Interfaces;

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
        public object? Run(Menu menu)
        {
            Console.CursorVisible = false;

            menu.SelectedIndex = menu.Items.FindIndex(i => i is ISelectable);
            int startRow = Console.GetCursorPosition().Top;

            object? result = null;

            bool isRunning = true;
            while (isRunning)
            {
                _renderer.Render(menu, startRow);

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case var k when k == _bindings.KeyUp:
                        menu.Navigate(-1);
                        break;

                    case var k when k == _bindings.KeyDown:
                        menu.Navigate(1);
                        break;

                    case var k when k == _bindings.KeySelect:
                        result = menu.Select();
                        isRunning = false;
                        break;

                    case var l when key == _bindings.KeyCancel:
                        isRunning = false;
                        break;
                }
            }

            Console.CursorVisible = true;
            return result;
        }
    }
}