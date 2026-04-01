using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    /// <summary>
    /// Provides a selectable menu item that returns an associated value.
    /// </summary>
    public class OptionItem : MenuItem, ISelectable
    {
        // PROPERTIES

        /// <summary>
        /// Gets the value associated with this option.
        /// </summary>
        public object? Value { get; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="OptionItem"/> with text, value, and color.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="value">The value returned when selected.</param>
        /// <param name="color">The foreground color.</param>
        public OptionItem(string text, object? value, ConsoleColor? color = null)
            : base(text, color)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="OptionItem"/> with text only.
        /// </summary>
        /// <param name="text">The display text.</param>
        public OptionItem(string text)
            : this(text, null, null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="OptionItem"/> with text and value.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="value">The value returned when selected.</param>
        public OptionItem(string text, object value)
            : this(text, value, null) { }

        /// <summary>
        /// Initializes a new instance of <see cref="OptionItem"/> with text and color.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="color">The foreground color.</param>
        public OptionItem(string text, ConsoleColor color)
            : this(text, null, color) { }

        // METHODS

        // internal

        object? ISelectable.OnSelect()
        {
            return Value;
        }
    }
}