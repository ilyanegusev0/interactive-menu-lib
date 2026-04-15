using InteractiveMenu.Configuration;

namespace InteractiveMenu.Items
{
    /// <summary>
    /// Provides the abstract base class for all menu items.
    /// </summary>
    public abstract class MenuItem
    {
        // PROPERTIES

        /// <summary>
        /// Gets the display text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the foreground color.
        /// </summary>
        public ConsoleColor? Color { get; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuItem"/>.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="color">Optional foreground color.</param>
        protected MenuItem(string text, ConsoleColor? color)
        {
            Text = text;
            Color = color;
        }

        // METHODS

        // internal

        internal abstract IEnumerable<string> Render(MenuOptions options, bool isSelected);
    }
}