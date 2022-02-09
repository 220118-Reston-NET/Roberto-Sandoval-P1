using StoreModel;
using StoreBL;

namespace StoreUI;

public class PlaceOrderMenu : IMenu
{
    private List<Products> _listOfProducts = new List<Products>();
    private static Costumer _newCostumer = new Costumer();
    private static Orders _newOrder = new Orders();

    private static StoreFront _newStoreFront = new StoreFront();
    //private static int _currStoreNum = 000;
    private static Products _currProduct;

    private ICostumerBL _costumerBL;
    private IStoreFrontBL _storeFrontBL;
    public PlaceOrderMenu(ICostumerBL p_costumerBL, IStoreFrontBL p_storeFrontBL)
    {
        _costumerBL = p_costumerBL;
        _storeFrontBL = p_storeFrontBL;
    }

    bool readyToProcess = false;
    bool addedStore = false;
    bool addedCostumer = false;
    bool costumerFound = false;
    public void ShowMenu()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("           Store Management System 2.0  ");
        Console.WriteLine("==================================================");
        Console.WriteLine();
        Console.WriteLine("             Please Select an Option\n");
        Console.WriteLine("             <5> Choose Store");
        Console.WriteLine("             <4> List Available Items");
        Console.WriteLine("             <3> Add Costumer to Order");
        Console.WriteLine("             <2> Add Items");
        Console.WriteLine("             <1> Place Order");
        Console.WriteLine("             <0> Go Back to Main Menu\n\n");
        Console.Write("Choice: ");

        // Console.WriteLine("\nCostumer:");
        // Console.WriteLine(_newCostumer.ToString);
        // Console.WriteLine("\nCart:");
        // Console.WriteLine(_listOfProducts.ToString);
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
                    _newOrder.CostumerId = _newCostumer.CostumerId;
                    _newOrder.StoreNumber = _newStoreFront.StoreNumber;
                    _costumerBL.placeOrder(_newCostumer, _listOfProducts);
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
                Console.WriteLine("Please Enter Item Number");
                Console.ReadLine();
                Console.WriteLine("Please Enter Quantity");
                Console.ReadLine();
                _listOfProducts.Add(_currProduct);
                Console.WriteLine($"Item Number: With Quantity: Has Been Succesfully Added To Your Order");
                Console.WriteLine("Press ENTER to Continue");
                Console.ReadLine();
                return "PlaceOrder";
            case "3":
                Console.WriteLine("Please Enter Costumer Name");
                _newCostumer.Name = Console.ReadLine();
                Console.WriteLine("Please Enter Costumer Phone Number");
                _newCostumer.Phone = Console.ReadLine();
                
                (_newCostumer, costumerFound) = _costumerBL.findCostumer(_newCostumer);
                if (costumerFound)
                {
                    addedCostumer = true;
                    Console.WriteLine("Costumer Has Been Added To Order");
                    Console.WriteLine("Costumer:");
                    Console.WriteLine(_newCostumer.ToString());
                    Console.WriteLine("Press ENTER To Go Back And Continue With Order");
                    Console.ReadLine();
                    return "PlaceOrder";
                }
                Console.WriteLine("Costumer Doesn't Exists in DataBase");
                Console.WriteLine("Press ENTER To Continue");
                Console.ReadLine();
                
                return "PlaceOrder";
            case "4":
                _listOfProducts = _storeFrontBL.listInventory(_newStoreFront.StoreNumber);
                foreach (var item in _listOfProducts)
                {
                    Console.WriteLine(item.ToString);
                }
                Console.WriteLine("Item Number Will be Required to Add Item to Cart");
                Console.WriteLine("Press ENTER to go back to Order Menu");
                Console.ReadLine();
                return "PlaceORder";
            case "5":
                processInput();
                Console.WriteLine("Press ENTER To Go Back And Continue With Order");
                Console.ReadLine();
                return "PlaceOrder";
            default:
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "PlaceOrderMenu";
        }
    }

    public void processInput()
    {
        bool storeFound = false;
        Console.WriteLine("Please Enter Store Number");
        _newStoreFront.StoreNumber = Convert.ToInt32(Console.ReadLine());
        

        (_newStoreFront, storeFound) = _storeFrontBL.findStore(_newStoreFront);

        if (storeFound)
        {
            addedStore = true;
            Console.WriteLine("Store Has Been Added To Order");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect Store Number\nPress ENTER to go back and Try Again");
            Console.ReadLine();
        }


    }


}