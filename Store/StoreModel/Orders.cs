namespace StoreModel;
public class Orders
{

    public List<Products> _itemList;
    public string Name { get; set; }
    public double Price { get; set; }

    public StoreFront store;

    public Orders()
    {
        _itemList =  new List<Products>();
        Price = 0.0;
    }

    public void addToOrder(Products p_product)
    {
        _itemList.Add(p_product);
    }

    public override string ToString()
    {
        return $"Name: {Name}\nPhone Total Price: {Price}";
    }

    

}

