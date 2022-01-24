namespace StoreUI
{
    public class SnackMenu : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("These are our snacks!");
            Console.WriteLine("Cheetos, Angus Burger, Polish Hot Dog, M&Ms, Kit-Kats, Peach Sweet Tea,");

            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[0] Exit to Main Menu");
        }

        public string UserPick()
        {
            string pickedChoice = Console.ReadLine();

            switch (pickedChoice)
            {
                case "0":
                    return "MainMenu";
                default:
                    Console.WriteLine("You have chosen an invalid pick");
                    return "MainMenu";

            }
        }
    }
}