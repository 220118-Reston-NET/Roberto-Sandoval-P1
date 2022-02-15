using StoreModel;

namespace StoreBL;

public interface IStoreFrontBL
{
    (StoreFront, bool) findStore(StoreFront p_storeNumber);
    (Products, bool) findProduct(Products p_product);
    List<StoreInventory> listInventory(int p_storeNumber);
    void subtractInventory(List<StoreInventory> p_stock);
    void addInventory(List<StoreInventory> p_stock);
    

}