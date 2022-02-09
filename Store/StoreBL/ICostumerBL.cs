using StoreModel;

namespace StoreBL;

public interface ICostumerBL
{
    Costumer AddCostumer(Costumer p_costumer);

    (Costumer, bool) findCostumer(Costumer p_costumer);

    void placeOrder(Costumer p_costumer, List<Products> p_products);

    void listOrders(Costumer p_costumer);

    List<Orders> orderHistory(int p_costumerId);

}
