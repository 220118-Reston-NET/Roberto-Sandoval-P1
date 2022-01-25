namespace StoreModel
{
    public class Costumer
    {
        private List<Costumer> _list = new List<Costumer>();
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Costumer()
        {
            Name = ".Name";
            Phone = ".Phone";
            Address = ".Address";
            Email = ".Email";
        }

        public void findCostumer(String p_name, string p_phone)
        {
            foreach (var curr in _list)
            {
                if (curr.Name == p_name && curr.Phone == p_phone)
                {
                    Console.WriteLine("Costumer does excist in database");
                    return;
                }
            }
            
            Console.WriteLine("costumer does not excist in database");

        }
    }
}