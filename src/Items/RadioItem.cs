using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    public class RadioItem : GroupItem, ISelectable
    {
        // PROPERTIES

        public bool CloseMenu { get; set; }

        // CONSTRUCTORS

        public RadioItem(string text, string identificator, string group, bool isChecked = false) : base(text, identificator, group, isChecked)
        {
            Marker = '*';
            Format = "(%m)%t%s";
            CloseMenu = false;
        }

        // METHODS

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