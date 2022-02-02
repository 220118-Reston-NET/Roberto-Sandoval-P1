using StoreModel;
using StoreBL;

namespace StoreUI;

public class PlaceOrderMenu : IMenu
{
    private List<Products> _listOfProducts = new List<Products>();
    private static Costumer _newCostumer = new Costumer();
    private static Orders _newOrder = new Orders();
    private static Products _currProduct;

    private ICostumerBL _costumerBL;
    public PlaceOrderMenu(ICostumerBL p_costumerBL)
    {
        _costumerBL = p_costumerBL;
    }

    bool readyToProcess = false;
    bool finishedSelecting = false;
    public void ShowMenu()
    {
        Console.WriteLine("Store Management System 2.0");
        //Console.WriteLine(_newCostumer.ToString());
        Console.WriteLine("Please Select an Option");
        Console.WriteLine("[3] Add/Change Costumer");
        Console.WriteLine("[2] Add Items");
        Console.WriteLine("[1] Place Order");
        Console.WriteLine("[0] Go Back to Main Menu");
    }

    public string UserPick()
    {
        string pickedChoice = Console.ReadLine();

        switch (pickedChoice)
        {
            case "0":
                return "MainMenu";
            case"1":
                
            case "2":
                _listOfProducts.Add(_currProduct);
                //_costumerBL.addOrder(_newCostumer, _listOfProducts);
                Console.WriteLine("The Item has Been Succesfully Added To Your Order");
                //processInput();
                return "ItemsMenu";
            case "3":
                Console.WriteLine("Please Enter Costumer Name");
                _newCostumer.Name = Console.ReadLine();
                Console.WriteLine("Please Enter Costumer Phone Number");
                _newCostumer.Phone = Console.ReadLine();
                return "PlaceOrderMenu";
            case "4":
                (_newCostumer, readyToProcess) = _costumerBL.findCostumer(_newCostumer);
                if (readyToProcess)
                {
                    Console.WriteLine("Costumer Exists in DataBase");
                    Console.WriteLine("Press ENTER to return and finish order");
                    Console.ReadLine();
                    return "PlaceOrderMenu";
                }
                Console.WriteLine("Costumer Doesn't Exists in DataBase");
                Console.WriteLine("Press ENTER to go back and change details");
                Console.ReadLine();
                
                return "PlaceOrderMenu";
        
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "PlaceOrderMenu";
        }
    }

    public void processInput()
    {
        bool addNext=true;
        string yesNo="";
        while (addNext)
        {
        // Place order and save order to costumer's lsit of orders
        _listOfProducts.Add(_currProduct);
        //_costumerBL.addOrder(_newCostumer, _listOfProducts);
        Console.WriteLine("The Item has Been Succesfully Added To Your Order");
        Console.WriteLine("Would you like to add another item to order");
        Console.WriteLine("[1] Yes");
        Console.WriteLine("[0] No");
        yesNo=Console.ReadLine();
        if(yesNo == "0")
        {
            Console.WriteLine("Press ENTER to finish and go back to the Main Menu And");
            Console.ReadLine();
            break;
        }
        else if (yesNo == "1")
        {
            continue;
        }
        else
            return;
        }

    }


}