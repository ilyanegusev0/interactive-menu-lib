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

        public virtual bool IsEnabled { get; set; }

        public bool IsVisible { get; set; }

        public string Format { get; set; }

        internal int CursorLeft { get; set; }

        internal int CursorTop { get; set; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuItem"/>.
        /// </summary>
        /// <param name="text">The display text.</param>
        protected MenuItem(string text)
        {
            Text = text;
            IsEnabled = true;
            IsVisible = true;
            Format = "%t%s";
        }

        // METHODS

        // internal

        internal virtual IEnumerable<string> Render(string selector)
        {
            string formatted = Format
                .Replace("%s", selector)
                .Replace("%t", Text);

            yield return formatted;
        }
    }
}