using InteractiveMenu.Core;
using InteractiveMenu.Interfaces;

namespace InteractiveMenu.Items
{
    public class CheckboxItem : GroupItem, ISelectable
    {
        // PROPERTIES

        public bool CloseMenu { get; set; }

        // CONSTRUCTORS

        public CheckboxItem(string text, string identificator, string group, bool isChecked = false) : base(text, identificator, group, isChecked)
        {
            Marker = 'x';
            Format = "[%m]%t%s";
            CloseMenu = false;
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