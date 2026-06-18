using InteractiveMenu.Core;

namespace InteractiveMenu.Interfaces
{
    internal interface ISelectable
    {
        // PROPERTIES

        bool CloseMenu { get; set; }

        // METHODS

        MenuResult? OnSelect(Menu menu);
    }
}