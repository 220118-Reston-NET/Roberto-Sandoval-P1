using StoreModel;

namespace StoreBL;

public interface ICostumerBL
{
    Costumer AddCostumer(Costumer p_costumer);

    (Costumer, bool) findCostumer(String p_name, string p_phone);

    void addOrder(String p_name, string p_phone, Orders p_order);

}
