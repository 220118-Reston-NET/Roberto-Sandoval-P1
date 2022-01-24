namespace StoreUI
{
    public class MainMenu : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("Store Management System 2.0");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("[1] Add Costumer");
            Console.WriteLine("[2] Search for Costumer");
            Console.WriteLine("[3] View Store Front Inventory");
            Console.WriteLine("[4] Place Order");
            Console.WriteLine("[5] View Store Order History");
            Console.WriteLine("[6] View Costumer Order History");
            Console.WriteLine("[7] Replenish Inventory");
            Console.WriteLine("[0] Exit");
        }

        public string UserPick()
        {
            string pickedChoice = Console.ReadLine();

            switch (pickedChoice)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "AddCostumer";
                default:
                    Console.WriteLine("You have chosen an invalid pick");
                    return "MainMenu";

            }
        }
    }
}