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
            if (curr.StoreNumber == p_storeFront.StoreNumber)
                return (curr, true);
        }
        //Console.WriteLine("costumer does not excist in database");

        StoreFront empty = new StoreFront();
        return (empty, false);
    }

    public List<StoreInventory> listInventory(int p_storeNumber)
    {
        List<StoreInventory> inventoryList = _repo.ListInventory(p_storeNumber);

        return inventoryList;
    }

    public void subtractInventory(List<StoreInventory> p_storeInventory)
    {
        _repo.subtractInventory(p_storeInventory);

    }

    public void addInventory(List<StoreInventory> p_storeInventory)
    {
        _repo.subtractInventory(p_storeInventory);

    }

}