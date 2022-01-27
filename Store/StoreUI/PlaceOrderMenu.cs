using StoreModel;
using StoreBL;

namespace StoreUI;

public class PlaceOrderMenu : IMenu
{
    private static Costumer _newCostumer = new Costumer();
    private static Orders _newOrder = new Orders();

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
        Console.WriteLine($"[3] Select Costumer");
        Console.WriteLine("[2] Items:");
        if (readyToProcess)
            Console.WriteLine("[1] Place Order");
        else
            Console.WriteLine("[4] Confirm Costumer Exists");
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
                // Place order and save order to costumer's lsit of orders
                _costumerBL.addOrder(_newCostumer.Name, _newCostumer.Phone, _newOrder);
                Console.WriteLine("The Order Has Been Succesfully Placed");
                Console.WriteLine("Press ENTER to finish and go back to the Main Menu");
                Console.ReadLine();
                return "MainMenu";
            case "2":
                // Go to add items menu
                return "ItemsMenu";
            case "3":
                Console.WriteLine("Please Enter Costumer Name");
                _newCostumer.Name = Console.ReadLine();
                Console.WriteLine("Please Enter Costumer Phone Number");
                _newCostumer.Phone = Console.ReadLine();
                return "PlaceOrderMenu";
            case "4":
                (_newCostumer, readyToProcess) = _costumerBL.findCostumer(_newCostumer.Name, _newCostumer.Phone);
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
                Console.WriteLine("You have chosen an invalid pick");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "PlaceOrderMenu";
        }
    }
}