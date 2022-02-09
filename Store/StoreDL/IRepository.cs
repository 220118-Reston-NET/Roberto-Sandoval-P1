using StoreModel;

namespace StoreDL;
public interface IRepository
{
    Costumer AddCostumer(Costumer p_costumer);
    List<Costumer> ListOfCostumers();
    List<Products> ListOfProducts();
    List<StoreFront> ListOfStores();
    List<Orders> ListOfOrders(int p_costumerId);
    List<Products> ListInventory(int p_storeNumber);
    void addOrder(Costumer p_costumer, Orders p_order);

}
