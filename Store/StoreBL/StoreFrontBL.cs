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

    public (Products, bool) findProduct(Products p_product)
    {
        List<Products> _productList = _repo.ListOfProducts();

        foreach (var curr in _productList)
        {
            // If costumer exists in database return true and object
            if (curr.ProductId == p_product.ProductId)
                return (curr, true);
        }

        Products empty = new Products();
        return (empty, false);
    }

    public List<StoreInventory> listInventory(int p_storeNumber)
    {
        List<StoreInventory> inventoryList = _repo.ListInventory(p_storeNumber);

        return inventoryList;
    }

    public List<Products> listOfProducts()
    {
        List<Products> productList = _repo.ListOfProducts();

        return productList;
    }

    public void subtractInventory(List<StoreInventory> p_storeInventory)
    {
        _repo.subtractInventory(p_storeInventory);

    }

    public List<StoreInventory> addInventory(List<StoreInventory> p_storeInventory)
    {
        return _repo.addInventory(p_storeInventory);

    }

}