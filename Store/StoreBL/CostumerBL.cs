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

    public void AddCostumer(Costumer p_costumer)
    {
        _repo.AddCostumer(p_costumer);
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

    public void placeOrder(Costumer p_costumer, List<Products> p_products)
    {
        List<LineItems> _lineItemsList = new List<LineItems>();
        LineItems _lineItem = new LineItems();
        Orders _newOrder = new Orders();
        double _orderTotal = 0.0;
        int _orderNumber = 000; // change field

        foreach (var item in p_products)
        {
            _lineItem.OrderNumber = _orderNumber; 
            _lineItem.ProductId = item.ProductId;
            _lineItem.Quantity = item.ProductQuantity;
            _lineItemsList.Add(_lineItem);
            _orderTotal += (item.ProductPrice*item.ProductQuantity);
        }

        _newOrder.OrderNumber = _orderNumber;
        _newOrder.CostumerId = p_costumer.CostumerId;
        _newOrder.StoreNumber = 000;
        _newOrder.OrderTotal = _orderTotal;
        _newOrder.OrderedItems = _lineItemsList;

        _repo.addOrder(_lineItemsList, _newOrder);
        
    
    }
    
    public void listOrders(Costumer p_costumer)
    {
        foreach(var curr in p_costumer._orders)
        {
            Console.WriteLine(curr.ToString);
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
}   
