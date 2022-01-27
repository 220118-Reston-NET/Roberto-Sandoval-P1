global using Serilog;

using StoreUI;
using StoreBL;
using StoreDL;

// Initializing program logging for debugging
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/debuglog.txt") //We configure our logger to save in this file
    .CreateLogger();

bool repeat = true;
IMenu menu = new MainMenu();

Console.WriteLine("Database has been initialized succesfully");
Console.WriteLine("Press ENTER to continue");


while(repeat)
{
    Console.Clear();
    menu.ShowMenu();
    string choice = menu.UserPick();

    switch (choice)
    {
        case "Exit":
            Log.Information("User exited program");
            Log.CloseAndFlush();
            repeat = false;
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "AddCostumer":
            Log.Information("User selected AddCostumer menu");
            menu = new AddCostumerMenu(new CostumerBL(new Repository()));
            break;
        case "SearchCostumer":
            Log.Information("User selected SearchCostumer menu");
            menu = new SearchCostumerMenu(new CostumerBL(new Repository()));
            break;
        case "PlaceOrder":
            Log.Information("User went into PlaceOrder menu");
            menu = new PlaceOrderMenu(new CostumerBL(new Repository()));
            break;
        case "ViewStore":
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