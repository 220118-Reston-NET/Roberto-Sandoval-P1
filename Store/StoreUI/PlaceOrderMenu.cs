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
        Console.WriteLine("==================================================");
        Console.WriteLine("           Store Management System 2.0  ");
        Console.WriteLine("==================================================");
        Console.WriteLine();
        Console.WriteLine("             Please Select an Option\n");
        Console.WriteLine("             <3> Add/Change Costumer");
        Console.WriteLine("             <2> Add Items");
        Console.WriteLine("             <1> Place Order");
        Console.WriteLine("             <0> Go Back to Main Menu\n\n");
        Console.Write(" Choice: ");
    }

    public string UserPick()
    {
        string pickedChoice = Console.ReadLine();

        switch (pickedChoice)
        {
            case "0":
                return "MainMenu";
            case"1":
                // Get costumerId and add it to order
                if (readyToProcess){
                    Log.Information("User has placed an order");
                    _costumerBL.addOrder(_newCostumer, _listOfProducts);
                    Console.WriteLine("Your Order Has Been Succesfully Placed");
                    Console.WriteLine("Press ENTER To Go Back To Main Menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please finish adding a costumer to order");
                    Console.WriteLine("Presente ENTER to continue");
                    Console.ReadLine();
                    return "PlaceOrder";
                }
                return"MainMenu";
                
            case "2":
                // Add store to order from
                // List products
                _listOfProducts.Add(_currProduct);
                Console.WriteLine("The Item has Been Succesfully Added To Your Order");
                Console.WriteLine("Press ENTER to Continue");
                Console.ReadLine();
                return "PlaceOrder";
            case "3":
                Console.WriteLine("Please Enter Costumer Name");
                _newCostumer.Name = Console.ReadLine();
                Console.WriteLine("Please Enter Costumer Phone Number");
                _newCostumer.Phone = Console.ReadLine();
                
                (_newCostumer, readyToProcess) = _costumerBL.findCostumer(_newCostumer);
                if (readyToProcess)
                {
                    Console.WriteLine("Costumer Has Been Added To Order");
                    Console.WriteLine("Costumer:");
                    Console.WriteLine(_newCostumer.ToString());
                    Console.WriteLine("Press ENTER To Reurn And Continue With Order");
                    Console.ReadLine();
                    return "PlaceOrder";
                }
                Console.WriteLine("Costumer Doesn't Exists in DataBase");
                Console.WriteLine("Press ENTER To Continue");
                Console.ReadLine();
                
                return "PlaceOrder";
        
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "PlaceOrderMenu";
        }
    }


}