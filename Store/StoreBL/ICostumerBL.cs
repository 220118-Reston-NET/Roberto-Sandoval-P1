using StoreModel;

namespace StoreBL;

public interface ICostumerBL
{
    void AddCostumer(Costumer p_costumer);

    (Costumer, bool) findCostumer(Costumer p_costumer);

    void processOrder(List<Products> p_products, Costumer p_costumer, int p_storeNumber);

    void listOrders(Costumer p_costumer);

    List<Orders> orderHistory(int p_costumerId);
    int createCostumerId();

}
