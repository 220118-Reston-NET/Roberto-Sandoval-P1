using StoreModel;
using StoreDL;

namespace StoreBL;

public class CostumerBL : ICostumerBL
{
    private IRepository _repo;
    public CostumerBL(IRepository p_repo)
    {
        _repo = p_repo;
    }

    public Costumer AddCostumer(Costumer p_costumer)
    {
        return _repo.AddCostumer(p_costumer);
    }

    public List<Costumer> loadCostumerData()
    {
        return _repo.ListOfCostumers();
    }

    public (Costumer, bool) findCostumer(String p_name, string p_phone)
    {
        List<Costumer> _costumerList = loadCostumerData();
        foreach (var curr in _costumerList)
        {
            // If costumer exists in database return true and object
            if (curr.Name == p_name && curr.Phone == p_phone)
            {
                //Console.WriteLine("Costumer does excist in database");
                return (curr, true);
            }
        }
        //Console.WriteLine("costumer does not excist in database");

        Costumer empty = new Costumer();
        return (empty, false);
    }

    public void addOrder(String p_name, string p_phone, Orders p_order)
    {
        (Costumer curr, bool readyToGo) = findCostumer(p_name, p_phone);
        curr._orders.Add(p_order);
    }
}   
