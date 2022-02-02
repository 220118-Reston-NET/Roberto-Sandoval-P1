using StoreModel;

namespace StoreBL;

public interface ICostumerBL
{
    Costumer AddCostumer(Costumer p_costumer);

    (Costumer, bool) findCostumer(Costumer p_costumer);

    void addOrder(Costumer p_costumer, Orders p_order);

}
