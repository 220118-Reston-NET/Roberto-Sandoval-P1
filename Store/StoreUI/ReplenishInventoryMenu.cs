using StoreModel;
using StoreBL;

namespace StoreUI;

class ReplenishInventoryMenu : IMenu
{
    private static StoreFront _newStore =  new StoreFront();
    bool finishedSelecting = false;
    bool searchValidated = false;

    private IStoreFrontBL _storeFrontBL;
    public ReplenishInventoryMenu(IStoreFrontBL p_storeFrontBL)
    {
        _storeFrontBL = p_storeFrontBL;
    }


    public void ShowMenu()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("           Store Management System 2.0  ");
        Console.WriteLine("==================================================");
        Console.WriteLine();
        Console.WriteLine("             Enter Store Information\n");
        Console.WriteLine($"             <4> Name: {_newStore.StoreName}");
        Console.WriteLine($"             <3> Address: {_newStore.StoreAddress}");
        Console.WriteLine("             <2> Replenish Selected Store");
        //Console.WriteLine("             <1> List Items to Add to Store Inventory");
        Console.WriteLine("             <0> Return to Main Menu\n\n");
        Console.Write(" Choice: ");
        
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
                Console.WriteLine("Please Enter Store Address");
                _newStore.StoreAddress = Console.ReadLine();
                return "ReplenishInventory";
            case "4":
                Console.WriteLine("Please Enter Store Name");
                _newStore.StoreName = Console.ReadLine();
                return "ReplinishInventory";
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "ReplenishInventory";
        }
        
    }

    public void processInput()
    {
        if (_newStore.StoreName != ".StoreName" && _newStore.StoreAddress != ".StoreAddress")
        {
            _storeFrontBL.findStore(_newStore);
        }
        else
        {
            Console.WriteLine("Please Finish FIlling in Store Details");
            Console.WriteLine("Press ENTER t ocontinue");
            Console.ReadLine();
        }
    }
}