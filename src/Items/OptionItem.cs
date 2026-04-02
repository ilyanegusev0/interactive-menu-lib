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
        public object Value { get; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="OptionItem"/> with text, value, and color.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="value">The value returned when selected.</param>
        /// <param name="color">The foreground color.</param>
        public OptionItem(string text, object value, ConsoleColor? color = null)
            : base(text, color)
        {
            Value = value;
        }

        // METHODS

        // internal

        object ISelectable.OnSelect()
        {
            return Value;
        }
    }
}