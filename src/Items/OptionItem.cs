using InteractiveMenu.Configuration;
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
        }

        // METHODS

        // internal

        internal override IEnumerable<string> Render(MenuOptions options, bool isSelected)
        {
            yield return options.IsShowSelector && isSelected ? Text + options.Selector : Text;
        }

        MenuResult ISelectable.OnSelect()
        {
            return new MenuResult.OptionResult(Value);
        }
    }
}