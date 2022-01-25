using StoreModel;
using StoreBL;

namespace StoreUI
{
    public class AddCostumerMenu : IMenu
    {
        private static Costumer _newCostumer = new Costumer();

        private ICostumerBL _costumerBL;
        public AddCostumerMenu(ICostumerBL p_costumerBL)
        {
            _costumerBL = p_costumerBL;
        }
        public void ShowMenu()
        {
            Console.WriteLine("Store Management System 2.0");
            Console.WriteLine("Enter Costumer Information");
            Console.WriteLine($"[1] Name: {_newCostumer.Name}");
            Console.WriteLine($"[2] Phone: {_newCostumer.Phone}");
            Console.WriteLine($"[3] Address: {_newCostumer.Address}");
            Console.WriteLine($"[4] Email: {_newCostumer.Email}");
            Console.WriteLine("[5] Save");
            Console.WriteLine("[0] Return to Main Menu (Changes won't be saved)");
        }

        public string UserPick()
        {
            string pickedChoice = Console.ReadLine();

            switch (pickedChoice)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Please Enter Costumer Name:");
                    _newCostumer.Name = Console.ReadLine();
                    return "AddCostumer";
                case "2":
                    Console.WriteLine("Please Enter Costumer Phone Number");
                    _newCostumer.Phone = Console.ReadLine();
                    return "AddCostumer";
                case "3":
                    Console.WriteLine("Please Enter Costumer Address");
                    _newCostumer.Address = Console.ReadLine();
                    return "AddCostumer";
                case "4":
                    Console.WriteLine("Please Enter Costumer Email");
                    _newCostumer.Phone = Console.ReadLine();
                    return "AddCostumer";
                case "5":
                    bool proceed = checkFilled();
                    if (proceed)
                        return "MainMenu";
                    else
                        return "AddCostumer";
                default:
                    Console.WriteLine("You have chosen an invalid pick");
                    Console.WriteLine("Press ENTER to try again");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }

        public bool checkFilled()
        {
            if (_newCostumer.Name!=".Name" && _newCostumer.Phone!=".Phone" && _newCostumer.Address!=".Address" && _newCostumer.Email !=".Email")
            {
                _costumerBL.AddCostumer(_newCostumer);
                Console.WriteLine($"Costumer {_newCostumer.Name} has been succesfully added to database");
                Console.WriteLine("Press ENTER to go back to Main Menu");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Please update every costumer field before saving");
                Console.WriteLine("Press ENTER to go back and finish");
                Console.ReadLine();
                return false;
            }
        }
    }
}