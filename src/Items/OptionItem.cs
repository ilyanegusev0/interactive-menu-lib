using InteractiveMenu.Core;
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

        public bool CloseMenu { get; set; }

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="OptionItem"/> with text and value.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="value">The value returned when selected.</param>
        public OptionItem(string text, object value)
            : base(text)
        {
            Value = value;
            CloseMenu = true;
        }

        // METHODS

        // internal

        MenuResult ISelectable.OnSelect(Menu menu)
        {
            return new MenuResult.OptionResult(Value);
        }
    }
}