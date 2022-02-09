using StoreBL;
using StoreModel;

namespace StoreUI;

public class ViewStoreInventoryMenu : IMenu
{
    private static StoreFront _newStore = new StoreFront();
    //private bool readyForOrder = false;
    private bool storeFound = true;

    private IStoreFrontBL _storeFrontBL;
    public ViewStoreInventoryMenu(IStoreFrontBL p_storeFrontBL)
    {
        _storeFrontBL = p_storeFrontBL;
    }


    public void ShowMenu()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("           Store Management System 2.0  ");
        Console.WriteLine("==================================================");
        Console.WriteLine();
        Console.WriteLine("         Please Fill In the Following Store Information\n");
        Console.WriteLine($"             <4> Store Name: {_newStore.StoreName}");
        Console.WriteLine($"             <3> Store Address: {_newStore.StoreAddress}");
        //Console.WriteLine("[2] Start a Purchase For Costumer From Selected Store");
        Console.WriteLine("             <1> Search For Store and List Its Inventory");
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
                checkFilled();
                return "ViewStoreInventory";
            // case "2":
            //     if (readyForOrder)
            //     {
            //         // proceed with order
            //         return "PlaceOrder";
            //     }
            //     else
            //     {
            //         Console.WriteLine("Please do a search for store before trying to place an order");
            //         Console.WriteLine("Press ENTER to continue");
            //         Console.ReadLine();
            //         return "ViewStoreInventory";
            //     }
                
            case "3":
                Console.WriteLine("Please Enter Store Address");
                _newStore.StoreAddress = Console.ReadLine();
                return "ViewStoreInventory";
            case "4":
                Console.WriteLine("Please Enter Store Name");
                _newStore.StoreName = Console.ReadLine();
                return "ViewStoreInventory";
            default:
                Console.WriteLine("");
                Console.WriteLine("You Have Entered an Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "ViewStoreInventory";
        }
            
    }

    public void checkFilled()
    {
        if (_newStore.StoreName!=".StoreName" && _newStore.StoreAddress!=".StoreAddress")
        {
            (StoreFront _curr, bool found) = _storeFrontBL.findStore(_newStore);

            if(found)
            {
                // list store items
                _storeFrontBL.listItems(_newStore);
                storeFound = true;
                //readyForOrder = true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Store not found");
                Console.WriteLine("Information might be incorrect or Store doesn't exist");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Please Fill in All the Required Information to do a Search");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}