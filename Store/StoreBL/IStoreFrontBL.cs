using StoreModel;

namespace StoreBL;

public interface IStoreFrontBL
{
    (StoreFront, bool) findStore(StoreFront p_storeFront);
    void listOrders(StoreFront p_store);
    void listItems(StoreFront p_store);
}