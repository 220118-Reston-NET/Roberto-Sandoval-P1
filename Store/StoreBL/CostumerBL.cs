using StoreModel;
using StoreDL;

namespace StoreBL;

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

    public (Costumer, bool) findCostumer(Costumer p_costumer)
    {
        List<Costumer> _costumerList = _repo.ListOfCostumers();

        foreach (var curr in _costumerList)
        {
            // If costumer exists in database return true and object
            if (curr.Name == p_costumer.Name && curr.Phone == p_costumer.Phone)
                return (curr, true);
        }

        Costumer empty = new Costumer();
        return (empty, false);
    }

    public void processOrder(List<Products> p_products, Costumer p_costumer, int p_storeNumber)
    {
        List<StoreInventory> _storeInventoryList = new List<StoreInventory>();

        StoreInventory _storeInventoryItem = new StoreInventory();
        LineItems _lineItem = new LineItems();
        Orders _newOrder = new Orders();
        double _orderTotal = 0.0;
        int _orderNumber = createOrderId();

        foreach (var item in p_products)
        {
            _orderTotal += (item.ProductPrice*item.ProductQuantity);

            _storeInventoryItem.StoreNumber = p_storeNumber;
            _storeInventoryItem.ProductId = item.ProductId;
            _storeInventoryItem.Quantity = item.ProductQuantity;

            _storeInventoryList.Add(_storeInventoryItem);
        }

        _repo.subtractInventory(_storeInventoryList);

        _newOrder.OrderNumber = _orderNumber;
        _newOrder.CostumerId = p_costumer.CostumerId;
        _newOrder.StoreNumber = p_storeNumber;
        _newOrder.OrderTotal = _orderTotal;

        _repo.addOrder(_newOrder);
        

        foreach (var item in p_products)
        {
            _lineItem.OrderNumber = _orderNumber; 
            _lineItem.ProductId = item.ProductId;
            _lineItem.Quantity = item.ProductQuantity;

            _repo.addLineItem(_lineItem);
        }
        
        
    }

    public List<Orders> orderHistory(int p_costumerId)
    {
        List<Orders> orderList = _repo.ListOfOrders(p_costumerId);

        return orderList;
    }

    public int createCostumerId()
    {
        return _repo.createCostumerId();
    }

    public int createOrderId()
    {
        return _repo.createOrderId();
    }
}   
