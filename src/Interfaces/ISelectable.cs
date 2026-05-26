using InteractiveMenu.Core;

namespace InteractiveMenu.Interfaces
{
    internal interface ISelectable
    {
        MenuResult OnSelect();
    }
}