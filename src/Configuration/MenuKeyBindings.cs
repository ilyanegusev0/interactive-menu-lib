namespace InteractiveMenu.Configuration
{
    /// <summary>
    /// Defines key bindings for menu navigation and selection.
    /// </summary>
    public class MenuKeyBindings
    {
        // PROPERTIES

        /// <summary>
        /// Gets or sets the key for moving up.
        /// </summary>
        public ConsoleKey KeyUp;

        /// <summary>
        /// Gets or sets the key for moving down.
        /// </summary>
        public ConsoleKey KeyDown;

        /// <summary>
        /// Gets or sets the key for selecting an item.
        /// </summary>
        public ConsoleKey KeySelect;

        /// <summary>
        /// Gets or sets the key for canceling or exiting.
        /// </summary>
        public ConsoleKey KeyCancel;

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuKeyBindings"/> with default keys.
        /// </summary>
        public MenuKeyBindings()
        {
            KeyUp = ConsoleKey.UpArrow;
            KeyDown = ConsoleKey.DownArrow;
            KeySelect = ConsoleKey.Enter;
            KeyCancel = ConsoleKey.Escape;
        }
    }
}
