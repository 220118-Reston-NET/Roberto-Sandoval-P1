using StoreModel;
using System.Text.Json;

namespace StoreDL;
public class Repository : IRepository
{
    private static List<Costumer> _costumerList = new List<Costumer>();
    //private List<StoreFront> _storeList = new List<StoreFront>(); 

    private string _filepath = "../StoreDL/Database/";
    private string _jsonstring;

    public Costumer AddCostumer(Costumer p_costumer)
    {
        _costumerList.Add(p_costumer);

        string path = _filepath + "Costumer.json";

        _jsonstring = JsonSerializer.Serialize(_costumerList);

        File.WriteAllText(path, _jsonstring);

        //loadCostumer();

        return p_costumer;
    }

    public List<Costumer> ListOfCostumers(){
        // Converting JSON to Object
        string jsonString2 = File.ReadAllText(_filepath + "Costumer.json");
        
        // Load Objects onto new dictionary
        List<Costumer> _newCostumerList = JsonSerializer.Deserialize<List<Costumer>>(jsonString2);
        return _costumerList = _newCostumerList;

    }

    // public Costumer findCostumer(String p_name, string p_phone)
    // {
    //     foreach (var curr in _costumerList)
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