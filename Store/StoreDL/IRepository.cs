using StoreModel;

namespace StoreDL;
public interface IRepository
{
    Costumer AddCostumer(Costumer p_costumer);
    List<Costumer> ListOfCostumers();
    List<Products> ListOfProducts();
    List<StoreFront> ListOfStores();
    List<Orders> ListOfOrders(int p_costumerId);
    List<StoreInventory> ListInventory(int p_storeNumber);
    void addOrder(List<LineItems> p_lineItemsList, Orders p_order);
    void subtractInventory(List<StoreInventory> p_stock);
    void addInventory(List<StoreInventory> p_stock);

    int createCostumerId();

}
