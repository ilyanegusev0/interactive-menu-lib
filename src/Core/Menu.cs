using InteractiveMenu.Interfaces;
using InteractiveMenu.Items;

/// <summary>
/// Provides a menu container with navigation and selection logic.
/// </summary>
namespace InteractiveMenu.Core
{
    public class Menu
    {
        // PROPERTIES:

        /// <summary>
        /// Gets the list of menu items.
        /// </summary>
        public List<MenuItem> Items { get; }

        /// <summary>
        /// Gets the index of the selected item.
        /// </summary>
        public int SelectedIndex { get; internal set; }

        // CONSTRUCTORS:

        /// <summary>
        /// Initializes a new empty menu.
        /// </summary>
        public Menu()
        {
            Items = new List<MenuItem>();
        }

        /// <summary>
        /// Initializes a new menu with items.
        /// </summary>
        public Menu(params MenuItem[] items)
        {
            Items = items.ToList();
        }

        /// <summary>
        /// Initializes a new menu with items.
        /// </summary>
        public Menu(IEnumerable<MenuItem> items)
        {
            Items = items.ToList();
        }

        // METHODS:

        /// <summary>
        /// Adds a menu item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(MenuItem item)
        {
            Items.Add(item);
        }

        /// <summary>
        /// Adds a menu item at the specified index.
        /// </summary>
        /// <param name="index">The target index.</param>
        /// <param name="item">The item to add.</param>
        public void AddAt(int index, MenuItem item)
        {
            index = index < 0 ? Items.Count + index : index;

            Items.Insert(index, item);
        }

        /// <summary>
        /// Adds multiple menu items.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddRange(params MenuItem[] items)
        {
            Items.AddRange(items);
        }

        /// <summary>
        /// Adds multiple menu items.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddRange(IEnumerable<MenuItem> items)
        {
            Items.AddRange(items);
        }

        // <summary>
        /// Adds multiple menu items at the specified index.
        /// </summary>
        /// <param name="index">The target index.</param>
        /// <param name="items">The items to add.</param>
        public void AddRangeAt(int index, params MenuItem[] items)
        {
            index = index < 0 ? Items.Count + index : index;

            Items.InsertRange(index, items);
        }

        /// <summary>
        /// Adds multiple menu items at the specified index.
        /// </summary>
        /// <param name="index">The target index.</param>
        /// <param name="items">The items to add.</param>
        public void AddRangeAt(int index, IEnumerable<MenuItem> items)
        {
            index = index < 0 ? Items.Count + index : index;

            Items.InsertRange(index, items);
        }

        /// <summary>
        /// Replaces the item at the specified index.
        /// </summary>
        /// <param name="index">The target index.</param>
        /// <param name="item">The new item.</param>
        public void ReplaceAt(int index, MenuItem item)
        {
            index = index < 0 ? Items.Count + index : index;

            Items[index] = item;
        }

        /// <summary>
        /// Replaces a range of items.
        /// </summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        /// <param name="items">The new items.</param>
        public void ReplaceRange(int start, int end, params MenuItem[] items)
        {
            start = start < 0 ? Items.Count + start : start;
            end = end < 0 ? Items.Count + end : end;

            Items.RemoveRange(start, end - start + 1);

            Items.InsertRange(start, items);
        }

        /// <summary>
        /// Removes the first items.
        /// </summary>
        /// <param name="count">The number of items to remove.</param>
        public void RemoveFirst(int count)
        {
            Items.RemoveRange(0, count);
        }

        /// <summary>
        /// Removes the last items.
        /// </summary>
        /// <param name="count">The number of items to remove.</param>
        public void RemoveLast(int count)
        {
            Items.RemoveRange(Items.Count - count, count);
        }

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The target index.</param>
        public void RemoveAt(int index)
        {
            index = index < 0 ? Items.Count + index : index;

            Items.RemoveAt(index);
        }

        /// <summary>
        /// Removes a range of items starting at the specified index.
        /// </summary>
        /// <param name="index">The start index.</param>
        /// <param name="count">The number of items to remove.</param>
        public void RemoveRangeByCount(int index, int count)
        {
            index = index < 0 ? Items.Count + index : index;

            Items.RemoveRange(index, count);
        }

        /// <summary>
        /// Removes a range of items between indices.
        /// </summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        public void RemoveRangeByIndices(int start, int end)
        {
            start = start < 0 ? Items.Count + start : start;
            end = end < 0 ? Items.Count + end : end;

            Items.RemoveRange(start, end - start + 1);
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }

        // internal

        internal void SetSelectedIndexByNumber(int number)
        {
            if (number < 1)
                return;

            int count = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] is ISelectable)
                {
                    count++;
                    if (count == number)
                    {
                        SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        internal void Navigate(int direction)
        {
            if (Items.Count == 0)
                return;

            do
                SelectedIndex = (SelectedIndex + direction + Items.Count) % Items.Count;
            while (!(Items[SelectedIndex] is ISelectable));
        }

        internal MenuResult? Select()
        {
            var item = Items[SelectedIndex];

            if (item is ISelectable selectable)
                return selectable.OnSelect();

            return null;
        }
    }
}