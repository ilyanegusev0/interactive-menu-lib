namespace InteractiveMenu.Configuration
{
    /// <summary>
    /// Defines key bindings for menu navigation and selection.
    /// </summary>
    public class MenuKeyBindings
    {
        // PROPERTIES

        /// <summary>
        /// Gets or sets the set of keys for moving up.
        /// </summary>
        public HashSet<ConsoleKey> KeyUpSet;

        /// <summary>
        /// Gets or sets the set of keys for moving down.
        /// </summary>
        public HashSet<ConsoleKey> KeyDownSet;

        /// <summary>
        /// Gets or sets the set of keys for selecting an item.
        /// </summary>
        public HashSet<ConsoleKey> KeySelectSet;

        /// <summary>
        /// Gets or sets the set of keys for canceling or exiting.
        /// </summary>
        public HashSet<ConsoleKey> KeyCancelSet;

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="MenuKeyBindings"/> with default keys.
        /// </summary>
        public MenuKeyBindings()
        {
            KeyUpSet = new HashSet<ConsoleKey>() { ConsoleKey.UpArrow, ConsoleKey.W };
            KeyDownSet = new HashSet<ConsoleKey>() { ConsoleKey.DownArrow, ConsoleKey.S };
            KeySelectSet = new HashSet<ConsoleKey>() { ConsoleKey.Enter };
            KeyCancelSet = new HashSet<ConsoleKey>() { ConsoleKey.Escape };
        }
    }
}