using StoreBL;
using StoreModel;

namespace StoreUI;

class ViewOrderHistoryMenu : IMenu
{
    private List<Products> _productsForOrder = new List<Products>();
    private static Costumer _newCostumer = new Costumer();
    private static StoreFront _newStore = new StoreFront();

    private ICostumerBL _costumerBL;
    private IStoreFrontBL _storeFrontBL;
    public ViewOrderHistoryMenu(ICostumerBL p_costumerBL, IStoreFrontBL p_storeFrontBL)
    {
        _costumerBL = p_costumerBL;
        _storeFrontBL = p_storeFrontBL;
    }


    //bool frameSelected = false;
    bool selectedCostumer = false;
    bool selectedStore = false;
    //int orderNumber=0;
    public void ShowMenu()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("           Store Management System 2.0  ");
        Console.WriteLine("==================================================");
        Console.WriteLine();
        Console.WriteLine("         Please Select Order Type to Search\n");
        Console.WriteLine("             <2> Costumer");
        Console.WriteLine("             <1> Store");
        Console.WriteLine("             <0> Main Menu\n\n");
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
                //frameSelected=true;
                selectedStore=true;
                processInput();
                return "MainMenu";
            case "2":
                //frameSelected=true;
                selectedCostumer=true;
                processInput();
                return "MainMenu";
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "ViewOrderHistoryMenu";
        }
        
    }

    public void processInput()
    {
        Console.WriteLine("Inside process input");
        bool keep=true;
        if(selectedStore)
        {
            while(!keep)
            {
                Console.WriteLine("Please Enter The Following Store Information");
                Console.WriteLine("Name");
                _newStore.StoreName = Console.ReadLine();
                Console.WriteLine("Press ENTER");
                Console.WriteLine("Address");
                _newStore.StoreAddress = Console.ReadLine();
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
    }
}