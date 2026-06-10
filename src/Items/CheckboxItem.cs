using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    public class CheckboxItem : GroupItem, ISelectable
    {
        // CONSTRUCTORS

        public CheckboxItem(string text, string identificator, string group, bool isChecked = false) : base(text, identificator, group, isChecked)
        {
            Marker = 'x';
            Format = "(%m)%t%s";
        }

        // METHODS

        // internal

        MenuResult? ISelectable.OnSelect(Menu menu)
        {
            IsChecked = !IsChecked;

            return null;
        }
    }
}