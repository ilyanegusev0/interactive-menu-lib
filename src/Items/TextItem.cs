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
        public TextItem(string text)
            : base(text) { }
    }
}