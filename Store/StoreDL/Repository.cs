using StoreModel;
using System.Text.Json;

namespace StoreDL
{
    public class Repository : IRepository
    {
        private List<Costumer> _costumerList = new List<Costumer>();
        //private List<StoreFront> _storeList = new List<StoreFront>(); 

        private string _filepath = "../StoreDL/Database";
        private string _jsonstring;

        public Costumer AddCostumer(Costumer p_costumer)
        {
            _costumerList.Add(p_costumer);

            string path = _filepath + "Costumer.json";

            _jsonstring = JsonSerializer.Serialize(_costumerList);

            File.WriteAllText(path, _jsonstring);

            return p_costumer;
        }
    }
}