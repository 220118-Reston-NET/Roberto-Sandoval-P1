using StoreUI;
using StoreBL;
using StoreDL;

bool repeat = true;
IMenu menu = new MainMenu();

while(repeat)
{
    Console.Clear();
    menu.ShowMenu();
    string choice = menu.UserPick();

    switch (choice)
    {
        case "Exit":
            repeat = false;
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "AddCostumer":
            menu = new AddCostumerMenu(new CostumerBL(new Repository()));
            break;
        case "SearchCostumer":
            //menu = new SearchCostumerMenu();
            break;
        case "ViewStore":
            break;
        case "PlaceOrder":
            break;
        case "StoreOrderHistory":
            break;
        case "CostumerOrderHistory":
            break;
        case "ReplenishInventory":
            break;
        default:
            Console.WriteLine("An error has occured");
            break;
    }
}