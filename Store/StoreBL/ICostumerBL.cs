using StoreModel;

namespace StoreBL;

public interface ICostumerBL
{
    /// <summary>
    /// This function processes the request to add a costumer to the database
    /// </summary>
    /// <param name="p_costumer"></param>
    /// <returns></returns>
    Costumer AddCostumer(Costumer p_costumer);

    /// <summary>
    /// This method gets all costumers in the database
    /// </summary>
    /// <returns></returns>

    List<Costumer> GetAllCostumers();

    /// <summary>
    /// This function processes the request to find a costumer in the database
    /// </summary>
    /// <param name="p_costumerId"></param>
    /// <returns></returns>
    List<Costumer> FindCostumer(int p_costumerId);

    /// <summary>
    /// This function processes a new order
    /// </summary>
    /// <param name="p_products"></param>
    /// <param name="p_costumer"></param>
    /// <param name="p_storeNumber"></param>
    void processOrder(List<Products> p_products, Costumer p_costumer, int p_storeNumber);

    /// <summary>
    /// This function processes the request to see all orders placed for a costumer
    /// </summary>
    /// <param name="p_costumerId"></param>
    /// <returns></returns>
    List<Orders> orderHistory(int p_costumerId);
    int createCostumerId();

}
