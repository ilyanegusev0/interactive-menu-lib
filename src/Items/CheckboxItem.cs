using InteractiveMenu.Configuration;
using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    public class CheckboxItem : GroupItem, ISelectable
    {
        // CONSTRUCTORS

        public CheckboxItem(string text, string identificator, string group = null) : base(text, identificator, group)
        {
            Marker = 'x';
        }

        // METHODS

        // override

        internal override IEnumerable<string> Render(MenuOptions options, bool isSelected)
        {
            char marker = IsChecked ? Marker : ' ';
            string selector = isSelected ? options.Selector : string.Empty;

            yield return $"[{marker}]{Text}{selector}";
        }

        // internal

        MenuResult? ISelectable.OnSelect(Menu menu)
        {
            IsChecked = !IsChecked;

            return null;
        }
    }
}