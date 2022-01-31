namespace StoreUI;

public class ViewInventoryMenu : IMenu
{

    public void ShowMenu()
    {
        Console.WriteLine("Store Management System 2.0");
        Console.WriteLine("Please Fill In the Following Information to do a Search");
        Console.WriteLine("[4] Store Name: ");
        Console.WriteLine("[3] Store Address");
        Console.WriteLine("[2] Start a Purchase for Costumer From Selected Store");
        Console.WriteLine("[1] Search");
        Console.WriteLine("[0] Return to Main Menu");
    }

    public string UserPick()
    {
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "0":
                return "MainMenu";
            case "1":
                return "ViewInventory";
            case "2":
                return "PlaceOrder";
            case "3":
                return "ViewInventory";
            case "4":
                return "ViewInventory";
            default:
                Console.WriteLine("You Have Entered an Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "ViewInventory";
        }
            
    }

    public bool checkFilled()
    {
        throw new NotImplementedException();
    }
}