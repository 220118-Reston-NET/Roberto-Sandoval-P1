using StoreBL;
using StoreModel;

namespace StoreUI;

public class ViewInventoryMenu : IMenu
{
    private static StoreFront _newStore = new StoreFront();

    private IStoreFrontBL _storeFrontBL;
    public ViewInventoryMenu(IStoreFrontBL p_storeFrontBL)
    {
        _storeFrontBL = p_storeFrontBL;
    }


    public void ShowMenu()
    {
        Console.WriteLine("Store Management System 2.0");
        Console.WriteLine("Please Fill In the Following Store Information to do a Search");
        Console.WriteLine($"[4] Store Name: {_newStore.Name}");
        Console.WriteLine($"[3] Store Address: {_newStore.Address}");
        Console.WriteLine("[2] Start a Purchase For Costumer From Selected Store");
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
                checkFilled();
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
        if (_newStore.Name!=".Name" && _newStore.Address!=".Address")
        {
            (StoreFront _curr, bool found) = _storeFrontBL.findStore(_newStore);

            if(found)
            {
                _storeFrontBL.listItems(_newStore);

            return found;
            }
            else
            {
                Console.WriteLine("Store not found");
                Console.WriteLine("Information might be incorrect or Store doesn't exist");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return found;
            }

        }
        else
        {
            Console.WriteLine("Please Fill in All the Required Information to do a Search");
            return false;
        }
    }
}