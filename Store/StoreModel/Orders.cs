namespace StoreModel
{
    public class Orders
    {

        private List<Orders> _list = new List<Orders>();
        public List<LineItems> _itemList;
        public string Name { get; set; }
        public double Price { get; set; }

        public Orders()
        {
            _itemList =  new List<LineItems>();
            Price = 0.0;
        }

        // public void findCostumer(String p_name, string p_phone)
        // {
        //     foreach (var curr in _list)
        //     {
        //         if (curr.Name == p_name && curr.Phone == p_phone)
        //         {
        //             Console.WriteLine("Costumer does excist in database");
        //             return;
        //         }
        //     }
            
        //     Console.WriteLine("costumer does not excist in database");

        // }
        

    }
}
