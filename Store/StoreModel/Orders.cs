namespace StoreModel;
public class Orders
{

    public List<LineItems> _itemList;
    public string StoreFront { get; set; }
    public double Price { get; set; }

    public StoreFront store;

    public Orders()
    {
        _itemList =  new List<LineItems>();
        Price = 0.0;
    }

    public override string ToString()
    {
        return $"Store: {StoreFront}\nTotal Price: {Price}";
    }

    

}

