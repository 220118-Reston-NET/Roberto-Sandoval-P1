using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class CostumerBL : ICostumerBL
    {
        private IRepository _repo;
        public CostumerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public Costumer AddCostumer(Costumer p_costumer)
        {
            return _repo.AddCostumer(p_costumer);
        }
    }
}