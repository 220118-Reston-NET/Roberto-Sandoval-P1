using StoreModel;
using StoreBL;

namespace StoreUI;

public class PlaceOrderMenu : IMenu
{
    private List<Products> _listOfProducts = new List<Products>();
    private List<StoreInventory> _listOfStock = new List<StoreInventory>();
    private static Costumer _newCostumer = new Costumer();
    //private static Orders _newOrder = new Orders();
    private static StoreFront _newStoreFront = new StoreFront();
    private static Products _currProduct = new Products();
    //private static LineItems _orderedItem = new LineItems();
    private static StoreInventory _currStock = new StoreInventory();

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
    bool addedItem = false;
    bool costumerFound = false;
    public void ShowMenu()
    {
        Console.WriteLine("===============================================================");
        Console.WriteLine("                  Store Management System 2.0");
        Console.WriteLine("===============================================================");
        Console.WriteLine();
        Console.WriteLine("                       -- Place Order --");
        Console.WriteLine("");

        if(addedCostumer && !addedStore)
        {
            Console.WriteLine("Costumer:");
            Console.WriteLine($"  {_newCostumer.Name}");
            Console.WriteLine($"  {_newCostumer.Phone}");
        }

        else if(addedCostumer && addedStore)
        {
            Console.WriteLine("Costumer:                                   Store:");
            Console.WriteLine($"  {_newCostumer.Name}                        {_newStoreFront.StoreNumber} - {_newStoreFront.StoreName}");
            Console.WriteLine($"  {_newCostumer.Phone}");
        }

        if (addedItem)
        {
            foreach (var item in _listOfProducts)
            {
                Console.WriteLine("Qty   Item      Price");
                Console.WriteLine($"{item.ProductQuantity} {item.ProductName} {item.ProductPrice}");
            }
        }
        Console.WriteLine("                     Please Select an Option\n");
        Console.WriteLine("                     <5> Choose Store");
        Console.WriteLine("                     <4> Choose Costumer");
        Console.WriteLine("                     <3> Add Items");
        Console.WriteLine("                     <2> List Available Items");
        Console.WriteLine("                     <1> Place Order");
        Console.WriteLine("                     <0> Go Back to Main Menu\n\n");
        Console.Write("Choice: ");
    }

    public string UserPick()
    {
        string pickedChoice = Console.ReadLine();

        switch (pickedChoice)
        {
            case "0":
                return "MainMenu";
            case"1":
                // Add list of products onto database
                if (readyToProcess){
                    // Subtract items from store inventory
                    _storeFrontBL.subtractInventory(_listOfStock);
                    _costumerBL.placeOrder(_newCostumer, _listOfProducts);
                    Log.Information("User has placed an order");

                    Console.WriteLine("");
                    Console.WriteLine("Your Order Has Been Succesfully Placed");
                    Console.WriteLine("Press ENTER To Go Back To Main Menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please finish adding required order information");
                    Console.WriteLine("Presente ENTER to continue");
                    Console.ReadLine();
                    return "PlaceOrder";
                }
                return"MainMenu";
            case "2":
                if(addedStore)
                {
                    _listOfStock = _storeFrontBL.listInventory(_newStoreFront.StoreNumber);
                    Console.WriteLine("");
                    foreach (var item in _listOfStock)
                    {
                        Console.WriteLine(item.ToString);
                    }
                    Console.WriteLine("Item Number Will be Required to Add Item to Cart");
                    Console.WriteLine("Press ENTER to go back to Order Menu");
                    Console.ReadLine();
                    return "PlaceOrder";
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("You have not added a store to your order");
                    Console.WriteLine("Press ENTER to go back and add a store");
                    Console.ReadLine();
                    return "PlaceOrder";
                }
                
            case "3":
                if (addedCostumer && addedStore)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please Enter Item Number");
                    _currProduct.ProductId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please Enter Quantity");
                    _currProduct.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    _currStock.ProductId = _currProduct.ProductId;
                    _currStock.Quantity = _currProduct.ProductQuantity;
                    _currStock.StoreNumber = _newStoreFront.StoreNumber;
                    _listOfProducts.Add(_currProduct);
                    _listOfStock.Add(_currStock);
                    
                    Console.WriteLine($"Item Number: {_currProduct.ProductId} With Quantity {_currProduct.ProductQuantity}: Has Been Succesfully Added To Your Order");
                    _currProduct = new Products();
                    Console.WriteLine("Press ENTER to Continue");
                    Console.ReadLine();
                }
                return "PlaceOrder";
            case "4":
                Console.WriteLine("");
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
                Console.WriteLine("Press ENTER To Go Back to Order Menu");
                Console.ReadLine();
                
                return "PlaceOrder";
            case "5":
                processInput();
                Console.WriteLine("Press ENTER To Go Back And Continue With Order");
                Console.ReadLine();
                return "PlaceOrder";
            default:
                Console.WriteLine("");
                Console.WriteLine("You Have Entered An Invalid Choice");
                Console.WriteLine("Press ENTER to try again");
                Console.ReadLine();
                return "PlaceOrderMenu";
        }
    }

    public void processInput()
    {
        bool storeFound = false;
        Console.WriteLine("");
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