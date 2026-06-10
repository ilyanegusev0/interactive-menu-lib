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
            Format = "(%m)%t%s";
        }

        // METHODS

        // override

        internal override IEnumerable<string> Render(string selector)
        {
            char marker = IsChecked ? Marker : ' ';

            string formatted = Format
                .Replace("%m", marker.ToString())
                .Replace("%s", selector)
                .Replace("%t", Text);

            yield return formatted;
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