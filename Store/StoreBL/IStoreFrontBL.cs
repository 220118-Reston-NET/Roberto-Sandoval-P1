using StoreModel;

namespace StoreBL;

public interface IStoreFrontBL
{
    (StoreFront, bool) findStore(StoreFront p_storeNumber);

    List<Products> listInventory(int p_storeNumber);

}