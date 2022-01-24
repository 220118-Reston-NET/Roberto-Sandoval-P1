using StoreUI;

bool repeat = true;
IMenu menu = new MainMenu();

while(repeat)
{
    Console.Clear();
    menu.ShowMenu();
    string choice = menu.UserPick();

    switch (choice)
    {
        case "--":
            break;
        default:
            Console.WriteLine("An error has occured");
            break;
    }
}