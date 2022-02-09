using StoreModel;
using StoreDL;

namespace StoreBL;

public class StoreFrontBL : IStoreFrontBL
{
    private IRepository _repo;
    public StoreFrontBL(IRepository p_repo)
    {
        _repo = p_repo;
    }

    public (StoreFront, bool) findStore(StoreFront p_storeFront)
    {
        List<StoreFront> _storeFrontList = _repo.ListOfStores();

        foreach (var curr in _storeFrontList)
        {
            // If store exists in database return true and object
            if (curr.StoreName == p_storeFront.StoreName && curr.StoreAddress == p_storeFront.StoreAddress)
                return (curr, true);
        }
        //Console.WriteLine("costumer does not excist in database");

        StoreFront empty = new StoreFront();
        return (empty, false);
    }

    public void listItems(StoreFront p_store)
    {
        // foreach(var curr in p_store._productList)
        // {
        //     Console.WriteLine(curr.ToString);
        // }
    }

    public void listOrders(StoreFront p_store)
    {
        // foreach(var curr in p_store._odersList)
        // {
        //     Console.WriteLine(curr.ToString);
        // }
    }
    
}