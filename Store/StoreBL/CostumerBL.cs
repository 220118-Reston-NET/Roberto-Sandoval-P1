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

    public (Costumer, bool) findCostumer(String p_name, string p_phone)
    {
        List<Costumer> _costumerList = _repo.ListOfCostumers();

        foreach (var curr in _costumerList)
        {
            // If costumer exists in database return true and object
            if (curr.Name == p_name && curr.Phone == p_phone)
                return (curr, true);
        }
        //Console.WriteLine("costumer does not excist in database");

        Costumer empty = new Costumer();
        return (empty, false);
    }

    public (StoreFront, bool) findStore(String p_name, string p_address)
    {
        List<StoreFront> _costumerList = _repo.ListOfStores();
        foreach (var curr in _costumerList)
        {
            // If store exists in database return true and object
            if (curr.Name == p_name && curr.Address == p_address)
                return (curr, true);
        }
        //Console.WriteLine("costumer does not excist in database");

        StoreFront empty = new StoreFront();
        return (empty, false);
    }

    public void addOrder(String p_name, string p_phone, Orders p_order)
    {
        (Costumer curr, bool readyToGo) = findCostumer(p_name, p_phone);
        curr._orders.Add(p_order);
    }
}   
