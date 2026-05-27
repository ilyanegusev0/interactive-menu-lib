using InteractiveMenu.Enums;

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
        /// Gets or sets the color for selected items.
        /// </summary>
        public ConsoleColor SelectedColor;

        /// <summary>
        /// Gets or sets the symbol used to mark the selected item.
        /// </summary>
        public string Selector;

        public MenuAlignment Alignment;

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuOptions"/> with default values.
        /// </summary>
        public MenuOptions()
        {
            DefaultColor = ConsoleColor.Gray;
            SelectedColor = ConsoleColor.Green;
            Selector = " <";
            Alignment = MenuAlignment.Center;
        }
    }
}
