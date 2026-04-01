namespace InteractiveMenu.Configuration
{
    /// <summary>
    /// Defines appearance options for menu rendering.
    /// </summary>
    public class MenuOptions
    {
        // PROPERTIES

        /// <summary>
        /// Gets or sets the color for non-selected items.
        /// </summary>
        public ConsoleColor DefaultColor;

        /// <summary>
        /// Gets or sets the color for non-selected items.
        /// </summary>
        public ConsoleColor SelectedColor;

        /// <summary>
        /// Gets or sets a value indicating whether a selector symbol is shown.
        /// </summary>
        public bool IsShowSelector;

        /// <summary>
        /// Gets or sets the symbol used to mark the selected item.
        /// </summary>
        public string Selector;

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuOptions"/> with default values.
        /// </summary>
        public MenuOptions()
        {
            DefaultColor = ConsoleColor.Gray;
            SelectedColor = ConsoleColor.Green;
            IsShowSelector = true;
            Selector = " <";
        }
    }
}
