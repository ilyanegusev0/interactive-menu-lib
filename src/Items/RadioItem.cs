using InteractiveMenu.Configuration;
using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    public class RadioItem : GroupItem, ISelectable
    {
        // CONSTRUCTORS

        public RadioItem(string text, string identificator, string group, bool isChecked = false) : base(text, identificator, group, isChecked)
        {
            Marker = '*';
        }

        // METHODS

        // override

        internal override IEnumerable<string> Render(MenuOptions options, bool isSelected)
        {
            char marker = IsChecked ? Marker : ' ';
            string selector = isSelected ? options.Selector : string.Empty;

            yield return $"({marker}) {Text}{selector}";
        }

        // internal

        MenuResult? ISelectable.OnSelect(Menu menu)
        {
            var group = menu.Items
                .OfType<RadioItem>()
                .Where(r => r.Group == Group);

            foreach (var r in group)
                r.IsChecked = false;

            IsChecked = true;

            return null;
        }
    }
}