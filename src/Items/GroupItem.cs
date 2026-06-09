namespace InteractiveMenu.Items
{
    public abstract class GroupItem : MenuItem
    {
        // FIELDS

        private bool _isEnabled;

        // PROPERTIES

        public override bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;

                if (!_isEnabled)
                    IsChecked = false;
            }
        }

        public string Identificator { get; }

        public string Group { get; }

        public bool IsChecked { get; internal set; }

        public char Marker { get; protected set; }

        // CONSTRUCTORS

        public GroupItem(string text, string identificator, string group, bool isChecked) : base(text)
        {
            Identificator = identificator;
            Group = group;
            IsChecked = isChecked;
        }
    }
}