using StoreModel;

namespace StoreDL;
public interface IRepository
{
    Costumer AddCostumer(Costumer p_costumer);
    List<Costumer> ListOfCostumers();

}
