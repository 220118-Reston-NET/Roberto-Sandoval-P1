using StoreModel;
using StoreBL;

namespace StoreUI;

class ReplenishInventoryMenu : IMenu
{
    private static StoreFront _newStore =  new StoreFront();
    bool finishedSelecting = false;
    bool searchValidated = false;

    

    public void ShowMenu()
    {
        Console.WriteLine("Store Management System 2.0");
        Console.WriteLine("Enter Store Information");
        Console.WriteLine($"[4] Name: {_newStore.Name}");
        Console.WriteLine($"[3] Address: {_newStore.Address}");
        if(searchValidated)
            Console.WriteLine("[1] Replenish Selected Store");
        else
            Console.WriteLine("[2] Search For Inputted Store");
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
                return "ReplenishInventory";
            case "2":
                return "ReplenishInventory";
            case "3":
                return "ReplenishInventory";
            case "4":
                return "ReplinishInventory";
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "ReplenishInventory";
        }
        
    }

    public bool checkFilled()
    {
        throw new NotImplementedException();
    }
}