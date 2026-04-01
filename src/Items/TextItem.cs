namespace InteractiveMenu.Items
{
    /// <summary>
    /// Provides a menu item that displays static text.
    /// </summary>
    public class TextItem : MenuItem
    {
        // CONSTRUCTORS:

        /// <summary>
        /// Initializes a new instance of <see cref="TextItem"/>.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="color">Optional foreground color.</param>
        public TextItem(string text, ConsoleColor? color = null)
            : base(text, color) { }
    }
}