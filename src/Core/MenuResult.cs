namespace InteractiveMenu.Core
{
    /// <summary>
    /// Represents the result of a menu interaction.
    /// </summary>
    public abstract record class MenuResult
    {
        /// <summary>
        /// The user selected an option with an associated value.
        /// </summary>
        public sealed record OptionResult(object Value) : MenuResult;

        /// <summary>
        /// The user triggered an action that returned a value (or null).
        /// </summary>
        public sealed record ActionResult(object Value) : MenuResult;

        /// <summary>
        /// The user cancelled the menu (e.g., pressed Escape).
        /// </summary>
        public sealed record CancelResult : MenuResult;
    }
}