using InteractiveMenu.Configuration;
using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    /// <summary>
    /// Provides a menu item that executes a delegate when selected.
    /// </summary>
    public class ActionItem : MenuItem, ISelectable
    {
        // FIELDS

        private readonly Delegate _action;

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of <see cref="ActionItem"/> with a delegate.
        /// </summary>
        /// <param name="text">The display text.</param>
        /// <param name="action">The delegate to execute.</param>
        public ActionItem(string text, Delegate action)
            : base(text)
        {
            _action = action;
        }

        // METHODS

        // internal

        internal override IEnumerable<string> Render(MenuOptions options, bool isSelected)
        {
            yield return isSelected ? Text + options.Selector : Text;
        }

        MenuResult? ISelectable.OnSelect(Menu menu)
        {
            return new MenuResult.ActionResult(_action.DynamicInvoke());
        }
    }
}