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
        /// Gets or sets the symbol used to mark the selected item.
        /// </summary>
        public string Selector { get; set; }

        // <summary>
        /// Gets or sets the alignment of menu items (Left, Center, Right).
        /// Default is <see cref="MenuAlignment.Left"/>.
        /// </summary>
        public MenuAlignment Alignment { get; set; }

        /// <summary>
        /// Foreground color for non-selected items.
        /// </summary>
        public ConsoleColor DefaultColor { get; set; }

        /// <summary>
        /// Foreground color for selected items.
        /// </summary>
        public ConsoleColor SelectedColor { get; set; }

        /// <summary>
        /// Foreground color for disabled items.
        /// </summary>
        public ConsoleColor DisabledColor { get; set; }

        /// <summary>
        /// Background color for normal items.
        /// </summary>
        public ConsoleColor? DefaultBackgroundColor { get; set; }

        /// <summary>
        /// Background color for the selected item.
        /// </summary>
        public ConsoleColor? SelectedBackgroundColor { get; set; }

        /// <summary>
        /// Background color for disabled items.
        /// </summary>
        public ConsoleColor? DisabledBackgroundColor { get; set; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuOptions"/> with default values.
        /// </summary>
        public MenuOptions()
        {
            Selector = " <";
            Alignment = MenuAlignment.Left;

            DefaultColor = ConsoleColor.Gray;
            SelectedColor = ConsoleColor.Green;
            DisabledColor = ConsoleColor.DarkGray;

            DefaultBackgroundColor = null;
            SelectedBackgroundColor = null;
            DisabledBackgroundColor = null;
        }
    }
}
