using StoreBL;
using StoreModel;

namespace StoreUI;

class ViewORderHistoryMenu : IMenu
{
    private List<Products> _productsForOrder = new List<Products>();
    private static Costumer _newCostumer = new Costumer();
    private static StoreFront _newStore = new StoreFront();

    private ICostumerBL _costumerBL;
    private IStoreFrontBL _storeFrontBL;
    public ViewORderHistoryMenu(ICostumerBL p_costumerBL, IStoreFrontBL p_storeFrontBL)
    {
        _costumerBL = p_costumerBL;
        _storeFrontBL = p_storeFrontBL;
    }


    bool frameSelected = false;
    bool selectedCostumer = false;
    bool selectedStore = false;
    //int orderNumber=0;
    public void ShowMenu()
    {
        Console.WriteLine("Store Management System 2.0");

        if (frameSelected && selectedCostumer)
        {
            Console.WriteLine("Please Enter CostumerNumber");
            //orderNumber=Convert.ToInt32(Console.ReadLine());
        }
        else if (frameSelected && selectedStore)
        {

        }

        Console.WriteLine("Please Select Order Type to Search");
        Console.WriteLine("[2] Costumer");
        Console.WriteLine("[1] Store");
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
                frameSelected=true;
                selectedStore=true;
                return "ViewOrderHistoryMenu";
            case "2":
                frameSelected=true;
                selectedCostumer=true;
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

    public void processInput()
    {
        bool keep=true;
        if(selectedStore)
        {
            while(!keep)
            {
                Console.WriteLine("Please Enter The Following Store Information");
                Console.WriteLine("Name");
                _newStore.Name = Console.ReadLine();
                Console.WriteLine("Press ENTER");
                Console.WriteLine("Address");
                _newStore.Address = Console.ReadLine();
                Console.WriteLine("Press ENTER to confirm information");
                (StoreFront curr, bool proceed) =_storeFrontBL.findStore(_newStore);
                if(proceed)
                {
                    
                    _storeFrontBL.listOrders(_newStore);
                    Console.WriteLine("Press ENTER to return to menu");
                    Console.ReadLine();
                    keep=false;
                }

            }

        }
        else if (selectedCostumer)
        {
            while(!keep)
            {
                Console.WriteLine("Please Enter The Following Costumer Information");
                Console.WriteLine("Name");
                _newCostumer.Name = Console.ReadLine();
                Console.WriteLine("Press ENTER");
                Console.WriteLine("Phone Number");
                _newCostumer.Phone = Console.ReadLine();
                Console.WriteLine("Press ENTER to confirm information");
                (Costumer curr, bool proceed) =_costumerBL.findCostumer(_newCostumer);
                if(proceed)
                {
                    _costumerBL.listOrders(curr);
                    keep=false;
                }
            }

        }
        else
        {

        }
    }
}