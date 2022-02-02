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

    public (Costumer, bool) findCostumer(Costumer p_costumer)
    {
        List<Costumer> _costumerList = _repo.ListOfCostumers();

        foreach (var curr in _costumerList)
        {
            // If costumer exists in database return true and object
            if (curr.Name == p_costumer.Name && curr.Phone == p_costumer.Phone)
                return (curr, true);
        }
        //Console.WriteLine("costumer does not excist in database");

        Costumer empty = new Costumer();
        return (empty, false);
    }

    public void addOrder(Costumer p_costumer, Orders p_order)
    {
        (Costumer curr, bool readyToGo) = findCostumer(p_costumer);
        curr._orders.Add(p_order);
    }
    
}   
