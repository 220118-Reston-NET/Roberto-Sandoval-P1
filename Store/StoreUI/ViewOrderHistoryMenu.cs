namespace StoreUI;

class ViewORderHistoryMenu : IMenu
{
    bool frameSelected = false;
    bool selectedCostumer = false;
    bool selectedStore = false;
    public void ShowMenu()
    {
        Console.WriteLine("Store Management System 2.0");

        if (frameSelected && selectedCostumer)
        {
            Console.WriteLine("");
        }
        else if (frameSelected && selectedStore)
        {

        }

        Console.WriteLine("Please Select Search Type");
        Console.WriteLine("[] Costumer");
        Console.WriteLine("[] Store");
        Console.WriteLine("[0] Main Menu");
    }

    public string UserPick()
    {
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "0":
                return "MainMenu";
            case "1":
                return "ViewOrderHistoryMenu";
            case "2":
                return "ViewOrderHistoryMenu";
            case "3":
                return "ViewOrderHistoryMenu";
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "ViewOrderHistoryMenu";
        }
        
    }
}