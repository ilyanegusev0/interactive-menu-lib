namespace InteractiveMenu.Items
{
    public abstract class GroupItem : MenuItem
    {
        // PROPERTIES

        public string Identificator { get; }
        public string Group { get; }
        public bool IsChecked { get; internal set; }
        public char Marker { get; protected set; }

        // CONSTRUCTORS

        public GroupItem(string text, string identificator, string group) : base(text)
        {
            Identificator = identificator;
            Group = group;
            IsChecked = false;
        }
    }
}