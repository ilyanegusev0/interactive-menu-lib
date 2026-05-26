using InteractiveMenu.Core;
using InteractiveMenu.Items;
using InteractiveMenu.Configuration;

namespace InteractiveMenu.Demo.Minimal;

internal class Program
{

    static MenuRenderer renderer = new MenuRenderer();
    static MenuController controller = new MenuController(renderer);

    static void Main()
    {
        Menu menu = new Menu();

        List<MenuItem> items = new List<MenuItem>()
        {
            new TextItem("[ MAIN MENU ]"),
            new EmptyItem(),
            new OptionItem(" Start", "start"),
            new OptionItem(" Settings", "settings"),
            new EmptyItem(),
            new ActionItem(" Exit",  () => Environment.Exit(0)) { Color = ConsoleColor.Red },
        };

        menu.AddRange(items);

        object result = controller.Run(menu);

        switch (result)
        {
            case "start":
                Console.WriteLine("\nStart");
                break;

            case "settings":
                Console.WriteLine("\nSettings");
                break;
        }
    }
}