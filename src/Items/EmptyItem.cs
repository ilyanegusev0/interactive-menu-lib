using InteractiveMenu.Configuration;

namespace InteractiveMenu.Items
{
    /// <summary>
    /// Provides a menu item that renders empty space.
    /// </summary>
    public class EmptyItem : MenuItem
    {
        // PROPERTIES

        /// <summary>
        /// Gets the number of empty lines.
        /// </summary>
        public int Count { get; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="EmptyItem"/> with one empty line.
        /// </summary>
        public EmptyItem()
            : base(string.Empty, null)
        {
            Count = 1;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EmptyItem"/> with a specified count.
        /// </summary>
        /// <param name="count">The number of empty lines.</param>
        public EmptyItem(int count)
            : base(string.Empty, null)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException();

            Count = count;
        }

        // METHODS

        //internal

        internal override IEnumerable<string> Render(MenuOptions options, bool isSelected)
        {
            for (int i = 0; i < Count; i++)
                yield return string.Empty;
        }
    }
}