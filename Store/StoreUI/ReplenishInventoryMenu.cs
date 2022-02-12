using StoreModel;
using StoreBL;

namespace StoreUI;

class ReplenishInventoryMenu : IMenu
{
    List<StoreInventory> _inventoryList = new List<StoreInventory>();
    private static StoreFront _newStore =  new StoreFront();
    private static StoreInventory _newItem = new StoreInventory();

    private IStoreFrontBL _storeFrontBL;
    public ReplenishInventoryMenu(IStoreFrontBL p_storeFrontBL)
    {
        _storeFrontBL = p_storeFrontBL;
    }


    public void ShowMenu()
    {
        Console.WriteLine("===============================================================");
        Console.WriteLine("                  Store Management System 2.0");
        Console.WriteLine("===============================================================");
        Console.WriteLine();
        Console.WriteLine("                    -- Replenish Inventory --");
        Console.WriteLine("");
        Console.WriteLine("                     Enter Store Information\n");
        Console.WriteLine($"                    <3> Store Number: {_newStore.StoreNumber}");
        Console.WriteLine("                    <2> Add Item to Replenish Queue");
        Console.WriteLine("                    <1> Finish Replenish Request");
        Console.WriteLine("                    <0> Return to Main Menu Without Changing Inventory\n\n");
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
                // call method and pass list
                _storeFrontBL.addInventory(_inventoryList);
                return "ReplenishInventory";
            case "2":
                Console.WriteLine("");
                Console.WriteLine("Enter Item Number");
                _newItem.ProductId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Quantity");
                _newItem.Quantity = Convert.ToInt32(Console.ReadLine());
                _newItem.StoreNumber = _newStore.StoreNumber;
                _inventoryList.Add(_newItem);
                _newItem = new StoreInventory();
                Console.WriteLine("Item Added to Inventory Queue");
                Console.WriteLine("Press ENTER to Continue");
                Console.ReadLine();
                return "ReplenishInventory";
            case "3":
                Console.WriteLine("");
                Console.WriteLine("Please Enter Store Number");
                _newStore.StoreNumber = Convert.ToInt32(Console.ReadLine());
                return "ReplenishInventory";
            case "4":
                Console.WriteLine("");
                Console.WriteLine("Please Enter Store Name");
                _newStore.StoreName = Console.ReadLine();
                return "ReplinishInventory";
            default:
                Console.WriteLine("");
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
            Console.WriteLine("");
            Console.WriteLine("Please Finish Filling in Store Details");
            Console.WriteLine("Press ENTER t ocontinue");
            Console.ReadLine();
        }
    }
}