using InteractiveMenu.Configuration;
using InteractiveMenu.Enums;

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
        /// Gets or sets the foreground color.
        /// </summary>
        public ConsoleColor? Color { get; set; }

        public MenuAlignment? Alignment { get; set; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuItem"/>.
        /// </summary>
        /// <param name="text">The display text.</param>
        protected MenuItem(string text)
        {
            Text = text;
        }

        // METHODS

        // internal

        internal abstract IEnumerable<string> Render(MenuOptions options, bool isSelected);
    }
}