using StoreModel;
using StoreBL;

namespace StoreUI;

class ViewStoreFrontMenu : IMenu
{
    private static StoreFront _newStore =  new StoreFront();
    bool finishedSelecting = false;
    public void ShowMenu()
    {
        Console.WriteLine("Store Management System 2.0");
        Console.WriteLine("Enter Store Information");
        Console.WriteLine($"[1] Name: {_newStore.Name}");
        Console.WriteLine($"[3] Address: {_newStore.Address}");
        Console.WriteLine("[0] Return to Main Menu");
        
    }

    public string UserPick()
    {
        throw new NotImplementedException();
    }
}